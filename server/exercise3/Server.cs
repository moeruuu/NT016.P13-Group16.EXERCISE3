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
        private IMongoCollection<BsonDocument> tokenCollection;
        private CancellationTokenSource cancellationTokenSource;

        public TCPserver()
        {
            InitializeComponent();
            mongoClient = new MongoClient("mongodb+srv://baitapcuacoHoi:khongbietlam@clusterbaitap.nibhk.mongodb.net/");
            database = mongoClient.GetDatabase("BT3");
            accCollection = database.GetCollection<User>("Users");
            tokenCollection = database.GetCollection<BsonDocument>("token");
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
            if (!DateTime.TryParse(strings[4], out DateTime birthday))
            {
                return "Ngày sinh không hợp lệ"; // Return an error if the date format is incorrect
            }
            var document = new User
            {
                Username = strings[0],
                Password = strings[1],
                Email = strings[2],
                Fullname = strings[3],
                Birthday = birthday,
                logging = false
            };

            await accCollection.InsertOneAsync(document);
            return "Đăng ký thành công";
        }

        private async Task<string> LoginUser(string username, string password)
        {
            var filter = Builders<User>.Filter.And(
                Builders<User>.Filter.Eq("Username", username),
                Builders<User>.Filter.Eq("Password", password)
            );

            var userDoc = await accCollection.Find(filter).FirstOrDefaultAsync();
            if (userDoc == null) return "Đăng nhập thất bại";

            var userid = userDoc.UserId;
            var accesstoken = GenerateAccessToken(username);
            var refreshtoken = GenerateRefreshToken();

            var tokenDoc = new BsonDocument
            {
                { "userid", userid },
                { "RefreshToken", refreshtoken },
                { "UsedToken", 1 },
                { "CreatedTime", DateTime.UtcNow },
                { "ExpiresTime", DateTime.UtcNow.AddMinutes(30) }
            };

            await tokenCollection.InsertOneAsync(tokenDoc);

            UpdateLog($"{username} đã đăng nhập");
            return $"Đăng nhập thành công!|UserID: {userid}|Username: {username}|AccessToken: {accesstoken}|RefreshToken: {refreshtoken}";
        }


        private async Task<string> LogOut(string username)
        {
            var userFilter = Builders<User>.Filter.Eq("Username", username);
            var userDoc = await accCollection.Find(userFilter).FirstOrDefaultAsync();

            if (userDoc == null) return "Lỗi: Tài khoản không tồn tại";
            var userid = userDoc.UserId.ToString();

            var tokenFilter = Builders<BsonDocument>.Filter.Eq("userid", userid);
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
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
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
    }
}
