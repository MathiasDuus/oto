using Newtonsoft.Json;
using System.IO;
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

                        // Write to file
                        //ConfigurationManager.AppSettings.Set("HotKey", ChangeStart.combo.ToString());
                        Hotkey hotkey = new Hotkey
                        {
                            Key = ChangeStart.combo,
                        };

                        File.WriteAllText(AutoClicker.settingPath, JsonConvert.SerializeObject(hotkey));



                        var keybind = new AutoClicker();
                        keybind.unSetHotKey();
                        keybind.KeyBind();

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
