using System;
using System.Windows.Forms;

namespace oto
{
    public partial class Form1 : Form
    {
        AutoClicker ac = new AutoClicker();

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Controls.Add(ac);
            ac.Show();
        }
    }
}
