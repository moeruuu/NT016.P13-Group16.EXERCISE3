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
    public partial class ForgotPassword : Form
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private async void btnGetNewPassword_Click(object sender, EventArgs e)
        {
            string email = tboxEmail.Text.Trim();
            if (String.IsNullOrEmpty(email) )
            {
                MessageBox.Show("Vui lòng nhập email!");
                return;
            }
            try
            {
                using (TcpClient client = new TcpClient("127.0.0.1", 8080))
                using (NetworkStream network = client.GetStream())
                {
                    string message = "FORGETPASSWORD" + email+"|";
                    byte[] bytes = Encoding.UTF8.GetBytes(message);
                    await network.WriteAsync(bytes, 0, bytes.Length);

                    byte[] buffer = new byte[1024];
                    int bytestream = await network.ReadAsync(buffer, 0, buffer.Length);
                    string data = Encoding.UTF8.GetString(buffer);

                    if (data.Contains("SUCCESS"))
                    {
                         MessageBox.Show("Vui lòng check email", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //MessageBox.Show(data.Replace("SUCCESSS", ""));
                        //Clipboard.SetText(data);
                        this.Hide();
                        new ChangePassword().ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(data);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
