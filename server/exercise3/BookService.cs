using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Google.Apis.Auth.OAuth2;
using static System.Formats.Asn1.AsnWriter;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Util.Store;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using Google.Apis.Auth.OAuth2.Responses;
using System.Net;
using Newtonsoft.Json.Linq;

namespace exercise3
{
    public class BookService
    {

        private static readonly string clientid = "733627747078-guf0vb5qrui6f0dkfnit0n7tvtf0fahg.apps.googleusercontent.com";
        private static readonly string clientsecret = "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";

        public string accessToken;

        public async Task<string> GetAccessToken()
        {
            try
            {
                if (!string.IsNullOrEmpty(accessToken))
                {
                    return accessToken;
                }
                var storedRefreshToken = RetrieveStoredRefreshToken();
                if (!string.IsNullOrEmpty(storedRefreshToken))
                {
                    accessToken = await RefreshAccessToken(storedRefreshToken);
                    using (HttpClient client = new HttpClient())
                    {
                        string url = $"https://www.googleapis.com/oauth2/v1/tokeninfo?access_token={accessToken}";
                        HttpResponseMessage response = await client.GetAsync(url);

                        if (response.IsSuccessStatusCode)
                            return accessToken;
                    }
                }
                var clientsecrets = new ClientSecrets
                {
                    ClientId = clientid,
                    ClientSecret = clientsecret,
                };

                var flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
                {
                    ClientSecrets = clientsecrets,
                    Scopes = new[] { "https://www.googleapis.com/auth/books" }
                });

                var credential = await new AuthorizationCodeInstalledApp(flow, new LocalServerCodeReceiver()).AuthorizeAsync("user", CancellationToken.None);
                StoreRefreshToken(credential.Token.RefreshToken);
                accessToken = credential.Token.AccessToken;
                return accessToken;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return string.Empty;
            }
        }

