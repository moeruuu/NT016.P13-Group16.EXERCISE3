using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace exercise3
{
    public partial class TCPserver : Form
    {
        private TcpListener server;
        private Thread serverThread;
        private bool isrunning = false;
        private string connectionString = "Server=127.0.0.1;Database=account;User Id=sa;Password=your_password;";
        int getuserid;
        private CancellationTokenSource cancellationTokenSource;

        public TCPserver()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int port = Convert.ToInt32(txtPort.Text);
            cancellationTokenSource = new CancellationTokenSource();
            serverThread = new Thread(() => StartServer(port));
            serverThread.Start();
            isrunning = true;
            lblStatus.Text = $"Server đang chạy trên cổng {port}";
            btnStart.Enabled = false;
            btnStart.BackColor = Color.DimGray;
            btnStop.Enabled = true;
            MessageBox.Show("Kết nối thành công");
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
        try
        {
            server = new TcpListener(IPAddress.Any, port);
            server.Start();
            UpdateLog($"Server đang chạy trên cổng {port}");
        }
            catch (Exception ex)
            {
                UpdateLog("Lỗi khởi động Server " + ex.Message);
                return ;
            }

            while (!cancellationTokenSource.Token.IsCancellationRequested)
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

        private void activeloggingindatabase(string username)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string changestatus = "update [acc] set logging=1 when username=@username";
                using (SqlCommand cmd = new SqlCommand(changestatus, con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private void StopServer()
        {
            cancellationTokenSource.Cancel();
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
                    activeloggingindatabase(request[1]);
                    response = LoginUser(request[1], request[2]);
                    break;
                case "LOGOUT": 
                    response = LogOut(request[1]);
                    break;
                case "VERIFY_TOKEN":
                    response = VerifyToken(request[1]);
                    break;
                case "REFRESH_TOKEN":
                    response = RefreshToken(request[1], request[2]);
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
                    int userid = Int32.Parse(reader["UserID"].ToString());
                    string fullName = reader["FullName"].ToString();
                    string email = reader["Email"].ToString();
                    string birthday = reader["Birthday"].ToString();

                    //tạo access_token và refresh_token
                    string accesstoken = GenerateAccessToken(username);
                    string refreshtoken = GenerateRefreshToken();

                    string addvalues = "INSERT INTO [TOKEN] (UserID, RefreshToken, UsedToken, CreatedTime, ExpiresTime) VALUES (@userid, @refreshtoken, 1, GETDATE(), DATEADD(MINUTE, 30, GETDATE()))";
                    using (SqlCommand command = new SqlCommand(addvalues, conn))
                    {
                        command.Parameters.AddWithValue("@userid", userid);
                        cmd.Parameters.AddWithValue("@refreshtoken", refreshtoken);
                        cmd.ExecuteNonQuery();
                    }

                    UpdateLog($"{username} đã đăng nhập");
                    return $"Đăng nhập thành công!|UserID: {userid}|Username: {username}|FullName: {fullName}|Email: {email}|Birthday: {birthday}|AccessToken: {accesstoken}|RefreshToken: {refreshtoken}";
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

        private string GenerateAccessToken(string username)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("exercise3_LTMCB"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: "yourAppName",
                audience: "yourAppName",
                claims: null,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

        private string GenerateRefreshToken()
        {
            var randomnumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomnumber);
                return Convert.ToBase64String(randomnumber);
            }
        }

        private string VerifyToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("exercise3_LTMCB");

            try
            {
                tokenHandler.ValidateToken(token, 
                    new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidIssuer = "yourAppName",
                        ValidAudience = "yourAppName",
                        ClockSkew = TimeSpan.Zero
                    }, 
                out SecurityToken validatedToken);

                // Token hợp lệ
                return "VALID";
            }
            catch
            {
                // Token không hợp lệ
                return "INVALID";
            }
        }

        private string RefreshToken(string refreshtoken, string username)
        {
            // Kiểm tra Refresh Token có hợp lệ không
            if (ValidateRefreshToken(refreshtoken))
            {
                // Tạo Access Token mới
                string newAccessToken = GenerateAccessToken(username);

                // Trả về Access Token mới cho client
                return  $"SUCCESS|{newAccessToken}";
            }
            else
            {
                // Refresh Token không hợp lệ
                return "FAILED";
            }
        }

        private bool ValidateRefreshToken(string refreshtoken)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM [TOKEN] WHERE  RefreshToken = @RefreshToken";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@RefreshToken", refreshtoken);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    //kiem tra token hợp lệ
                    int usedtoken = reader.GetInt16(0);
                    DateTime expirestime = reader.GetDateTime(5);
                    if (usedtoken > 0 || expirestime < DateTime.Now)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        private string LogOut(string username)
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

