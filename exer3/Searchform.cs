﻿using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exer3
{
    public partial class Searchform : Form
    {
        private readonly user users;
        private int selectedIndexBookShelf = -1;
        private int selectedIndexBook = -1;
        public Searchform(user userinfo)
        {
            InitializeComponent();
            users = userinfo;
            WelcomeText();
            //bookService = book;
            CreateDataGridView();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
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
            dgvBoooks.Columns.Add("Title", "Title");
            dgvBoooks.Columns.Add("Authors", "Authors");
            dgvBoooks.Columns.Add("Publisher", "Publisher");
            dgvBoooks.Columns.Add("PublishedDate", "PublishedDate");
            dgvBoooks.Columns.Add("Description", "Description");

            dgvShelf.Columns.Add("No.", "No.");
            dgvShelf.Columns.Add("ID", "ID");
            dgvShelf.Columns.Add("Bookself", "Bookself's name");

            //fix size
            dgvBoooks.Columns[0].Width = 45;
            dgvBoooks.Columns[1].Width = 160;
            dgvBoooks.Columns[2].Width = 270;
            dgvBoooks.Columns[3].Width = 270;
            dgvBoooks.Columns[4].Width = 150;
            dgvBoooks.Columns[5].Width = 120;
            dgvBoooks.Columns[6].Width = 120;

            dgvShelf.Columns[0].Width = 45;
            dgvShelf.Columns[1].Width = 80;
            dgvShelf.Columns[2].Width = 270;
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

                string message = "SEARCH_BOOK" + txtSearch.Text.Trim() + "|";
                byte[] data = Encoding.UTF8.GetBytes(message);
                await stream.WriteAsync(data, 0, data.Length);

                byte[] bytes = new byte[4096];
                int bytesread = await stream.ReadAsync(bytes, 0, bytes.Length);
                var response = Encoding.UTF8.GetString(bytes, 0, bytesread);
                //                dgvBoooks.Rows.Add(response);

                var books = JsonConvert.DeserializeObject<List<Book>>(response);

                // MessageBox.Show(books[1].ToString());
                progressBar.Visible = true;
                progressBar.Minimum = 0;
                if (books != null)
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
                if (books != null && books.Count != 0)
                {
                    foreach (var book in books)
                    {
                        try
                        {
                            progressBar.Value++;
                            string id = book.ID;
                            string authors = book.Authors != null ? string.Join(", ", book.Authors) : "No authors";
                            string publisher = book.Publisher ?? "Unknown";
                            string publishedDate = book.PublishedDate ?? "Unknown";
                            string description = book.Description ?? "None";

                            dgvBoooks.Rows.Add(
                                num++,
                                id,
                                book.Title ?? "No Title",
                                authors,
                                publisher,
                                publishedDate,
                                description
                            );
                        }
                        catch 
                        {
                            continue;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm tháy sách nào!");
                }
                progressBar.Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu sách: " + ex.Message + "\n\n>>>Hãy thử với một tựa đề khác");
            }
        }

        private async void btnLoadBookshelf_Click(object sender, EventArgs e)
        {
            dgvShelf.Rows.Clear();
            try
            {
                TcpClient tcpClient = new TcpClient("127.0.0.1", 8080);
                NetworkStream stream = tcpClient.GetStream();

                string message = "SEARCHSHELF";
                byte[] data = Encoding.UTF8.GetBytes(message);
                await stream.WriteAsync(data, 0, data.Length);

                byte[] bytes = new byte[4096];
                int bytesread = await stream.ReadAsync(bytes, 0, bytes.Length);
                var response = Encoding.UTF8.GetString(bytes, 0, bytesread);

                List<Shelf> shelves = JsonConvert.DeserializeObject<List<Shelf>>(response);

                progressBar.Visible = true;
                progressBar.Minimum = 0;
                if (shelves != null)
                {
                    progressBar.Maximum = shelves.Count;
                    progressBar.Value = 0;
                }
                else
                {
                    progressBar.Maximum = 1;
                    progressBar.Value = 0;
                }

                int num = 1;
                if (shelves != null && shelves.Count > 0)
                {
                    foreach (var shelf in shelves)
                    {
                        progressBar.Value++;

                        dgvShelf.Rows.Add(
                            num++,
                            shelf.ID,
                            shelf.Title
                        );
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy kệ nào của UID này");
                }
                progressBar.Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ danh sách kệ: " + ex.Message + "\n\n>>>Hãy thử với một UID khác");
            }
        }

        private async void dgvShelf_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvBoooks.Rows.Clear();
            try
            {
                TcpClient tcpClient = new TcpClient("127.0.0.1", 8080);
                NetworkStream stream = tcpClient.GetStream();

                string message = "GETBOOK" + dgvShelf.Rows[e.RowIndex].Cells["ID"].Value.ToString() + "|";
                //MessageBox.Show(message);
                byte[] data = Encoding.UTF8.GetBytes(message);
                await stream.WriteAsync(data, 0, data.Length);

                byte[] bytes = new byte[4096];
                int bytesread = await stream.ReadAsync(bytes, 0, bytes.Length);
                var response = Encoding.UTF8.GetString(bytes, 0, bytesread);

                List<Book> books = JsonConvert.DeserializeObject<List<Book>>(response);

                progressBar.Visible = true;
                progressBar.Minimum = 0;
                if (books != null)
                {
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
                }

                int num = 1;
                if (books != null && books.Count > 0)
                {
                    foreach (var book in books)
                    {
                        progressBar.Value++;
                        string id = book.ID;
                        string authors = book.Authors != null ? string.Join(", ", book.Authors) : "No authors";
                        string publisher = book.Publisher ?? "Unknown";
                        string publishedDate = book.PublishedDate ?? "Unknown";
                        string description = book.Description ?? "None";

                        dgvBoooks.Rows.Add(
                            num++,
                            id,
                            book.Title ?? "No Title",
                            authors,
                            publisher,
                            publishedDate,
                            description
                        );
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm tháy sách nào!");
                }
                progressBar.Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu sách: " + ex.Message + "\n\n>>>Hãy thử với một kệ sách khác");
            }
        }

        private void dgvBoooks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string volumeId = dgvBoooks.Rows[e.RowIndex].Cells["ID"].Value.ToString().Trim();
            BookDetailsPage bookDetailsPage = new BookDetailsPage(volumeId);
            bookDetailsPage.ShowDialog();
        }

        private void dgvBoooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
                selectedIndexBook = e.RowIndex;
        }

        private void dgvShelf_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
                selectedIndexBookShelf = e.RowIndex;
        }
        private async void btnAddBook_Click(object sender, EventArgs e)
        {
            if (selectedIndexBook == -1 || selectedIndexBookShelf == -1) return;
            try
            {
                TcpClient tcpClient = new TcpClient("127.0.0.1", 8080);
                NetworkStream stream = tcpClient.GetStream();

                string message = "ADDBOOK" + dgvShelf.Rows[selectedIndexBookShelf].Cells["ID"].Value.ToString() + "|" + dgvBoooks.Rows[selectedIndexBook].Cells["ID"].Value.ToString() + "|";
                byte[] data = Encoding.UTF8.GetBytes(message);
                await stream.WriteAsync(data, 0, data.Length);

                byte[] bytes = new byte[4096];
                int bytesread = await stream.ReadAsync(bytes, 0, bytes.Length);
                var response = Encoding.UTF8.GetString(bytes, 0, bytesread);

                progressBar.Visible = true;
                progressBar.Minimum = 0;
                progressBar.Maximum = 1;
                if (response == "SUCCESS")
                {
                    progressBar.Value = 1;
                    MessageBox.Show("Thêm sách thành công!");
                }
                else
                {
                    MessageBox.Show("Thêm sách thất bại!");
                }
                progressBar.Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu sách: " + ex.Message + "\n\n>>>Hãy thử lại");
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedIndexBook == -1 || selectedIndexBookShelf == -1) return;
            try
            {
                TcpClient tcpClient = new TcpClient("127.0.0.1", 8080);
                NetworkStream stream = tcpClient.GetStream();

                string message = "REMOVEBOOK" + dgvShelf.Rows[selectedIndexBookShelf].Cells["ID"].Value.ToString() + "|" + dgvBoooks.Rows[selectedIndexBook].Cells["ID"].Value.ToString() + "|";
                byte[] data = Encoding.UTF8.GetBytes(message);
                await stream.WriteAsync(data, 0, data.Length);

                byte[] bytes = new byte[4096];
                int bytesread = await stream.ReadAsync(bytes, 0, bytes.Length);
                var response = Encoding.UTF8.GetString(bytes, 0, bytesread);

                progressBar.Visible = true;
                progressBar.Minimum = 0;
                progressBar.Maximum = 1;
                if (response.StartsWith("SUCCESS"))
                {
                    //MessageBox.Show(response);
                    progressBar.Value = 1;
                    MessageBox.Show("Xóa sách thành công! Vui lòng tải lại kệ sách!");
                    //dgvBoooks.Rows.RemoveAt(selectedIndexBook);
                }
                else
                {
                    MessageBox.Show("Xóa sách thất bại!");
                }
                progressBar.Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu sách: " + ex.Message + "\n\n>>>Hãy thử lại");
            }
        }


    }
}