        private void StoreRefreshToken(string refreshToken)
        {
            try
            {
                File.WriteAllText("refresh_token.txt", refreshToken);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string RetrieveStoredRefreshToken()
        {
            try
            {
                if (File.Exists("refresh_token.txt"))
                {
                    return File.ReadAllText("refresh_token.txt");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return string.Empty;
        }

        private async Task<string> RefreshAccessToken(string refreshToken)
        {
            try
            {
                var clientsecrets = new ClientSecrets
                {
                    ClientId = clientid,
                    ClientSecret = clientsecret,
                };

                var flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
                {
                    ClientSecrets = clientsecrets,
                    Scopes = new[] { "https://www.googleapis.com/auth/books" },
                });

                var credential = new UserCredential(flow, "user", new TokenResponse
                {
                    RefreshToken = refreshToken
                });

                await credential.RefreshTokenAsync(CancellationToken.None);
                accessToken = credential.Token.AccessToken;
                return accessToken;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }


        public class Book
        {
            public string ID { get; set; }
            public string Title { get; set; }
            public List<string> Authors { get; set; }
            public string Publisher { get; set; }
            public string PublishedDate { get; set; }
            public string Description { get; set; }
            
            [JsonProperty("imageLinks")]
            public ImageLinks ImageLinks { get; set; }
        }

        public class BooksResponse
        {
            public string kind { get; set; }
            public BookItem[] items { get; set; }
            public int totalItems { get; set; }
        }

        public class BookItem
        {
            public string id { get; set; }
            public VolumeInfo volumeInfo { get; set; }
        }

        public class VolumeInfo
        {
            public string title { get; set; }
            public List<string> authors { get; set; }
            public string publisher { get; set; }
            public string publishedDate { get; set; }
            public string description { get; set; }
            public ImageLinks imageLinks { get; set; }
        }


        public class Shelf
        {
            public string ID { get; set; }
            public string Title { get; set; }
        }
        public class ImageLinks
        {
            [JsonProperty("thumbnail")]
            public string thumbnail { get; set; }
        }
        public class ShelvesResponse
        {
            public ShelfItem[] items { get; set; }
        }

        public class ShelfItem
        {
            public string id { get; set; }
            public string title { get; set; }
        }

        /* public string GetAuthorize()
         {
             *//*return $"https://accounts.google.com/o/oauth2/v2/auth?" +
                $"scope=email&" +
                $"response_type=code&" +
                $"redirect_uri={uri}&" +
                $"client_id={clientid}";*//*

             //string redirectUri = "urn:ietf:wg:oauth:2.0:oob";
             string redirectUri = "http://localhost:8080/";
             *//*string oauth = string.Format("https://accounts.google.com/o/oauth2/auth?client_id={0}&redirect_uri={1}&scope={2}&response_type=code", clientid, redirectUri, scopes);
             return oauth;*//*

             return $"https://accounts.google.com/o/oauth2/v2/auth?" +
            $"client_id={clientid}&" +
            $"redirect_uri={Uri.EscapeDataString(redirectUri)}&" +
            $"response_type=code&" +
            $"scope={Uri.EscapeDataString(scopes)}";
         }*/

        public async Task<List<Book>> SearchBooks(string search)
        {
            //MessageBox.Show(clientid);
            string searchQuery = Uri.EscapeDataString(search);
            string apiUrlTitle = $"https://www.googleapis.com/books/v1/volumes?q=intitle:{searchQuery}";
            string apiUrl = $"https://www.googleapis.com/books/v1/volumes?q={searchQuery}";

            try
            {
                using (var client = new HttpClient())
                {
                    /*   if (string.IsNullOrEmpty(accesstoken))
                       {
                           MessageBox.Show("Access token is null or empty. Authorization failed.");
                           return null;
                       }*/
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                    List<Book> books = new List<Book>();

                    //sách có từ khóa trong tựa đề
                    var responseTitle = await client.GetStringAsync(apiUrlTitle);
                    var booksResponseTitle = JsonConvert.DeserializeObject<BooksResponse>(responseTitle);

                    if (booksResponseTitle.items.Length > 0)
                    {
                        for (int i = 0; i < booksResponseTitle.items.Length; i++)
                        {
                            var item = booksResponseTitle.items[i];
                            books.Add(new Book
                            {
                                ID = item.id,
                                Title = item.volumeInfo?.title,
                                Authors = item.volumeInfo?.authors ?? new List<string> { "No authors" },
                                Publisher = item.volumeInfo?.publisher ?? "Unknown",
                                PublishedDate = item.volumeInfo?.publishedDate ?? "Unknown",
                                Description = !string.IsNullOrEmpty(item.volumeInfo?.description) ? "Have details" : "None",
                            });
                        }
                    }

                    //sách có từ khóa trong nội dung
                    var response = await client.GetStringAsync(apiUrl);
                    var booksResponse = JsonConvert.DeserializeObject<BooksResponse>(response);

                    if (booksResponse.items.Length > 0)
                    {
                        for (int i = 0; i < booksResponse.items.Length; i++)
                        {
                            var item = booksResponse.items[i];
                            books.Add(new Book
                            {
                                ID = item.id,
                                Title = item.volumeInfo?.title,
                                Authors = item.volumeInfo?.authors ?? new List<string> { "No authors" },
                                Publisher = item.volumeInfo?.publisher ?? "Unknown",
                                PublishedDate = item.volumeInfo?.publishedDate ?? "Unknown",
                                Description = !string.IsNullOrEmpty(item.volumeInfo?.description) ? "Have details" : "None",
                            });
                        }
                    }

                    return books;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<List<Shelf>> SearchShelves()
        {
            string apiUrl = $"https://www.googleapis.com/books/v1/mylibrary/bookshelves";
            try
            {
                using (var client = new HttpClient())
                {
                    //MessageBox.Show(apiUrl);
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
                    var response = await client.GetStringAsync(apiUrl);
                    var shelvesResponse = JsonConvert.DeserializeObject<ShelvesResponse>(response);

                    List<Shelf> shelves = new List<Shelf>();

                    foreach (var item in shelvesResponse.items)
                    {
                        shelves.Add(new Shelf
                        {
                            ID = item.id,
                            Title = item.title
                        });
                    }

                    return shelves;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<List<Book>> GetBooks(string idShelf)
        {
            string apiUrl = $@"https://www.googleapis.com/books/v1/mylibrary/bookshelves/{idShelf}/volumes";
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
                    var response = await client.GetStringAsync(apiUrl);
                    var booksResponse = JsonConvert.DeserializeObject<BooksResponse>(response);

                    List<Book> books = new List<Book>();

                    if (booksResponse.items.Count() > 0)
                    {
                        foreach (var item in booksResponse.items)
                        {
                            books.Add(new Book
                            {
                                ID = item.id,
                                Title = item.volumeInfo.title,
                                Authors = item.volumeInfo.authors,
                                Publisher = item.volumeInfo.publisher,
                                PublishedDate = item.volumeInfo.publishedDate,
                                Description = item.volumeInfo.description
                            });
                        }

                        return books;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<string> AddBooks(string idShelf, string idBook)
        {
            string apiUrl = $@"https://www.googleapis.com/books/v1/mylibrary/bookshelves/{idShelf}/addVolume?volumeId={idBook}";
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
                    var response = await client.PostAsync(apiUrl, null);

                    if (response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.OK)
                    {
                        return "SUCCESS";
                    }
                    return "FAILED";
                }
            }
            catch (Exception ex)
            {
                return "FAILED";
            }
        }

        public async Task<string> RemoveBooks(string idShelf, string idBook)
        {
            string apiUrl = $@"https://www.googleapis.com/books/v1/mylibrary/bookshelves/{idShelf}/removeVolume?volumeId={idBook}";
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
                    var response = await client.PostAsync(apiUrl, null);

                    if (response.IsSuccessStatusCode)
                    {
                        
                        return "SUCCESS";
                    }
                    return "FAILED";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<Book> GetBookDetails(string volumeId)
        {
            string apiUrl = $@"https://www.googleapis.com/books/v1/volumes/{volumeId}";

            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                    var response = await client.GetStringAsync(apiUrl);
                    var bookResponse = JsonConvert.DeserializeObject<BookItem>(response);
                    var volumeInfo = bookResponse?.volumeInfo;

                    if (volumeInfo != null)
                    {
                        var bookDetails = new Book
                        {
                            ID = bookResponse.id,
                            Title = volumeInfo?.title,
                            Authors = volumeInfo?.authors ?? new List<string> { "No authors" },
                            Publisher = volumeInfo?.publisher ?? "Unknown",
                            PublishedDate = volumeInfo?.publishedDate ?? "Unknown",
                            Description = volumeInfo?.description ?? "None",
                            ImageLinks = volumeInfo?.imageLinks
                        };

                        return bookDetails;
                    }

                    return null;  
                }
            }
            catch (Exception ex)
            {
  
                return null;
            }
        }

    }
}