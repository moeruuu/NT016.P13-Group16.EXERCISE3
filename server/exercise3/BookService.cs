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
using DotNetEnv;

namespace exercise3
{
    public class BookService
    {
        private static readonly string clientid = "733627747078-guf0vb5qrui6f0dkfnit0n7tvtf0fahg.apps.googleusercontent.com";
        private static readonly string clientsecret = "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";
        private static readonly string baseurl = @"https://www.googleapis.com/books/v1";


        private async Task<string> GetAccessToken()
        {
            try
            {
                /*if (string.IsNullOrEmpty(clientid) || string.IsNullOrEmpty(clientsecret))
                {
                    MessageBox.Show("Vui lòng cài đặt client id hoặc secret");
                }*/
                var clientsecrets = new ClientSecrets
                {
                    ClientId = clientid,
                    ClientSecret = clientsecret,
                };

                //MessageBox.Show(clientid + '\n' + clientsecret);
                var flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
                {
                    ClientSecrets = clientsecrets,
                    Scopes = new[] { "https://www.googleapis.com/auth/books" },
                    //DataStore = new FileDataStore("Google.Apis.Auth")
                });

                var credential = await new AuthorizationCodeInstalledApp(flow, new LocalServerCodeReceiver()).AuthorizeAsync("user", CancellationToken.None);
                return credential.Token.AccessToken;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
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
            try
            {
                DotNetEnv.Env.Load();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            string apiUrl = $"https://www.googleapis.com/books/v1/volumes?q={search}";
            try
            {
            using (var client = new HttpClient())
            {
                string accesstoken = await GetAccessToken();
                 /*   if (string.IsNullOrEmpty(accesstoken))
                    {
                        MessageBox.Show("Access token is null or empty. Authorization failed.");
                        return null;
                    }*/
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accesstoken);
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

        }
    }
}