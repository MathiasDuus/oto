using oto.Properties;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using Xceed.Wpf.Toolkit;

namespace oto
{
    public partial class MainWindow : Window
    {
        // Registers a hot key with Windows.
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
        // Unregisters the hot key with Windows.
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern void mouse_event(
            uint dwFlags,
            uint dx,
            uint dy,
            uint cButtons,
            uint dwExtraInfo);

        // Indicates whether the clicking task is running
        private bool _isRunning = false;
        public bool IsRunning
        {
            get => _isRunning;
            set
            {
                if (_isRunning != value)
                {
                    _isRunning = value;
                    if (!_isRunning)
                    {
                        StopClicking();
                    }
                }
            }
        }

        // Get the window handle
        private IntPtr Handle
        {
            get
            {
                WindowInteropHelper helper = new(this);
                return helper.Handle;
            }
        }

        // Cancellation token source to stop the clicking task
        private CancellationTokenSource? _cts;

        // Current hotkey, default to F5
        private Key _hotkey = Key.F5;

        // Used to identify the hotkey
        private static int UniqueHotkeyId;

        // To avoid triggering ValueChanged event on initialization 
        private bool _isDelayBoxInitialized = false;

        // Delay between clicks in milliseconds
        private int delay = 0;

        // User settings instance
        private static readonly Settings user_settings = Settings.Default;


        public MainWindow()
        {
            InitializeComponent();
            Topmost = true;
            Loaded += MainWindow_Loaded;
            EnableMaxClicks.Checked += EnableMaxClicks_Checked;
            EnableMaxClicks.Unchecked += EnableMaxClicks_Unchecked;
            ChangeHotkeyButton.Click += ChangeHotkeyButton_Click;

            _hotkey = KeyInterop.KeyFromVirtualKey(user_settings.Hotkey);
            CurrentHotkeyText.Text = _hotkey.ToString();
            
            delay = user_settings.Delay;
            DelayBox.Text = delay.ToString();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            HookGlobalHotkey(_hotkey);
            HwndSource source = HwndSource.FromHwnd(Handle);
            source.AddHook(HwndHook);
        }

        private void EnableMaxClicks_Checked(object sender, RoutedEventArgs e)
        {
            ClicksBox.IsEnabled = true;
        }

        private void EnableMaxClicks_Unchecked(object sender, RoutedEventArgs e)
        {
            ClicksBox.IsEnabled = false;
        }

        private void ChangeHotkeyButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeHotkeyButton.IsEnabled = false;
            StatusText.Text = "Press a key to set new hotkey...";
            this.PreviewKeyDown += MainWindow_PreviewKeyDown_ForHotkeyChange;
        }

        private void MainWindow_PreviewKeyDown_ForHotkeyChange(object sender, KeyEventArgs e)
        {
            _hotkey = e.Key;
            CurrentHotkeyText.Text = _hotkey.ToString();
            StatusText.Text = "";
            this.PreviewKeyDown -= MainWindow_PreviewKeyDown_ForHotkeyChange;
            UnhookGlobalHotkey();
            HookGlobalHotkey(_hotkey);
            ChangeHotkeyButton.IsEnabled = true;
        }

        private void DelayBox_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (!_isDelayBoxInitialized)
            {
                _isDelayBoxInitialized = true;
                return;
            }
            if (DelayBox.Value is int newDelay)
            {
                delay = newDelay;
                user_settings.Delay = delay;
                user_settings.Save();
            }
        }

        private void HookGlobalHotkey(Key HotKey = Key.F5)
        {
            // gives the hot key the id of 1
            UniqueHotkeyId = 1;

            // local variable of the KeyValue
            uint HotKeyCode = (uint)KeyInterop.VirtualKeyFromKey(HotKey);

            //Bool to both check and register the hot key
            bool hotKeyRegistered = RegisterHotKey(
                this.Handle, UniqueHotkeyId, 0x0000, HotKeyCode
            );

            // Verify if the hotkey was succesfully registered, if not, show to user
            if (hotKeyRegistered)
            {
                _hotkey = HotKey;
                CurrentHotkeyText.Text = HotKey.ToString();
                user_settings.Hotkey = (int)HotKeyCode;
                user_settings.Save();
                System.Diagnostics.Debug.WriteLine($"Hotkey registered: {HotKey} ({HotKeyCode})");
            }
            else
            {
                StatusText.Text = "Hotkey couldn't be registered!\n It may be already in use.";
            }

        }

        private IntPtr HwndHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            const int WM_HOTKEY = 0x0312;
            if (msg == WM_HOTKEY && wParam.ToInt32() == UniqueHotkeyId)
            {
                ToggleStartStop();
                handled = true;
            }
            return IntPtr.Zero;
        }

        private void ToggleStartStop()
        {
            if (IsRunning)
                StopClicking();
            else
                StartClicking();
        }

        private async void StartClicking()
        {
            IsRunning = true;
            _cts = new CancellationTokenSource();
            // Change backgound color to indicate running state
            Background = System.Windows.Media.Brushes.Green;

            // Disable all ui inputs
            ChangeHotkeyButton.IsEnabled = false;
            DelayBox.IsEnabled = false;
            EnableMaxClicks.IsEnabled = false;
            ClicksBox.IsEnabled = false;


            // Read values from UI
            if (!int.TryParse(DelayBox.Text, out delay))
            {
                StatusText.Text = "Invalid delay value";
                IsRunning = false;
                return;
            }

            user_settings.Delay = delay;
            user_settings.Save();

            bool useMaxClicks = EnableMaxClicks.IsChecked == true;
            long maxClicks = 0;

            if (useMaxClicks)
            {
                if (!long.TryParse(ClicksBox.Text, out maxClicks) || maxClicks < 1)
                {
                    StatusText.Text = "Invalid clicks value";
                    IsRunning = false;
                    return;
                }
            }

            long clicksDone = 0;

            await Task.Run(() =>
            {
                while (!_cts.Token.IsCancellationRequested)
                {
                    // If max clicks is enabled and reached → break
                    if (useMaxClicks && clicksDone >= maxClicks)
                    {
                        break;
                    }

                    // Get current cursor position on UI thread
                    Point position = Dispatcher.Invoke(() =>
                    {
                        Point point = Mouse.GetPosition(this);
                        return PointToScreen(point);
                    });

                    uint x = (uint)position.X;
                    uint y = (uint)position.Y;
                    // Left Click
                    mouse_event(6U, x, y, 0U, 0U);

                    // Only increment clicks if max clicks is enabled
                    if (useMaxClicks)
                    {
                        clicksDone++;
                    }

                    if (delay > 0)
                    {
                        Thread.Sleep(delay);
                    }
                }
            }, _cts.Token);

            IsRunning = false;
        }

        private void StopClicking()
        {
            _cts?.Cancel();

            // Re-enable all ui inputs
            ChangeHotkeyButton.IsEnabled = true;
            DelayBox.IsEnabled = true;
            EnableMaxClicks.IsEnabled = true;
            ClicksBox.IsEnabled = true;

            // Change backgound color to indicate stopped state
            Background = System.Windows.Media.Brushes.White;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            // Clean up hooks
            UnhookGlobalHotkey();
        }

        private void UnhookGlobalHotkey()
        {
            // Unregister HotKey
            UnregisterHotKey(this.Handle, UniqueHotkeyId);
        }
    }
}
