using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReading.Models.Models.Games.MakeWord
{
    public class MakeWordItemModel
    {
        public string Word { get; set; }
        public bool Answer { get; set; }

        public MakeWordItemModel(string _word, bool _answer)
        {
            Word = _word;
            Answer = _answer;
        }
    }
}
