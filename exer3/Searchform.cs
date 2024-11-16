using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
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
    public partial class Searchform : Form
    {
        private readonly user users;
        private readonly Book book;
        public Searchform(user userinfo, Book book)
        {
            InitializeComponent();
            users = userinfo;
            WelcomeText();
            //bookService = book;
            CreateDataGridView();
            this.book = book;
        }

        private void WelcomeText()
        {
            //MessageBox.Show(users.fullname);
            labelName.Text += users.fullname;
        }

        private void CreateDataGridView()
        {
            dgvBoooks.Columns.Clear();
            dgvBoooks.Columns.Add("Serial", "No.");
            dgvBoooks.Columns.Add("ID", "ID");
            dgvBoooks.Columns.Add("Etag", "Etag");
            dgvBoooks.Columns.Add("Title", "Title");
            dgvBoooks.Columns.Add("Authors", "Authors");
            dgvBoooks.Columns.Add("Publisher", "Publisher");
            dgvBoooks.Columns.Add("PublishedDate", "publishedDate");
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private async void btnSearch_Click(object sender, EventArgs e)
        {
            dgvBoooks.Rows.Clear();
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                MessageBox.Show("Vui lòng nhập tên tìm kiếm!");
                return;
            }
            try
            {
                TcpClient tcpClient = new TcpClient("127.0.0.1", 8080);
                NetworkStream stream = tcpClient.GetStream();

                string message = "SEARCHBOOK" + txtSearch.Text.Trim();
                byte[] data = Encoding.UTF8.GetBytes(message);
                await stream.WriteAsync(data, 0, data.Length);

                byte[] bytes = new byte[4096];
                int bytesread = await stream.ReadAsync(bytes, 0, bytes.Length);
                var response = Encoding.UTF8.GetString(bytes, 0, bytesread);

//                dgvBoooks.Rows.Add(response);

                List<Book> books = JsonConvert.DeserializeObject<List<Book>>(response);

                // MessageBox.Show(books[1].ToString());
                progressBar.Minimum = 0;
                if (books.Count > 0)
                {
                    progressBar.Maximum = books.Count;
                    progressBar.Value = 0;
                }
                else
                {
                    progressBar.Maximum = 1;
                    progressBar.Value = 0;
                }

                int num = 1;
                if (books != null && books.Count > 0)
                {
                    foreach (var book in books)
                    {
                        progressBar.Value++;
                        string authors = book.Authors != null ? string.Join(", ", book.Authors) : "No authors";
                        string publisher = book.Publisher ?? "Unknown";
                        string publishedDate = book.PublishedDate ?? "Unknown";

                        dgvBoooks.Rows.Add(
                            num++,
                            book.ID ?? "Unknown",
                            book.Etag ?? "Unknown",
                            book.Title ?? "No Title",
                            authors,
                            publisher,
                            publishedDate
                        );
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm tháy sách nào!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
