using QuickReading.Utilities.API.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace QuickReading.Utilities.API
{
    public class BookApiService : IBookApiService
    {
        private readonly HttpClient _httpClient;
        public BookApiService(
            HttpClient httpClient)
        {
            _httpClient = httpClient;
            
        }

        public async Task<string> GetText(string url)
        {
            string resultText = "";
            string urlToTxt = await GetBook(url);

            resultText = (new WebClient()).DownloadString(urlToTxt);

            return resultText;
        }

        public async Task<string> GetBook(string url)
        {
            _httpClient.BaseAddress = new Uri(url);
            var getBook = await _httpClient.GetAsync($"");

            if (!getBook.IsSuccessStatusCode && getBook.StatusCode != System.Net.HttpStatusCode.NotFound)
            {
                return "";
            }

            string getBookResults = await getBook.Content.ReadAsStringAsync();
            string result = JsonConvert.DeserializeObject<BookDetailModel>(getBookResults).TxtUrl;

            return result;
        }
    }


    public class BookDetailModel
    {
        [JsonProperty("txt")]
        public string TxtUrl { get; set; }
    }
}
