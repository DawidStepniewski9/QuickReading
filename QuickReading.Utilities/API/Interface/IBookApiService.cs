using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReading.Utilities.API.Interface
{
    public interface IBookApiService
    {
        public Task<string> GetText(string url);
    }
}
