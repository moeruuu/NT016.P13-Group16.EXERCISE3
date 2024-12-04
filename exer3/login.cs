using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
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

namespace exer3
{
    public partial class login : Form
    {

        public login()
        {
            InitializeComponent();
        }

        private void linksignup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            signup signupform = new signup();
            signupform.ShowDialog();
            this.Close();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            
            string username = tbusername.Text;
            string pass = tbpass.Text.Trim();

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            try
            {
                this.Enabled = false;
                using (TcpClient client = new TcpClient("127.0.0.1", 8080))
                using (NetworkStream stream = client.GetStream())
                {
                    // Send login message to server
                    string message = $"LOGIN{username}|{pass}|";
                    byte[] data = Encoding.UTF8.GetBytes(message);
                    await stream.WriteAsync(data, 0, data.Length);
                    //await stream.FlushAsync();


                    // Response from server
                    byte[] buffer = new byte[4092];
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    string datareceived = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    //MessageBox.Show(datareceived);
                    // Check response
                    this.Enabled = true;
                    if (datareceived.StartsWith("SUCCESS"))
                    {
                        datareceived = datareceived.Replace("SUCCESS", "");
                        string[] response = datareceived.Split('|');
                        user userinfo = new user();
                        userinfo.userid = response[0].Trim();
                        userinfo.username = response[1].Trim();
                        userinfo.fullname = response[2].Trim();
                        userinfo.email = response[3].Trim();
                        userinfo.birthday = response[4].Trim();
                        userinfo.accesstoken = response[5].Trim();
                        if (response[6] == null) {
                            MessageBox.Show("Không thể lấy được token ở google");
                        }

                        userinfo.tokengg = response[6].Trim();
                        //userinfo.refreshtoken = response[7].Split(":")[1].Trim();

                        MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //BookService book = new BookService();
                        this.Hide();
                        new Homepage(userinfo).ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        //MessageBox.Show(datareceived);
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối tới server: " + ex.Message + '\n' + ex.StackTrace, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            this.Hide();
            ForgotPassword forgotPassword = new ForgotPassword();
            forgotPassword.ShowDialog();
            this.Close();
        }
    }
}
