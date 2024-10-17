using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace exer3
{
    public partial class Homepage : Form
    {
        string name;
        public Homepage(string name)
        {
            InitializeComponent();
            this.name = name;
            lbUserInfo.Text = name;
        }

        private void funcLogOut(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất?", "Chú ý", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Hide();
                login formLogin = new login();
                formLogin.ShowDialog();
                this.Close();
            }
        }

        private void funcExit(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát?", "Chú ý", MessageBoxButtons.YesNo) == DialogResult.Yes)
                this.Close();
        }
    }
}
