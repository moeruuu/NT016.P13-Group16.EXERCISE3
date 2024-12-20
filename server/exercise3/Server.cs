﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using MongoDB.Bson;
using Microsoft.VisualBasic.ApplicationServices;
using System.Text.Json;
using MongoDB.Driver.Core.Events;
using MongoDB.Driver.Core.Configuration;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Policy;
using Newtonsoft.Json;
using MimeKit;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace exercise3
{
    public partial class TCPserver : Form
    {
        private TcpListener server;
        private Thread serverThread;
        private bool isrunning = false;
        private MongoClient mongoClient;
        private IMongoDatabase database;
        private IMongoCollection<User> accCollection;
        private IMongoCollection<Token> tokenCollection;
        private CancellationTokenSource cancellationTokenSource;
        private readonly User users;
        private readonly BookService bookService;
        private static string name;

        public TCPserver(BookService book)
        {
            InitializeComponent();
            mongoClient = new MongoClient("mongodb+srv://baitapcuacoHoi:khongbietlam@clusterbaitap.nibhk.mongodb.net/");
            database = mongoClient.GetDatabase("BT3");
            accCollection = database.GetCollection<User>("Users");
            tokenCollection = database.GetCollection<Token>("Token");
            bookService = book;
        }

        private async Task activeloggingindatabase(string username, bool active)
        {
            var filter = Builders<User>.Filter.Eq("Username", username);
            var update = Builders<User>.Update.Set("logging", active);
            await accCollection.UpdateOneAsync(filter, update);
        }

        private async Task<string> Signupprocessing(string requestfromclient)
        {
            var strings = requestfromclient.Split(';');

            var filter = Builders<User>.Filter.Or(
                Builders<User>.Filter.Eq("Username", strings[0]),
                Builders<User>.Filter.Eq("Email", strings[2])
                );
            if (strings.Length < 5) return "Tài khoản đã tồn tại";
            if (!DateTime.TryParse(strings[4].Trim(), out DateTime birthday))
            {
                return "Ngày sinh không hợp lệ"; // Return an error if the date format is incorrect
            }
            var document = new User
            {
                UserId = ObjectId.GenerateNewId(),
                Username = strings[0].Trim(),
                Password = strings[1].Trim(),
                Email = strings[2].Trim(),
                Fullname = strings[3].Trim(),
                Birthday = birthday,
                logging = false
            };
            UpdateLog($"{strings[0]}: Đăng ký thành công!");
            await accCollection.InsertOneAsync(document);
            return "Đăng ký thành công";
        }

        private async Task<string> LoginUser(string requestfromclient)
        {
            try
            {
                var strings = requestfromclient.Split('|');
                //MessageBox.Show(strings[1]);
                var filter =  Builders<User>.Filter.Eq(u => u.Username, strings[0].Trim());
                var userDoc = await accCollection.Find(filter).FirstOrDefaultAsync();
                
                if (userDoc == null)
                {
                    return "Không tìm thấy người dùng";
                }
                string password = strings[1].Trim();

                HashAlgorithm al = SHA256.Create();
                byte[] inputbyte = Encoding.UTF8.GetBytes(password);
                byte[] hashbyte = al.ComputeHash(inputbyte);
                string hashedPassword = BitConverter.ToString(hashbyte).Replace("-", "");
                //MessageBox.Show(password + "HII");
                if (hashedPassword != userDoc.Password.Trim())
                {
                    return "Sai mật khẩu";
                }
                name = userDoc.Username;
                var userid = userDoc.UserId;
               // MessageBox.Show(userDoc.UserId.ToString());
                var accesstoken = GenerateAccessToken(strings[0].Trim());
                var refreshtoken = GenerateRefreshToken();

                var tokenDoc = new Token
                {
                    Id = ObjectId.GenerateNewId(),
                    UserId = userid,
                    RefreshToken = refreshtoken,
                    UsedToken = 1,
                    CreateTime = DateTime.Now,
                    ExpiresTime = DateTime.Now.AddMinutes(30),
                };
                await activeloggingindatabase(strings[0].Trim(), true);
                await tokenCollection.InsertOneAsync(tokenDoc);
                var tokengg = await bookService.GetAccessToken();

                UpdateLog($"{strings[0].Trim()} đã đăng nhập");
                return $"SUCCESS{userDoc.UserId}|{userDoc.Username}|{userDoc.Fullname}|{userDoc.Email}|{userDoc.Birthday}|{accesstoken}|{tokengg}";
            }
            catch (Exception ex) {

                //MessageBox.Show(ex.Message);
                return "Đăng nhập thất bại!";
            }
        }

        private async Task<string> RefreshToken(string message)
        {
            var strings = message.Split('|');

            if (ValidateRefreshToken(strings[0].Trim()))
            {

                string newAccessToken = GenerateAccessToken(strings[1].Trim());
                return $"SUCCESS|{newAccessToken}";
                UpdateLog($"{strings[1].Trim()}: Tạo Token mới thành công!");
            }
            else
            {
                return "FAILED";
            }
        }

        private bool ValidateRefreshToken(string refreshtoken)
        {
            var filter = Builders<Token>.Filter.Eq("RefreshToken", refreshtoken);
            var tokenDocument = tokenCollection.Find(filter).FirstOrDefault();
            if (tokenDocument != null)
            {
                int usedToken = tokenDocument.UsedToken; 
                DateTime expiresTime = tokenDocument.ExpiresTime;

                if (usedToken > 0 || expiresTime < DateTime.UtcNow)
                {
                    return false;
                }
            }
            return true;

        }

        private async Task<string> LogOut(string user)
        {
            var strings = user.Split("|");
            var username = strings[0].Trim();
            var filter = Builders<User>.Filter.Eq(u => u.Username, username);
            var userDoc = await accCollection.Find(filter).FirstOrDefaultAsync();


            if (userDoc == null) return "Lỗi: Tài khoản không tồn tại";
            var userid = userDoc.UserId.ToString();

            var tokenfilter = Builders<Token>.Filter.Eq("userid", userid);
            await tokenCollection.DeleteManyAsync(tokenfilter);

            await activeloggingindatabase(username, false);

            UpdateLog($"{username} đã đăng xuất!");
            return "SUCCESS";
        }

        private async Task<string> ForgetPassword(string email)
        {
            var filter = Builders<User>.Filter.Eq(u=>u.Email, email);
            var getemail = await accCollection.Find(filter).FirstOrDefaultAsync();

            if (getemail == null) return "Email không tồn tại";

            var password = Guid.NewGuid().ToString();

            HashAlgorithm al = SHA256.Create();
            byte[] inputbyte = Encoding.UTF8.GetBytes(password);
            byte[] hashbyte = al.ComputeHash(inputbyte);
            string hashedPassword = BitConverter.ToString(hashbyte).Replace("-", "");
            //Viết gửi mail vào đây nhé
            var cfemail = await SendMail(email, password);
            if (cfemail.Contains("thành công"))
            {

                var update = Builders<User>.Update.Set(u => u.Password, hashedPassword);
                await accCollection.UpdateOneAsync(filter, update);

                UpdateLog($"{getemail.Username} đã đổi mật khẩu mới!");
                return "SUCCESS";
            }
            else
            {
                return cfemail;
            }
        }

        private async Task<string> ChangePassword(string requestFromClient)
        {
            try
            {
                var strings = requestFromClient.Split('|');
                if (strings.Length < 3)
                {
                    return "Dữ liệu không hợp lệ";
                }
                string email = strings[0].Trim();
                string currentPassword = strings[1].Trim();
                string newPassword = strings[2].Trim();
                if (newPassword.Length < 6)
                {
                    return "Mật khẩu mới phải từ 6 ký tự.";
                }

                var filter = Builders<User>.Filter.Eq(u => u.Email, email);
                var userDoc = await accCollection.Find(filter).FirstOrDefaultAsync();
                if (userDoc == null)
                {
                    return "Người dùng không tồn tại";
                }
                HashAlgorithm hashAlgorithm = SHA256.Create();
                byte[] currentPasswordBytes = Encoding.UTF8.GetBytes(currentPassword);
                byte[] hashedCurrentPasswordBytes = hashAlgorithm.ComputeHash(currentPasswordBytes);
                string hashedCurrentPassword = BitConverter.ToString(hashedCurrentPasswordBytes).Replace("-", "");

                if (hashedCurrentPassword != userDoc.Password)
                {
                    return "Mật khẩu hiện tại không đúng";
                }
                byte[] newPasswordBytes = Encoding.UTF8.GetBytes(newPassword);
                byte[] hashedNewPasswordBytes = hashAlgorithm.ComputeHash(newPasswordBytes);
                string hashedNewPassword = BitConverter.ToString(hashedNewPasswordBytes).Replace("-", "");
                if (hashedNewPassword == userDoc.Password)
                {
                    return "Không thể đổi thành mật khẩu cũ";
                }

                var update = Builders<User>.Update.Set(u => u.Password, hashedNewPassword);
                await accCollection.UpdateOneAsync(filter, update);

                UpdateLog($"{userDoc.Username} đã đổi mật khẩu thành công");
                return "SUCCESS";
            }
            catch (Exception ex)
            {
                UpdateLog($"Lỗi: {ex.Message}");
                return "Lỗi hệ thống";
            }

        }

        private async Task<string> SendMail(string email, string newpass)
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            string sv = "smtp.gmail.com";
            int port = 465;
            string from = "ltmkhongvui@gmail.com";
            string pass = "zczehpxjavqhdlsz";
            var filter = Builders<User>.Filter.Eq(u => u.Email, email);
            var finduser = await accCollection.Find(filter).FirstOrDefaultAsync();
            if (finduser == null) return "Không tồn tại email";
            var bodybuilder = new BodyBuilder();
            string body = $@"
        <!DOCTYPE html>
        <html>
        <head>
        <style>
            body {{
                font-family: 'Arial', sans-serif;
                background-color: #f9f9f9;
                margin: 0;
                padding: 0;
            }}
            .container {{
                max-width: 600px;
                margin: 20px auto;
                background: #ffffff;
                border-radius: 8px;
                box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
                overflow: hidden;
                border: 1px solid #ddd;
            }}
            .header {{
                background-color: #4CAF50;
                color: #ffffff;
                text-align: center;
                padding: 20px;
                font-size: 24px;
                font-weight: bold;
            }}
            .content {{
                padding: 20px;
                font-size: 16px;
                line-height: 1.6;
                color: #333;
            }}
            .content p {{
                margin: 10px 0;
            }}
            .note{{
                padding: 20px;
                font-size: 12px;
                color: #333;
                line-height: 1.6;
            }}
        
        </style>
        </head>
        <body>
            <div class=""container"">
                <div class=""header"">
                    FORGET YOUR PASSWORD?
                </div>
                <div class=""content"">
                    <p>Đây là password mới của bạn:</p>
                    <p><strong>{newpass}</strong></p>
                    <div class=""note"">
                    <p>Đây chỉ là password tạm thời. Bạn hãy lưu lại và đổi password mới nhé!</p>
                    </div>
                    </div>
                </div>
            </div>
        </body>
        </html>";
            try
            {
                var message = new MimeKit.MimeMessage();
                message.From.Add(MailboxAddress.Parse(from));
                message.To.Add(MailboxAddress.Parse(finduser.Email));
                message.Subject = "FORGET PASSWORD?";
                bodybuilder.HtmlBody = body;
                message.Body = bodybuilder.ToMessageBody();
                using (var client = new MailKit.Net.Smtp.SmtpClient()) {
                    client.Connect(sv, port, true);
                    client.Authenticate(from, pass);
                    client.Send(message);
                    client.Disconnect(true);
                }
                return "Xác nhận mail thành công";

            }
            catch (Exception ex)
            {
                return ex.Message + "\n" + ex.StackTrace;
            }
        }
        private void UpdateLog(string message)
        {
            //MessageBox.Show(message);
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateLog(message)));
            }
            else
            {
                lstLog.Items.Add(message);
            }
        }

        private string GenerateAccessToken(string username)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("0NoDHn8CwloyRZMw1YqXlxIdGhyaJbzr"));
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
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        private async Task<string> VerifyToken(string token)
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
                UpdateLog($"{users.Username}: Token không hợp lệ");
            }
        }

            private void btnStop_Click(object sender, EventArgs e)
        {
            if (isrunning)
            {
                CloseServerAsync();
            }
            else
            {
                UpdateLog("Server chưa bắt đầu.");
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!isrunning)
            {
                try
                {
                    int port = Convert.ToInt32(txtPort.Text);
                    StartListeningAsync(port);

                    //UpdateLog($"Server đã bắt đầu trên port {port}");
                }
                catch (Exception ex)
                {
                    UpdateLog($"Lỗi khi khởi động server: {ex.Message}");
                }
            }
            else
            {
                UpdateLog("Server đã được bắt đầu.");
            }
        }

        private async Task StartListeningAsync(int port)
        {
            isrunning = true;
            server = new TcpListener(System.Net.IPAddress.Any, port);
            server.Start();
            UpdateLog($"[SERVER]: Bắt đầu ở port {port}");

            while (isrunning)
            {
                var tcpClient = await server.AcceptTcpClientAsync();
                ReceiveData(tcpClient);
            }
        }

        private async Task CloseServerAsync()
        {
            if (server != null)
            {
                server.Stop();
                isrunning = false;
                UpdateLog("[SERVER]: Server đã đóng!");
            }
        }

        private async Task ReceiveData(TcpClient tcpClient)
        {
            byte[] bytes = new byte[128];
            NetworkStream stream = tcpClient.GetStream();
            while (stream.CanRead && isrunning)
            {
                int bytesRead = await stream.ReadAsync(bytes, 0, bytes.Length);
                if (bytesRead == 0)
                    break;
                string incomingMessage = Encoding.UTF8.GetString(bytes);
                if (incomingMessage.StartsWith("signup:"))
                {
                    incomingMessage = incomingMessage.Replace("signup:", "");
                    string messgaetoclient = await Signupprocessing(incomingMessage);
                    SendMessageToClient(tcpClient, messgaetoclient);
                    //UpdateLog("SERVER: Client đã đăng ký thành công!");
                }
                else if (incomingMessage.StartsWith("LOGIN"))
                {
                    incomingMessage = incomingMessage.Replace("LOGIN", "");
                    //UpdateLog(incomingMessage);
                    string messgaetoclient = await LoginUser(incomingMessage);
                    SendMessageToClient(tcpClient, messgaetoclient);
                }
                else if (incomingMessage.StartsWith("REFRESH_TOKEN"))
                {
                    incomingMessage = incomingMessage.Replace("REFRESH_TOKEN", "");
                    string messgaetoclient = await RefreshToken(incomingMessage);
                    SendMessageToClient(tcpClient, messgaetoclient);
                }
                else if (incomingMessage.StartsWith("VERIFY_TOKEN"))
                {
                    incomingMessage = incomingMessage.Replace("VERIFY_TOKEN", "");
                    string messgaetoclient = await VerifyToken(incomingMessage);
                    SendMessageToClient(tcpClient, messgaetoclient);
                }
                else if (incomingMessage.StartsWith("LOGOUT"))
                {
                    incomingMessage = incomingMessage.Replace("LOGOUT", "");
                    string messagetoclients = await LogOut(incomingMessage);
                    //MessageBox.Show(messagetoclients);
                    SendMessageToClient(tcpClient, messagetoclients);
                }
                else if (incomingMessage.StartsWith("SEARCH_BOOK"))
                {
                    incomingMessage = incomingMessage.Replace("SEARCH_BOOK", "");
                    var strings = incomingMessage.Split("|");
                    var messagetoclient = await bookService.SearchBooks(strings[0]);
                    UpdateLog($"{name} đã tra sách");
                    SendListToClient(tcpClient, messagetoclient);
                }
                else if (incomingMessage.StartsWith("SEARCHSHELF"))
                {
                    var messagetoclient = await bookService.SearchShelves();
                    UpdateLog($"{name} đã tra kệ");
                    SendListToClient(tcpClient, messagetoclient);
                }
                else if (incomingMessage.StartsWith("GETBOOK"))
                {

                    incomingMessage = incomingMessage.Replace("GETBOOK", "");
                    var strings = incomingMessage.Split("|");
                    var messagetoclient = await bookService.GetBooks(strings[0]);
                    UpdateLog($"{name} đã tra sách");
                    SendListToClient(tcpClient, messagetoclient);
                }
                else if (incomingMessage.StartsWith("ADDBOOK"))
                {
                    incomingMessage = incomingMessage.Replace("ADDBOOK", "");
                    var strings = incomingMessage.Split("|");
                    var messagetoclient = await bookService.AddBooks(strings[0], strings[1]);
                    UpdateLog($"{name} đã thêm sách");
                    SendMessageToClient(tcpClient, messagetoclient);
                }
                else if (incomingMessage.StartsWith("REMOVEBOOK"))
                {
                    incomingMessage = incomingMessage.Replace("REMOVEBOOK", "");
                    var strings = incomingMessage.Split("|");
                    var messagetoclient = await bookService.RemoveBooks(strings[0], strings[1]);
                    //MessageBox.Show(strings[0] + "hihi\n" + strings[1] + "hihi");
                    UpdateLog($"{name} đã xóa sách khỏi kệ");
                    SendMessageToClient(tcpClient, messagetoclient);
                }
                else if (incomingMessage.StartsWith("BOOKINFO"))
                {
                    // Loại bỏ chuỗi "GETBOOKDETAILS" khỏi message
                    incomingMessage = incomingMessage.Replace("BOOKINFO", "");
                    var strings = incomingMessage.Split("|");
                    var bookDetails = await bookService.GetBookDetails(strings[0]);
                    var messagetoclient = JsonConvert.SerializeObject(bookDetails);
                    UpdateLog($"{name} đã tra chi tiết sách");
                    SendMessageToClient(tcpClient, messagetoclient);
                }
                else if (incomingMessage.StartsWith("CHANGEPASSWORD"))
                {
                    //MessageBox.Show(incomingMessage);
                    incomingMessage = incomingMessage.Replace("CHANGEPASSWORD", "").Trim();
                    string responseMessage = await ChangePassword(incomingMessage);
                    await SendMessageToClient(tcpClient, responseMessage);
                }
                else if (incomingMessage.StartsWith("FORGETPASSWORD"))
                {
                    //MessageBox.Show(incomingMessage);
                    incomingMessage = incomingMessage.Replace("FORGETPASSWORD", "");
                    string[] strings = incomingMessage.Split("|");
                    var messageforgetpass = await ForgetPassword(strings[0]);
                    //MessageBox.Show(messageforgetpass);
                    SendMessageToClient(tcpClient, messageforgetpass);
                }

            }
        }

        private async Task SendMessageToClient(TcpClient tcpClient, string message)
        {
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            NetworkStream stream = tcpClient.GetStream();
            await stream.WriteAsync(messageBytes, 0, messageBytes.Length);
        }

        public async Task SendListToClient<T>(TcpClient tcpClient, List<T> list)
        {
            try
            {
                string jsonMessage = JsonConvert.SerializeObject(list);
                byte[] bytes = Encoding.UTF8.GetBytes(jsonMessage);
                NetworkStream stream = tcpClient.GetStream();
                await stream.WriteAsync(bytes, 0, bytes.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
