using System.Windows.Forms;

namespace oto
{
    public partial class ChangeStart : UserControl
    {
        public static int combo;

        public ChangeStart()
        {
            InitializeComponent();
            this.ActiveControl = textBox_change_start;
        }

        public void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            combo = e.KeyValue;
            var keyStr = ((Keys)combo).ToString();
            switch (keyStr)
            {
                case "ControlKey":
                    keyStr = "Control";
                    break;
                case "ShiftKey":
                    keyStr = "Shift";
                    break;
                case "Menu":
                    keyStr = "Alt";
                    break;
            }

            textBox_change_start.Text = keyStr;
        }
    }
}
