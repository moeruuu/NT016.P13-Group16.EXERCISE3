using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace exer3
{
    internal class addvalues
    {
        //Đây là phần để add thông tin đăng kí vào database để xử lý thông tin khi client gửi đến server. Khi nào tạo xong form server thì xóa class này
        //Cop hàm Signupprocessing vào form server để sử dụng 
        private string Signupprocessing(string requestfromclient)
        {
           
            string[] strings = requestfromclient.Split(':');
            if (strings.Length < 5 )
            {
                return "Tài khoản đã tồn tại";
            } 
            string username = strings[0];
            string password = strings[1];
            string email = strings[2];
            string name = strings[3];
            string birthday = strings[4];
            try
            {
                using (SqlConnection con = connection.getConnection())
                {
                    con.Open();
                    string addvalues = "insert into [acc] (username, pass, email, fullname, birthday) values (@username, @pass, @email, @fullname, @birthday)";
                    using (SqlCommand cmd = new SqlCommand(addvalues, con))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@pass", password);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@birthday", birthday);
                        cmd.ExecuteNonQuery();
                    }
                }
                return "Success";
            }
            catch (Exception ex)
            {
                //Hiển thị lỗi thông qua ex để biết lỗi gì
                return ex.Message;
            }

        }
    }
}
