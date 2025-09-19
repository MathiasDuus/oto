using oto.Properties;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace oto
{
    /// <summary>
    /// Main application window for the Oto clicker tool.
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _isRunning = false;
        private CancellationTokenSource? _cts;
        private Key _hotkey = Key.F5;
        private static int UniqueHotkeyId = 1;
        private bool _isDelayBoxInitialized = false;
        private int delay = 0;
        private static readonly Settings user_settings = Settings.Default;
        private HotkeyManager? _hotkeyManager;

        /// <summary>
        /// Indicates whether the clicking task is running.
        /// </summary>
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

        /// <summary>
        /// Gets the window handle for interop operations.
        /// </summary>
        private IntPtr Handle => new WindowInteropHelper(this).Handle;

        /// <summary>
        /// Initializes the main window and UI event handlers.
        /// </summary>
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
            _hotkeyManager = new HotkeyManager(Handle, UniqueHotkeyId);
            HookGlobalHotkey(_hotkey);
            HwndSource source = HwndSource.FromHwnd(Handle);
            source.AddHook(HwndHook);
        }

        private void EnableMaxClicks_Checked(object sender, RoutedEventArgs e) => ClicksBox.IsEnabled = true;
        private void EnableMaxClicks_Unchecked(object sender, RoutedEventArgs e) => ClicksBox.IsEnabled = false;

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

        /// <summary>
        /// Registers the global hotkey and updates settings.
        /// </summary>
        private void HookGlobalHotkey(Key HotKey = Key.F5)
        {
            if (_hotkeyManager == null)
                _hotkeyManager = new HotkeyManager(Handle, UniqueHotkeyId);

            bool hotKeyRegistered = _hotkeyManager.Register(HotKey);

            if (hotKeyRegistered)
            {
                _hotkey = HotKey;
                CurrentHotkeyText.Text = HotKey.ToString();
                user_settings.Hotkey = (int)KeyInterop.VirtualKeyFromKey(HotKey);
                user_settings.Save();
                System.Diagnostics.Debug.WriteLine($"Hotkey registered: {HotKey}");
            }
            else
            {
                StatusText.Text = "Hotkey couldn't be registered!\n It may be already in use.";
            }
        }

        /// <summary>
        /// Handles window messages for hotkey activation.
        /// </summary>
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

        /// <summary>
        /// Toggles the clicker between running and stopped states.
        /// </summary>
        private void ToggleStartStop()
        {
            if (IsRunning)
                StopClicking();
            else
                StartClicking();
        }

        /// <summary>
        /// Starts the automated clicking task.
        /// </summary>
        private async void StartClicking()
        {
            IsRunning = true;
            _cts = new CancellationTokenSource();
            Background = System.Windows.Media.Brushes.Green;

            ChangeHotkeyButton.IsEnabled = false;
            DelayBox.IsEnabled = false;
            EnableMaxClicks.IsEnabled = false;
            ClicksBox.IsEnabled = false;

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
                    if (useMaxClicks && clicksDone >= maxClicks)
                        break;

                    Point position = Dispatcher.Invoke(() =>
                    {
                        Point point = Mouse.GetPosition(this);
                        return PointToScreen(point);
                    });

                    uint x = (uint)position.X;
                    uint y = (uint)position.Y;
                    Win32Interop.mouse_event(6U, x, y, 0U, 0U);

                    if (useMaxClicks)
                        clicksDone++;

                    if (delay > 0)
                        Thread.Sleep(delay);
                }
            }, _cts.Token);

            IsRunning = false;
        }

        /// <summary>
        /// Stops the automated clicking task and restores UI state.
        /// </summary>
        private void StopClicking()
        {
            _cts?.Cancel();
            ChangeHotkeyButton.IsEnabled = true;
            DelayBox.IsEnabled = true;
            EnableMaxClicks.IsEnabled = true;
            ClicksBox.IsEnabled = true;
            Background = System.Windows.Media.Brushes.White;
        }

        /// <summary>
        /// Cleans up resources and unregisters hotkeys on window close.
        /// </summary>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            UnhookGlobalHotkey();
        }

        /// <summary>
        /// Unregisters the global hotkey.
        /// </summary>
        private void UnhookGlobalHotkey()
        {
            _hotkeyManager?.Unregister();
        }
    }
}
