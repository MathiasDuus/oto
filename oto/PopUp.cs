using System.Windows.Forms;
using System.Configuration;
using System.Collections.Specialized;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

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
                        ConfigurationManager.AppSettings.Set("HotKey", ChangeStart.combo.ToString());
                        
                        JObject videogameRatings = new JObject(
                            new JProperty("Halo", 9),
                            new JProperty("Starcraft", 9),
                            new JProperty("Call of Duty", 7.5));

                        File.WriteAllText(@"c:\videogames.json", videogameRatings.ToString());

                        // write JSON directly to a file
                        using (StreamWriter file = File.CreateText(@"c:\videogames.json"))
                        using (JsonTextWriter writer = new JsonTextWriter(file))
                        {
                            videogameRatings.WriteTo(writer);
                        }


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
