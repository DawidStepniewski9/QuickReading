using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReading.Models.Models.Games.GuessLetter
{
    public class GuessLetterModel
    {
        public char Letter { get; set; }
        public string[,] ArrayLetter { get; set; }

        public int ArraySize { get; set; }
        public int CountSearchLetter { get; set; }
    }
}
