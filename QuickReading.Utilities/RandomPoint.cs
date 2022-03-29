using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReading.Utilities
{
    public static class RandomGenerator
    {
        public static RandomPoint GetRandomPoint(int tableSize)
        {
            Random random = new Random();
            int x = random.Next(0, tableSize - 1);
            int y = random.Next(0, tableSize - 1);

            return new RandomPoint(x, y);
        }
    }

    public class RandomPoint
    {
        public int x { get; set; }
        public int y { get; set; }

        public RandomPoint() { }

        public RandomPoint(int _x,int _y)
        {
            x = _x;
            y = _y;
        }
    }
}
