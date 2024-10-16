﻿using Microsoft.AspNetCore.Http;
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
            signup signupform = new signup();
            this.Hide();
            signupform.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbusername.Text;
            string pass = tbpass.Text;

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

            HashAlgorithm al = SHA256.Create();
            byte[] inputbyte = Encoding.UTF8.GetBytes(pass);
            byte[] hashbyte = al.ComputeHash(inputbyte);
            string hashedPassword = BitConverter.ToString(hashbyte).Replace("-", "");


            try
            {
                using (TcpClient client = new TcpClient("127.0.0.1", 8080))
                using (NetworkStream stream = client.GetStream())
                {
                    // Send login message to server
                    string message = $"LOGIN|{username}|{hashedPassword}";
                    byte[] data = Encoding.UTF8.GetBytes(message);
                    stream.Write(data, 0, data.Length);

                    // Response from server
                    byte[] buffer = new byte[256];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string datareceived = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    string[] response = datareceived.Split('|');
                    // Check response
                    if (response[0] == "Đăng nhập thành công!")
                    {
                        user userinfo = new user();
                        userinfo.userid = Int32.Parse(response[1].Split(":")[1].Trim());
                        userinfo.username = response[2].Split(':')[1].Trim();
                        userinfo.fullname = response[3].Split(':')[1].Trim();
                        userinfo.email = response[4].Split(':')[1].Trim();
                        userinfo.birthday = response[5].Split(':')[1].Trim();
                        userinfo.accesstoken = response[6].Split(":")[1].Trim();
                        userinfo.refreshtoken = response[7].Split(":")[1].Trim();

                        MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Homepage formHome = new Homepage();
                        formHome.Homepage_load(userinfo);
                        formHome.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            }
            catch (SocketException ex)
            {
                MessageBox.Show("Lỗi kết nối tới server: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối tới server: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Application.Exit();
            }

        }
    }
}
