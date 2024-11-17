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
using Newtonsoft.Json;
using static Google.Apis.Requests.BatchRequest;

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
            string apiUrl = $"https://www.googleapis.com/books/v1/volumes/{volumeId}";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResult = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(jsonResult); //để kiểm tra
                    dynamic bookDetails = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonResult);

                    if (bookDetails != null && bookDetails.volumeInfo != null)
                    {
                        if (bookDetails.volumeInfo.imageLinks != null && bookDetails.volumeInfo.imageLinks.thumbnail != null)
                        {
                            string imageUrl = bookDetails.volumeInfo.imageLinks.thumbnail;
                            picBookcover.Load(imageUrl);
                        }

                        rtbBookDetails.Text = $"Title: {bookDetails.volumeInfo.title ?? "N/A"}\n" +
                                              $"Authors: {string.Join(", ", bookDetails.volumeInfo.authors ?? new string[] { "N/A" })}\n" +
                                              $"Publisher: {bookDetails.volumeInfo.publisher ?? "Unknown"}\n" +
                                              $"Published Date: {bookDetails.volumeInfo.publishedDate ?? "Unknown"}";

                    }
                    else
                    {
                        MessageBox.Show("No details found for this book.");
                    }
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error loading book details. Status Code: {response.StatusCode}. Error: {errorMessage}");
                    return;
                }
            }

        }
    }
}
