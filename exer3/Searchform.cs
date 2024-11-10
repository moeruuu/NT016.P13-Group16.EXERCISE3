using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exer3
{
    public partial class Searchform : Form
    {
        private readonly user users;
        public Searchform(user userinfo)
        {
            InitializeComponent();
            users = userinfo;
            WelcomeText();
        }

        private void WelcomeText()
        {
            MessageBox.Show(users.fullname);
            labelName.Text += users.fullname;
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
