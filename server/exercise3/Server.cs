using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace exercise3
{
    public partial class TCPserver : Form
    {
        private TcpListener server;
        private Thread serverThread;
        private bool isrunning = false;
        private string connectionString = "Server=127.0.0.1;Database=account;User Id=sa;Password=your_password;";
        int getuserid;

        public TCPserver()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int port = Convert.ToInt32(txtPort.Text);
            serverThread = new Thread(() => StartServer(port));
            serverThread.Start();
            isrunning = true;
            lblStatus.Text = $"Server đang chạy trên cổng {port}";
            btnStart.Enabled = false;
            btnStop.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopServer();
            lblStatus.Text = "Server đã dừng.";
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private void StartServer(int port)
        {
            server = new TcpListener(IPAddress.Any, port);
            server.Start();
            UpdateLog($"Server đang chạy trên cổng {port}");

            while (isrunning)
            {
                try
                {
                    TcpClient client = server.AcceptTcpClient();
                    Thread clientThread = new Thread(() => HandleClient(client));
                    clientThread.Start();
                }
                catch (Exception ex)
                {
                    UpdateLog("Error: " + ex.Message);
                }
            }

            server.Stop();
        }

        private void StopServer()
        {
            isrunning = false;
            server.Stop();
            UpdateLog("Server đã dừng.");
        }

        private void HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string data = Encoding.ASCII.GetString(buffer, 0, bytesRead);

            string[] request = data.Split('|');
            string response = "";

            switch (request[0])
            {
                case "SIGN_UP":
                    response = Signupprocessing(request[1]);
                    break;
                case "LOGIN":
                    response = LoginUser(request[1], request[2]);
                    break;
                case "LOGOUT": 
                    response = logout(request[1]);
                    break;
                default:
                    response = "INVALID_COMMAND";
                    break;
            }

            byte[] responseData = Encoding.ASCII.GetBytes(response);
            stream.Write(responseData, 0, responseData.Length);
            client.Close();
        }

        private string Signupprocessing(string requestfromclient)
        {
            string[] strings = requestfromclient.Split(':');
            if (strings.Length < 5)
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
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string addvalues = "insert into [acc] (username, pass, email, fullname, birthday) values (@username, @pass, @email, @fullname, @birthday)";
                    using (SqlCommand cmd = new SqlCommand(addvalues, con))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@pass", password);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@fullname", name);
                        cmd.Parameters.AddWithValue("@birthday", birthday);
                        cmd.ExecuteNonQuery();
                    }
                }
                return "Đăng xuất thành công";
            }
            catch (Exception ex)
            {
                return $"Có lỗi xảy ra: {ex.Message}";
            }
        }

        private string LoginUser(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM [acc] WHERE Username = @Username AND Password = @Password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    string fullName = reader["FullName"].ToString();
                    string email = reader["Email"].ToString();
                    string birthday = reader["Birthday"].ToString();
                    UpdateLog($"{username} đã đăng nhập");
                    return $"Đăng nhập thành công |Username: {username}|FullName: {fullName}|Email: {email}|Birthday: {birthday}";
                }

                return "Đăng nhập thất bại";
            }
        }

        private void UpdateLog(string message)
        {
            if (lstLog.InvokeRequired)
            {
                lstLog.Invoke(new Action(() => lstLog.Items.Add(message)));
            }
            else
            {
                lstLog.Items.Add(message);
            }
        }

        private string logout(string username)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "select userid from [acc] where username = @username";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        getuserid = (int)cmd.ExecuteScalar();
                    }
                    string deletetokens = "delete from token where userid=@getuserid";
                    using (SqlCommand cm = new SqlCommand(deletetokens, conn))
                    {
                        cm.Parameters.AddWithValue("@getuserid", getuserid);
                        cm.ExecuteNonQuery();
                    }
                    string chousercook = "update user set logging=0 where userid=@getuserid";
                    using (SqlCommand cmnek = new SqlCommand(chousercook, conn))
                    {
                        cmnek.Parameters.AddWithValue("@getuserid", getuserid);
                        cmnek.ExecuteNonQuery();
                    }
                    UpdateLog($"{username} đã đăng xuất!");
                    return "cook";

                }
            }
            catch
            {
                return "Lỗi";
            }
        }
    }
}

