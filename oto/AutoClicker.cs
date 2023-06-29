using oto.Properties;
using System;
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
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        // Import the UnregisterHotKey Method
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        // Import to handle mouse
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern void mouseEvent(
            uint dwFlags,
            uint dx,
            uint dy,
            uint cButtons,
            uint dwExtraInfo);
        #endregion

        public static readonly PopUp p = new();
        public static readonly Help h = new();
        public static readonly ChangeStart cs = new();
        public Settings settings = Settings.Default;

        #region variables

        private static bool stop;
        private static bool MaxKliks;

        private static int i;
        private static int max;
        private static int start = 1;

        private static decimal tempVal;

        // Used to identify the hotkey
        private static int UniqueHotkeyId;

        #endregion

        public AutoClicker()
        {
            InitializeComponent();
            numericUpDown_delay.Value = settings.Delay;
            SetHotKey();
        }

        public void SetHotKey()
        {
            // gives the hot key the id of 1
            UniqueHotkeyId = 1;

            // local variable of the KeyValue
            int HotKeyCode = settings.HotKey;

            //Bool to both check and register the hot key
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
            settings.Save();
        }

        public void UnSetHotKey()
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

                // Ensures it is the correct key before running the DoStart method
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

                tempVal = NumericUpDown_clicks.Value;

                stop = false;

                Thread thread = new(new ThreadStart(AutoClick))
                {
                    Name = "klik"
                };
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
            int delay = settings.Delay;

            i = 0;

            if (MaxKliks)
            {
                max = Convert.ToInt32(NumericUpDown_clicks.Value);
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
                    AutoClicker.mouseEvent(6U, x, y, 0U, 0U);

                    // If it needs to go slower 
                    Thread.Sleep(delay);
                    i++;
                    if (MaxKliks && NumericUpDown_clicks.Value >= 1)
                        this.Invoke(new MethodInvoker(() => NumericUpDown_clicks.Value--));
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
                    AutoClicker.mouseEvent(6U, x, y, 0U, 0U);

                    //i%3 sleep 15
                    if (i % 3 == 0)
                    {
                        Thread.Sleep(15);
                    }
                    i++;
                    if (MaxKliks && NumericUpDown_clicks.Value >= 1)
                        this.Invoke(new MethodInvoker(() => NumericUpDown_clicks.Value--));
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
                    AutoClicker.mouseEvent(6U, x, y, 0U, 0U);

                    //i%4 sleep 13
                    if (i % 4 == 0)
                    {
                        Thread.Sleep(13);
                    }
                    i++;
                    if (MaxKliks && NumericUpDown_clicks.Value >= 1)
                        this.Invoke(new MethodInvoker(() => NumericUpDown_clicks.Value--));
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
                    AutoClicker.mouseEvent(6U, x, y, 0U, 0U);
                    i++;
                    if (MaxKliks && NumericUpDown_clicks.Value >= 1)
                        this.Invoke(new MethodInvoker(() => NumericUpDown_clicks.Value--));
                    else
                        i = 0;
                }
            }
        }

        private void Checkbox_enable_max_clicks_CheckedChanged(object sender, EventArgs e)
        {
            MaxKliks = checkbox_enable_max_clicks.Checked;

            if (MaxKliks)
            {
                NumericUpDown_clicks.Enabled = true;
            }
            else
            {
                NumericUpDown_clicks.Enabled = false;
            }
        }

        private void NumericUpDown_clicks_ValueChanged(object sender, EventArgs e)
        {
            if (NumericUpDown_clicks.Value == 0 && MaxKliks)
            {
                DoStart();
                NumericUpDown_clicks.Value = tempVal;
            }
        }

        private void Button_help_Click(object sender, EventArgs e)
        {
            OpenUC(h);
        }

        private void Button_change_Click(object sender, EventArgs e)
        {
            p.KeyPreview = true;

            p.Controls.Add(cs);
            p.Text = cs.Name;
            cs.Show();



            DialogResult dialogresult = p.ShowDialog();
            if (dialogresult == DialogResult.OK)
            {
                settings.HotKey = ChangeStart.combo;
                settings.Save();

                UnSetHotKey();
                SetHotKey();
                p.Controls.Clear();
            }
        }

        public static void OpenUC(Control UC)
        {
            p.Controls.Clear();
            p.Show();
            p.Controls.Add(UC);
            p.Text = UC.Name;
            UC.Show();
        }

        private void NumericUpDown_delay_ValueChanged(object sender, EventArgs e)
        {
            // Sets the delay and saves it
            settings.Delay = (int)numericUpDown_delay.Value;
            settings.Save();
        }
    }
}
