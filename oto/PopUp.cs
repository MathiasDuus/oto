using System.Windows.Forms;

namespace oto
{
    public partial class PopUp : Form
    {
        public PopUp()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                switch (this.Text)
                {
                    case "ChangeStart":
                        this.KeyPreview = false;
                        CloseUC(AutoClicker.cs);

                        // Write to a file instead
                        var keybind = new AutoClicker();
                        keybind.unSetHotKey();
                        keybind.KeyBind();
                        keybind.label_start.Text = "hello";

                        break;

                    case "Help":
                        CloseUC(AutoClicker.h);
                        break;
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void CloseUC(Control UC)
        {
            this.Hide();
            UC.Hide();
        }
    }
}
