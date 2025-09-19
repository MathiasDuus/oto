using System.Runtime.InteropServices;

namespace oto
{
    /// <summary>
    /// Provides P/Invoke signatures for Win32 API functions used in hotkey and mouse automation.
    /// </summary>
    internal static class Win32Interop
    {
        /// <summary>
        /// Registers a system-wide hotkey.
        /// </summary>
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        /// <summary>
        /// Unregisters a system-wide hotkey.
        /// </summary>
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        /// <summary>
        /// Simulates mouse events.
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(
            uint dwFlags,
            uint dx,
            uint dy,
            uint cButtons,
            uint dwExtraInfo);
    }
}