﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        int id;
        public Homepage(string name, int id)
        {
            InitializeComponent();
            this.name = name;
            this.id = id;
            lbUserInfo.Text = name;
            activeloggingindatabase();

        }

        private void activeloggingindatabase()
        {
            using (SqlConnection con = connection.getConnection())
            {
                con.Open();
                string changestatus = "update [acc] set logging=1 when userid=@id";
                using (SqlCommand cmd = new SqlCommand(changestatus, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void Homepage_Load(object sender, EventArgs e)
        {

        }

        private void funcLogOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất?", "Chú ý", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Hide();
                login formLogin = new login();
                formLogin.ShowDialog();
                this.Close();
            }
        }

        private void funcExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát?", "Chú ý", MessageBoxButtons.YesNo) == DialogResult.Yes)
                this.Close();
        }
    }

   



}
