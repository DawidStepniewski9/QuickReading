using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReading.Models.Models.Games.MakeWord
{
    public class MakeWordModel
    {
        public string Word { get; set; }
        public string Translation { get; set; }
        public int NumberOfWords { get; set; }
        public List<MakeWordList> GroupsOfWords { get; set; }
    }
}
