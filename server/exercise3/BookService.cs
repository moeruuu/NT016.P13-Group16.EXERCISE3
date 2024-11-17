﻿using Microsoft.AspNetCore.DataProtection.KeyManagement;
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
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using Google.Apis.Auth.OAuth2.Responses;

namespace exercise3
{
    public class BookService
    {
       
        private static readonly string clientid = "733627747078-guf0vb5qrui6f0dkfnit0n7tvtf0fahg.apps.googleusercontent.com";
        private static readonly string clientsecret = "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";

        private static readonly string baseurl = @"https://www.googleapis.com/books/v1";

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
                    return accessToken;
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
                return null;
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
            return null;
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
                MessageBox.Show(ex.Message);
                return null;
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
        }

        public class BooksResponse
        {
            public BookItem[] items { get; set; }
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
        }

        public class Shelf
        {
            public string ID { get; set; }
            public string Title { get; set; }
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
            string apiUrl = $"https://www.googleapis.com/books/v1/volumes?q={search}";
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
                    var response = await client.GetStringAsync(apiUrl);
                    var booksResponse = JsonConvert.DeserializeObject<BooksResponse>(response);

                    List<Book> books = new List<Book>();

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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                MessageBox.Show(ex.Message);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

        }
    }
}