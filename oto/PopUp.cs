using System.Windows.Forms;

namespace oto
{
    public partial class PopUp : Form
    {
        public PopUp()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
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
