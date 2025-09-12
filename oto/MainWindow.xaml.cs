using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
// You might need a global keyboard hook library, e.g. Gma.System.MouseKeyHook or your own P/Invoke

namespace oto
{
    public partial class MainWindow : Window
    {
        private CancellationTokenSource? _cts;
        private Key _hotkey = Key.F5;
        private bool _isRunning = false;

        // Registers a hot key with Windows.
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
        // Unregisters the hot key with Windows.
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);


        // Used to identify the hotkey
        private static int UniqueHotkeyId;

        private IntPtr Handle
        {
            get
            {
                WindowInteropHelper helper = new(this);
                return helper.Handle;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            EnableMaxClicks.Checked += EnableMaxClicks_Checked;
            EnableMaxClicks.Unchecked += EnableMaxClicks_Unchecked;
            ChangeHotkeyButton.Click += ChangeHotkeyButton_Click;

            CurrentHotkeyText.Text = _hotkey.ToString();

            System.Diagnostics.Debug.WriteLine("Starting");

            // Hook global keyboard to listen for hotkey
            //HookGlobalHotkey();
            //HwndSource source = HwndSource.FromHwnd(Handle);
            //source.AddHook(HwndHook);
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Now the window handle is valid
            HookGlobalHotkey();
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
            // Show a dialog or capture the next key press
            StatusText.Text = "Press a key to set new hotkey...";
            this.PreviewKeyDown += MainWindow_PreviewKeyDown_ForHotkeyChange;
        }

        private void MainWindow_PreviewKeyDown_ForHotkeyChange(object sender, KeyEventArgs e)
        {
            _hotkey = e.Key;
            CurrentHotkeyText.Text = _hotkey.ToString();
            StatusText.Text = "";
            this.PreviewKeyDown -= MainWindow_PreviewKeyDown_ForHotkeyChange;
            HookGlobalHotkey(_hotkey);
        }

        private void HookGlobalHotkey(Key HotKey = Key.F5)
        {
            System.Diagnostics.Debug.WriteLine("Hooking global hotkey");
            // gives the hot key the id of 1
            UniqueHotkeyId = 1;

            // local variable of the KeyValue
            uint HotKeyCode = (uint)KeyInterop.VirtualKeyFromKey(HotKey);// settings.HotKey

            //Bool to both check and register the hot key
            bool hotKeyRegistered = RegisterHotKey(
                this.Handle, UniqueHotkeyId, 0x0000, HotKeyCode
            );

            // Verify if the hotkey was succesfully registered, if not, show message in the console
            if (hotKeyRegistered)
            {
                System.Diagnostics.Debug.WriteLine("Global Hotkey " + HotKey.ToString() + " was succesfully registered");
                _hotkey = HotKey;
                CurrentHotkeyText.Text = HotKey.ToString();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Global Hotkey couldn't be registered !");
            }

            //            settings.Save();
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
            if (_isRunning)
                StopClicking();
            else
                StartClicking();
        }

        private async void StartClicking()
        {
            _isRunning = true;
            _cts = new CancellationTokenSource();

            // Read values from UI
            int delay = 0;
            if (!int.TryParse(DelayBox.Text, out delay))
            {
                StatusText.Text = "Invalid delay value";
                _isRunning = false;
                return;
            }

            bool useMaxClicks = EnableMaxClicks.IsChecked == true;
            long maxClicks = 0;
            if (useMaxClicks)
            {
                if (!long.TryParse(ClicksBox.Text, out maxClicks) || maxClicks < 1)
                {
                    StatusText.Text = "Invalid clicks value";
                    _isRunning = false;
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

                    // Simulate mouse click at current cursor position


                    clicksDone++;

                    // Apply delay logic
                    if (delay > 0)
                    {
                        Thread.Sleep(delay);
                    }
                    else if (delay == -1)
                    {
                        // Some computation to get ~100 CPS
                        // For example: Sleep(10) or adaptive
                        Thread.Sleep(10);
                    }
                    else if (delay == -2)
                    {
                        // Higher speed (~200 CPS)
                        Thread.Sleep(5);
                    }
                }
            }, _cts.Token);

            _isRunning = false;
        }

        private void StopClicking()
        {
            _cts?.Cancel();
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
            bool UnRegistered = UnregisterHotKey(this.Handle, UniqueHotkeyId);

            if (UnRegistered)
            {
                System.Diagnostics.Debug.WriteLine("Global Hotkey was succesfully UNregistered");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Global Hotkey couldn't be UNregistered !");
            }
        }
    }
}
