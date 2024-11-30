using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Net.Sockets;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace exer3
{
    public partial class Homepage : Form
    {
        private System.Timers.Timer tokenValidationTimer;
        private user userinfo;
        string name;
        int id;
        public Homepage(user user)
        {
            InitializeComponent();
            StartTokenValidation();
            userinfo = user;
            Homepage_load();
        }

        public void Homepage_load()
        {

            lbWelcome.Text = "WELCOME TO " + userinfo.username + "'S HOMEPAGE";
            int x = (this.ClientSize.Width - lbWelcome.Width) / 2;
            lbWelcome.Location = new Point(x, lbWelcome.Height);
            lblUsername.Text += userinfo.username;
            lblFullname.Text += userinfo.username;
            lblEmail.Text += userinfo.email;

        }


        private void ClearDataUser()
        {
            userinfo.userid = null;
            userinfo.username = null;
            userinfo.fullname = null;
            userinfo.email = null;
            userinfo.birthday = null;
            userinfo.accesstoken = null;
            userinfo.refreshtoken = null;
        }

        // Refresh token mỗi 30p
        public void StartTokenValidation()
        {
            tokenValidationTimer = new System.Timers.Timer();
            tokenValidationTimer.Interval = 30 * 60 * 1000; // 30 phút
            tokenValidationTimer.Elapsed += OnTokenValidationEvent;
            tokenValidationTimer.AutoReset = true;
            tokenValidationTimer.Enabled = true;
        }

        // Event xác thực token
        private void OnTokenValidationEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            ValidateAccessToken();
        }

        // Kiểm tra token
        private void ValidateAccessToken()
        {
            using (TcpClient client = new TcpClient("127.0.0.1", 8080))
            using (NetworkStream stream = client.GetStream())
            {
                // Gửi yêu cầu xác thực token
                string message = $"VERIFY_TOKEN{userinfo.accesstoken}";
                byte[] data = Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);

                // Nhận phản hồi từ server
                byte[] buffer = new byte[256];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                // Xử lý phản hồi
                if (response == "INVALID")
                {
                    // Nếu token không hợp lệ hoặc đã hết hạn, thử làm mới token
                    RefreshAccessToken();
                }
            }
        }

        // Refresh token
        private void RefreshAccessToken()
        {
            using (TcpClient client = new TcpClient("127.0.0.1", 8080))
            using (NetworkStream stream = client.GetStream())
            {
                // Gửi yêu cầu làm mới token
                string message = $"REFRESH_TOKEN{userinfo.refreshtoken}|{userinfo.username}";
                byte[] data = Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);

                // Nhận phản hồi từ server
                byte[] buffer = new byte[256];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string datareceived = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                // Xử lý phản hồi
                string[] response = datareceived.Split('|');
                if (response[0] == "SUCCESS")
                {
                    // Cập nhật Access Token mới
                    userinfo.accesstoken = response[1];
                }
                else
                {
                    this.Hide();
                    login formLogin = new login();
                    formLogin.ShowDialog();
                    this.Close();
                    ClearDataUser();
                    MessageBox.Show("Không thể refresh token!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePassword changePassword = new ChangePassword();
            changePassword.ShowDialog();
        }

        private void linkBooksForm_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Searchform(userinfo).Show();
        }

        private void linklogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if (MessageBox.Show("Bạn có muốn đăng xuất?", "Chú ý", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Hide();
                login formLogin = new login();
                formLogin.ShowDialog();
                this.Close();
                ClearDataUser();
            }
        }
    }





}
