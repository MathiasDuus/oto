using System.Windows.Input;

namespace oto
{
    /// <summary>
    /// Manages registration and unregistration of global hotkeys.
    /// </summary>
    internal class HotkeyManager
    {
        private readonly IntPtr _windowHandle;
        private int _hotkeyId;

        public HotkeyManager(IntPtr windowHandle, int hotkeyId = 1)
        {
            _windowHandle = windowHandle;
            _hotkeyId = hotkeyId;
        }

        /// <summary>
        /// Registers the specified hotkey.
        /// </summary>
        public bool Register(Key hotkey)
        {
            uint hotkeyCode = (uint)KeyInterop.VirtualKeyFromKey(hotkey);
            return Win32Interop.RegisterHotKey(_windowHandle, _hotkeyId, 0x0000, hotkeyCode);
        }

        /// <summary>
        /// Unregisters the current hotkey.
        /// </summary>
        public void Unregister()
        {
            Win32Interop.UnregisterHotKey(_windowHandle, _hotkeyId);
        }
    }
}