using QuickReading.Utilities.API.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using Newtonsoft.Json;

namespace QuickReading.Utilities.API
{
    public class TranslateService : ITranslateService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private string UserName => _configuration["Translator:userName"];
        private string Password => _configuration["Translator:passWord"];
        private string Url => _configuration["Translator:url"];
        private string _key;

        public TranslateService(IConfiguration configuration,
            HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(Url);
        }

        public async Task<string> GetKey()
        {
            if (String.IsNullOrEmpty(_key))
            {
                var getKey = await _httpClient.GetAsync($"keygen?user={UserName}&pass={Password}");

                if (!getKey.IsSuccessStatusCode && getKey.StatusCode != System.Net.HttpStatusCode.NotFound)
                {
                    return "";
                }

                string getWordsResults = await getKey.Content.ReadAsStringAsync();
                string result = JsonConvert.DeserializeObject<ResponseKeyModel>(getWordsResults).Key;

                return result;
            }

            return _key;
        }
        public async Task<string> GetTranslation(string word)
        {
            var getKey = await _httpClient.GetAsync($"get?q={word}&langpair=en|pl&key={await GetKey()}");

            if (!getKey.IsSuccessStatusCode && getKey.StatusCode != System.Net.HttpStatusCode.NotFound)
            {
                return "";
            }

            string getWordsResults = await getKey.Content.ReadAsStringAsync();
            var translateResult = JsonConvert.DeserializeObject<TranslateResponseModel>(getWordsResults);

            string result = translateResult.responseData.translatedText;//translateResult.matches.Where(m => m.match == 1).FirstOrDefault().translation;

            return result;
        }
    }

    public class ResponseKeyModel
    {
        [JsonProperty("key")]
        public string Key {get;set;}
    }
}
