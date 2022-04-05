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
        private readonly string UrlWordsApi = "https://random-word-api.herokuapp.com";
        public WordsApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(UrlWordsApi);
        }

        public async Task<string> GetWord()
        {
            var getWord = await _httpClient.GetAsync($"word?number=1");

            if(!getWord.IsSuccessStatusCode && getWord.StatusCode != System.Net.HttpStatusCode.NotFound)
            {
                return "";
            }

            string getWordsResults = await getWord.Content.ReadAsStringAsync();
            string result = JsonConvert.DeserializeObject<List<string>>(getWordsResults).FirstOrDefault();

            return result;

        }

        public async Task<List<string>> GetWords(int number)
        {
            var getWord = await _httpClient.GetAsync($"word?number={number}");

            if (!getWord.IsSuccessStatusCode && getWord.StatusCode != System.Net.HttpStatusCode.NotFound)
            {
                return new List<string>();
            }

            string getWordsResults = await getWord.Content.ReadAsStringAsync();
            List<string> result = JsonConvert.DeserializeObject<List<string>>(getWordsResults);

            return result;
        }
    }
}
