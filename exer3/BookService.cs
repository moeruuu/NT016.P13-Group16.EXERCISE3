using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace exer3
{
    public class BookService
    {
        private static readonly string key = "AIzaSyCPAuwYbqhorOST7_wm4ZKTgQh5rF8nQ4Y";

        public class Book
        {
            public string ID { get; set; }
            public string Etag { get; set; }
            public string Title { get; set; }
            public List<string> Authors { get; set; }
            public string Publisher { get; set; }
            public string PublishedDate { get; set; }
        }

        public class BooksResponse
        {
            public BookItem[] items { get; set; }
        }

        public class BookItem
        {
            public VolumeInfo volumeInfo { get; set; }
        }

        public class VolumeInfo
        {
            public string id { get; set; }
            public string etag { get; set; }
            public string title { get; set; }
            public List<string> authors { get; set; }
            public string publisher { get; set; }
            public string publishedDate { get; set; }
        }

        public async Task<List<Book>> SearchBooks(string search)
        {
            string apiUrl = $"https://www.googleapis.com/books/v1/volumes?q={search}&key={key}";

            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync(apiUrl);
                var booksResponse = JsonConvert.DeserializeObject<BooksResponse>(response);

                List<Book> books = new List<Book>();

                foreach (var item in booksResponse.items)
                {
                    books.Add(new Book
                    {
                        ID = item.volumeInfo.id,
                        Etag = item.volumeInfo.etag,
                        Title = item.volumeInfo.title,
                        Authors = item.volumeInfo.authors,
                        Publisher = item.volumeInfo.publisher,
                        PublishedDate = item.volumeInfo.publishedDate
                    });
                }

                return books;
            }

        }
    }
}