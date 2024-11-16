using System;
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

        private async Task activeloggingindatabase(string username)
        {
            var filter = Builders<User>.Filter.Eq("Username", username);
            var update = Builders<User>.Update.Set("logging", true);
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
                activeloggingindatabase(strings[0].Trim());
                await tokenCollection.InsertOneAsync(tokenDoc);
                var tokengg = await bookService.GetAccessToken();

                UpdateLog($"{strings[0].Trim()} đã đăng nhập");
                return $"SUCESS{userDoc.UserId}|{userDoc.Username}|{userDoc.Fullname}|{userDoc.Email}|{userDoc.Birthday}|{accesstoken}|{tokengg}";
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

        private async Task<string> LogOut(string username)
        {
            var userFilter = Builders<User>.Filter.Eq("Username", username);
            var userDoc = await accCollection.Find(userFilter).FirstOrDefaultAsync();


            if (userDoc == null) return "Lỗi: Tài khoản không tồn tại";
            var userid = userDoc.UserId.ToString();

            var tokenFilter = Builders<Token>.Filter.Eq("userid", userid);
            await tokenCollection.DeleteManyAsync(tokenFilter);

            var update = Builders<User>.Update.Set("Logging", false);
            await accCollection.UpdateOneAsync(userFilter, update);

            UpdateLog($"{username} đã đăng xuất!");
            return "Đăng xuất thành công";
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
            server = new TcpListener(IPAddress.Any, port);
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
                else if (incomingMessage.StartsWith("SEARCHBOOK"))
                {
                    incomingMessage = incomingMessage.Replace("SEARCHBOOK", "");
                    var messagetoclient = await bookService.SearchBooks(incomingMessage);
                    UpdateLog($"{name} đã tra sách");
                    SendListToClient(tcpClient, messagetoclient);

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
