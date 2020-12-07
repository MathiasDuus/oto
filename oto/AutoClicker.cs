using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;


namespace oto
{
    public partial class AutoClicker : UserControl
    {
        #region DLL imports
        // Import the RegisterHotKey Method
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        // Import the UnregisterHotKey Method
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        // Import to handle mouse
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(
    uint dwFlags,
    uint dx,
    uint dy,
    uint cButtons,
    uint dwExtraInfo);
#endregion

        public static PopUp p = new PopUp();
        public static Help h = new Help();
        public static ChangeStart cs = new ChangeStart();

        #region var

        public static bool stop;
        public static bool MaxKliks;

        public static int i;
        public static int max;
        public static int start = 1;

        public static decimal tempVal;

        // Used to identify the hotkey
        public static int UniqueHotkeyId;
        #endregion

        // Write to a file from esc method
        // Add a way to read from a file, so lable and hotKey gets changed


        public AutoClicker()
        {
            InitializeComponent();
            KeyBind();
        }

        public void KeyBind()
        {
            // gives the hot key the id of 1
            UniqueHotkeyId = 1;
            // local variable of the KeyValue
            int HotKeyCode = ChangeStart.ChangeCombo();

            // Bool to both check and register the hot key
            bool hotKeyRegistered = RegisterHotKey(
                this.Handle, UniqueHotkeyId, 0x0000, HotKeyCode
            );

            // Verify if the hotkey was succesfully registered, if not, show message in the console
            if (hotKeyRegistered)
            {
                Console.WriteLine("Global Hotkey " + ((Keys)HotKeyCode).ToString() + " was succesfully registered");
                label_start.Text = ((Keys)HotKeyCode).ToString();
            }
            else
            {
                Console.WriteLine("Global Hotkey couldn't be registered !");
            }
        }

        public void unSetHotKey()
        {
            // Unregister HotKey
            bool UnRegistered = UnregisterHotKey(this.Handle, UniqueHotkeyId);

            if (UnRegistered)
            {
                Console.WriteLine("Global Hotkey was succesfully UNregistered");
            }
            else
            {
                Console.WriteLine("Global Hotkey couldn't be UNregistered !");
            }
        }

        protected override void WndProc(ref Message m)
        {
            // Catch when a HotKey is pressed !
            if (m.Msg == 0x0312)
            {
                int id = m.WParam.ToInt32();

                // ensures it is the correct key before running the DoStart method
                if (id == 1)
                {
                    DoStart();
                }
            }

            base.WndProc(ref m);
        }

        public void DoStart()
        {
            if (start == 1)
            {
                // Set background color to green
                Color color = ColorTranslator.FromHtml("#56ba45");
                this.BackColor = color;

                tempVal = NumericUpDown_Kliks.Value;

                stop = false;

                Thread thread = new Thread(new ThreadStart(AutoClick));
                thread.Name = "klik";
                thread.Start();
            }
            if (start == 0)
            {
                start = 1;
                stop = true;

                // Reverts the background color back to standard
                this.BackColor = SystemColors.Control;
            }

        }

        public void AutoClick()
        {
            start = 0;
            int delay = Convert.ToInt32(numericUpDown_Delay.Value);

            i = 0;

            if (MaxKliks)
            {
                max = Convert.ToInt32(NumericUpDown_Kliks.Value);
            }
            else
            {
                max = Int32.MaxValue;
            }

            if (delay > 0)
            {
                while (!stop && i < max)
                {
                    Point position = Cursor.Position;
                    uint x = (uint)position.X;
                    position = Cursor.Position;
                    uint y = (uint)position.Y;
                    AutoClicker.mouse_event(6U, x, y, 0U, 0U);

                    // If it needs to go slower 
                    Thread.Sleep(delay);
                    i++;
                    if (MaxKliks && NumericUpDown_Kliks.Value >= 1)
                        this.Invoke(new MethodInvoker(() => NumericUpDown_Kliks.Value--));
                    else
                        i = 0;
                }
            }
            else if (delay == -1)
            {
                while (!stop && i < max)
                {
                    Point position = Cursor.Position;
                    uint x = (uint)position.X;
                    position = Cursor.Position;
                    uint y = (uint)position.Y;
                    AutoClicker.mouse_event(6U, x, y, 0U, 0U);

                    //i%3 sleep 15
                    if (i % 3 == 0)
                    {
                        Thread.Sleep(15);
                    }
                    i++;
                    if (MaxKliks && NumericUpDown_Kliks.Value >= 1)
                        this.Invoke(new MethodInvoker(() => NumericUpDown_Kliks.Value--));
                    else
                        i = 0;
                }
            }
            else if (delay == -2)
            {
                while (!stop && i < max)
                {
                    Point position = Cursor.Position;
                    uint x = (uint)position.X;
                    position = Cursor.Position;
                    uint y = (uint)position.Y;
                    AutoClicker.mouse_event(6U, x, y, 0U, 0U);

                    //i%4 sleep 13
                    if (i % 4 == 0)
                    {
                        Thread.Sleep(13);
                    }
                    i++;
                    if (MaxKliks && NumericUpDown_Kliks.Value >= 1)
                        this.Invoke(new MethodInvoker(() => NumericUpDown_Kliks.Value--));
                    else
                        i = 0;
                }
            }
            else
            {
                while (!stop && i < max)
                {
                    Point position = Cursor.Position;
                    uint x = (uint)position.X;
                    position = Cursor.Position;
                    uint y = (uint)position.Y;
                    AutoClicker.mouse_event(6U, x, y, 0U, 0U);
                    i++;
                    if (MaxKliks && NumericUpDown_Kliks.Value >= 1)
                        this.Invoke(new MethodInvoker(() => NumericUpDown_Kliks.Value--));
                    else
                        i = 0;
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            MaxKliks = checkBox1.Checked;

            if (MaxKliks)
            {
                NumericUpDown_Kliks.Enabled = true;
            }
            else
            {
                NumericUpDown_Kliks.Enabled = false;
            }
        }

        private void NumericUpDown_Kliks_ValueChanged(object sender, EventArgs e)
        {
            if (NumericUpDown_Kliks.Value == 0 && MaxKliks)
            {
                DoStart();
                NumericUpDown_Kliks.Value = tempVal;
            }
        }

        private void button_help_Click(object sender, EventArgs e)
        {
            OpenUC(h);
        }

        private void button_change_Click(object sender, EventArgs e)
        {
            p.KeyPreview = true;
            OpenUC(cs);
        }

        public void OpenUC(Control UC)
        {
            p.Controls.Clear();
            p.Show();
            p.Controls.Add(UC);
            p.Text = UC.Name;
            UC.Show();
        }
    }
}
