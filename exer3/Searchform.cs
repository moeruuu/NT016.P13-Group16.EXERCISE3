using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static exer3.BookService;

namespace exer3
{
    public partial class Searchform : Form
    {
        private readonly user users;
        private readonly BookService bookService;
        public Searchform(user userinfo, BookService book)
        {
            InitializeComponent();
            users = userinfo;
            WelcomeText();
            bookService = book;
            CreateDataGridView();
        }

        private void WelcomeText()
        {
            MessageBox.Show(users.fullname);
            labelName.Text += users.fullname;
        }

        private void CreateDataGridView()
        {
            dgvBoooks.Columns.Clear();
            dgvBoooks.Columns.Add("Title", "Title");
            dgvBoooks.Columns.Add("Authors", "Authors");
            dgvBoooks.Columns.Add("Publisher", "Publisher");
            dgvBoooks.Columns.Add("Description", "Description");
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string ListtoString(List<string> motlist)
        {
            return motlist != null ? string.Join(", ", motlist) : "Unknow";
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                MessageBox.Show("Vui lòng nhập tên tìm kiếm!");
                return;
            }
            try
            {
                var books = await bookService.SearchBooks(txtSearch.Text);
                if (books != null && books.Any())
                {
                    //var bindingList = new BindingList<Book>(books);
                    foreach (var book in books)
                    {
                        dgvBoooks.Rows.Add(book.Title, ListtoString(book.Authors), book.Publisher, book.Description);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sách nào!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
