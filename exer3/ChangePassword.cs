using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exer3
{
    public partial class ChangePassword : Form
    {
        private string email;
        public ChangePassword(string email)
        {
            InitializeComponent();
            this.email = email;
        }

        private async void btnChangePassword_Click(object sender, EventArgs e)
        {
            string currentPassword = tboxReceivedPassword.Text.Trim();
            string newPassword = tboxNewPassword.Text.Trim();
            string confirmPassword = tboxConfirmPassword.Text.Trim();
            if (String.IsNullOrEmpty(currentPassword) || String.IsNullOrEmpty(newPassword) || String.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            if (newPassword.Length < 6)
            {
                MessageBox.Show("Mật khẩu mới phải từ 6 ký tự!");
                return;
            }
            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận không khớp!");
                return;
            }
            try
            {
                using (TcpClient client = new TcpClient ("127.0.0.1", 8080))
                {
                    using (NetworkStream network = client.GetStream())
                    {
                        string message = $"CHANGEPASSWORD{email}|{currentPassword}|{newPassword}|";
                        byte[] bytes = Encoding.UTF8.GetBytes(message);
                        await network.WriteAsync(bytes, 0, bytes.Length);

                        byte[] buffer = new byte[1024];
                        int byteCount = await network.ReadAsync(buffer, 0, buffer.Length);
                        string response = Encoding.UTF8.GetString(buffer, 0, byteCount);

                        if (response == "SUCCESS")
                        {
                            this.Hide();
                            MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            new login().ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show(response, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }
    }
}
