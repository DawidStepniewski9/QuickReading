using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReading.Models.Models.Games.FindLetter
{
    public class FindLetterModel
    {
        public char Letter { get; set; }
        public char[,] ArrayLetter { get; set; }

        public int ArraySize { get; set; }
    }
}
