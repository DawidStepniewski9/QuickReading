using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReading.Utilities.API.Interface
{
    public interface IWordsApiService
    {
        public Task<string> GetWord();
        public Task<List<string>> GetWords(int number);
    }
}
