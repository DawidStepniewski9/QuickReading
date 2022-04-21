using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReading.Models.Models.Games.MakeWord
{
    public class MakeWordList
    {
        public List<MakeWordItemModel> list { get; set; }
        public string AnswerWord { get; set; }
        
        public MakeWordList()
        {
            list = new List<MakeWordItemModel>();
        }
    }
}
