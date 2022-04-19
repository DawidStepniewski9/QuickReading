using Newtonsoft.Json;
using QuickReading.Utilities.API.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QuickReading.Utilities.API
{
    public class WordsApiService : IWordsApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string UrlWordsApi = "https://words-aas.vercel.app/api/";
        public WordsApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(UrlWordsApi);
        }

        public async Task<string> GetWord()
        {
            var getWord = await _httpClient.GetAsync($"$bodyPart");

            if(!getWord.IsSuccessStatusCode && getWord.StatusCode != System.Net.HttpStatusCode.NotFound)
            {
                return "";
            }

            string getWordsResults = await getWord.Content.ReadAsStringAsync();
            string result = JsonConvert.DeserializeObject<ReturnEnglishWordModel>(getWordsResults).phrase;

            return result;

        }

    }

    public class ReturnEnglishWordModel
    {
        public string phrase { get; set; }
    }
}
