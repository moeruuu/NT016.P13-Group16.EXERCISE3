using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using static Google.Apis.Requests.BatchRequest;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net.Sockets;

namespace exer3
{
    public partial class BookDetailsPage : Form
    {
        private string volumeId;
        public BookDetailsPage(string volumeId)
        {
            InitializeComponent();
            this.volumeId = volumeId;
            LoadBookDetailsAsync(volumeId);
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async Task LoadBookDetailsAsync(string volumeId)
        {

            progressBar.Visible = true;
            progressBar.Style = ProgressBarStyle.Marquee;
            try
            {
                
                TcpClient tcpClient = new TcpClient("127.0.0.1", 8080);
                NetworkStream stream = tcpClient.GetStream();

                string message = "GETBOOKDTAILS" + volumeId + "\n";
                byte[] data = Encoding.UTF8.GetBytes(message);
                await stream.WriteAsync(data, 0, data.Length);

                // Đọc phản hồi từ server
                byte[] bytes = new byte[4096];
                int bytesRead = await stream.ReadAsync(bytes, 0, bytes.Length);
                var response = Encoding.UTF8.GetString(bytes, 0, bytesRead);

                
                Book bookDetails = JsonConvert.DeserializeObject<Book>(response);

                // Hiển thị thông tin chi tiết sách
                if (bookDetails != null)
                {
                    DisplayBookDetails(bookDetails);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy chi tiết cho cuốn sách này!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy chi tiết sách: {ex.Message}");

            }
        }
            private void DisplayBookDetails(Book bookDetails)
            {
                // Kiểm tra và hiển thị thông tin chi tiết sách qua RichTextBox
                if (bookDetails != null)
                {
                    // Hiển thị thông tin chi tiết sách vào RichTextBox
                    rtbBookDetails.Clear(); // Xóa nội dung cũ

                    rtbBookDetails.AppendText($"Title: {bookDetails.Title ?? "No Title"}\n");
                    rtbBookDetails.AppendText($"Authors: {string.Join(", ", bookDetails.Authors ?? new string[] { "No authors" })}\n");
                    rtbBookDetails.AppendText($"Publisher: {bookDetails.Publisher ?? "Unknown"}\n");
                    rtbBookDetails.AppendText($"Published Date: {bookDetails.PublishedDate ?? "Unknown"}\n");
                    rtbBookDetails.AppendText($"Description: {bookDetails.Description ?? "No description available."}\n");

                    // Hiển thị hình ảnh bìa sách nếu có
                    if (bookDetails.ImageUrl != null)
                    {
                        try
                        {
                            picBookcover.Load(bookDetails.ImageUrl);
                            picBookcover.Visible = true; // Hiển thị hình ảnh bìa sách
                        }
                        catch (Exception)
                        {
                            picBookcover.Visible = false; // Nếu không tải được hình ảnh thì ẩn
                        }
                    }
                    else
                    {
                        picBookcover.Visible = false; // Ẩn hình ảnh nếu không có
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy chi tiết cho cuốn sách này!");
                }
            }

        }
    }
