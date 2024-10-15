using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Net.Mime.MediaTypeNames;

namespace exer3
{
    public partial class signup : Form
    {
        public signup()
        {
            InitializeComponent();
            addcb();
        }

        private void cbday_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        class Birthday
        {
            public int day;
            public int month;
            public int year;

        }
        private void addcb()
        {
            cbday.Items.Clear();

            for (int i = 1; i < 32; i++)
            {

                cbday.Items.Add(i);
            }
            for (int i = 1; i < 13; i++)
            {
                cbmonth.Items.Add(i);
            }
            for (int i = 1900; i <= 2024; i++)
            {
                cbyear.Items.Add(i);
            }
            cbday.SelectedIndex = 0;
            cbmonth.SelectedIndex = 0;
            cbyear.SelectedIndex = 124;
        }

        private void cbmonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbmonth.SelectedIndex == 3 || cbmonth.SelectedIndex == 5 || cbmonth.SelectedIndex == 8 || cbmonth.SelectedIndex == 10)
            {
                if (cbday.SelectedIndex == 30)
                {
                    MessageBox.Show("Ngày/tháng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbday.SelectedIndex--;
                }

            }
            if (cbmonth.SelectedIndex == 1)
            {
                if (cbday.SelectedIndex >= 29)
                {
                    MessageBox.Show("Ngày/tháng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbday.SelectedIndex--;
                }
            }
        }

        private void cbyear_SelectedIndexChanged(object sender, EventArgs e)
        {
            long year = Convert.ToInt64(cbyear.SelectedIndex);
            if (year % 4 != 0)
            {
                if (cbday.SelectedIndex >= 28 && cbmonth.SelectedIndex == 1)
                {
                    MessageBox.Show("Ngày/tháng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbday.SelectedIndex--;
                }
            }
            else
            {
                if (cbday.SelectedIndex >= 29 && cbmonth.SelectedIndex == 1)
                {
                    MessageBox.Show("Ngày/tháng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbday.SelectedIndex--;
                }
            }
        }
        private bool checkusername(string username)
        {
            return Regex.IsMatch(username, "^[a-zA-Z0-9]{4,15}$");
        }
        private bool checkpass(string pass)
        {
            return Regex.IsMatch(pass, @"^[\w]{6,20}$");
        }
        private bool checkmail(string mail)
        {
            return Regex.IsMatch(mail, @"^[\w]{4,15}@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$");
        }
        private bool checkfullname(string name) {
            return Regex.IsMatch(name, "^[a-zA-Z]{1,100}$");
        }

        private void btnsignup_Click(object sender, EventArgs e)
        {
            string username = tbusername.Text;
            string pass = tbpass.Text;
            string cfpass = tbcfpass.Text;
            string name = tbfullname.Text;
            string email = tbemail.Text;
            DateTime birthday = new DateTime((int)cbyear.SelectedItem, (int)cbmonth.SelectedItem, (int)cbday.SelectedItem);
            if (!checkusername(username))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập không chứa kí tự đặc biệt và dài từ 5 đến 15 chữ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!checkpass(pass))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu từ 6 đến 20 chữ số", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!checkfullname(name)){
                MessageBox.Show("Vui lòng nhập họ tên đúng định dạng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
            if (!checkmail(email))
            {
                MessageBox.Show("Vui lòng nhập email đúng định dạng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (pass != cfpass)
            {
                MessageBox.Show("Mật khẩu không khớp!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                //Lấy IP và port server
                TcpClient client = new TcpClient("127.0.0.1", 8080);
                string data = $"{username};{pass};{email};{name};{birthday}";
                byte[] bytesdata = Encoding.UTF8.GetBytes(data);
                NetworkStream stream = client.GetStream();
                stream.Write(bytesdata, 0, bytesdata.Length);

                //Lấy response từ server
                byte[] responseData = new byte[256];
                int bytes = stream.Read(responseData, 0, responseData.Length);
                string response = Encoding.UTF8.GetString(responseData, 0, bytes);

                //Tạo một chuỗi để server gửi Success nghĩa là đã đăng ký thành công
                if (response == "Success")
                {

                    DialogResult rs = MessageBox.Show("Đăng ký thành công!", "Thành công", MessageBoxButtons.OK);
                    if (rs == System.Windows.Forms.DialogResult.OK)
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tài khoản đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                stream.Close();
                client.Close();
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Lỗi kết nối đến server: " + ex.Message);
            }
        }
    }
}
