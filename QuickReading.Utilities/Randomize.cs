using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReading.Utilities
{
    public static class Randomize
    {
        private static Random random = new Random();
        public static string Word(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZĄŻŹĘÓŃŁŚĆ";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
