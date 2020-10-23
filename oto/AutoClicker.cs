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
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(
            uint dwFlags,
            uint dx,
            uint dy,
            uint cButtons,
            uint dwExtraInfo);

        public static bool stop;
        public static bool MaxKliks;

        public static int i;
        public static int max;
        public static int start = 1;

        public static decimal tempVal;

        public AutoClicker()
        {
            InitializeComponent();
            KeyBind();
        }       

        public void KeyBind()
        {
            var start = Combination.FromString("Shift+X");

            Action actionStart = DoStart;

            var assignment = new Dictionary<Combination, Action>
            {
                {start, actionStart},
            };

            Hook.GlobalEvents().OnCombination(assignment);
        }
        
        public void DoStart()
        {
            if (start == 1)
            {
                tempVal = NumericUpDown_Kliks.Value;

                button_start.Enabled = false;
                button_stop.Enabled = true;

                label_stop.Visible = false;
                label_run.Visible = true;

                label_startguide.Visible = false;

                stop = false;

                Thread thread = new Thread(new ThreadStart(AutoClick));
                thread.Name = "klik";
                thread.Start();
            }
            if (start == 0)
            {
                start = 1;
                stop = true;

                button_start.Enabled = true;
                button_stop.Enabled = false;

                label_run.Visible = false;
                label_stop.Visible = true;

                label_startguide.Visible = true;
            }

        }

        private void button_start_Click(object sender, EventArgs e)
        {
            DoStart();
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            DoStart();
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

        private void AutoClicker_KeyDown(object sender, KeyEventArgs e)
        {
            // If either Shift and x or z is pressed while "oto" is focused
            // Windows will not play that anoying beep.()
            if ((e.Modifiers == Keys.Shift && e.KeyCode == Keys.X) || (e.Modifiers == Keys.Shift && e.KeyCode == Keys.Z))
            {
                DoStart();
                e.Handled = e.SuppressKeyPress = true;
            }
        }
    }
}
