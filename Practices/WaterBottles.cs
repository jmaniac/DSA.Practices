using System;
using System.Collections.Generic;
using System.Text;

namespace Practices.Problems
{
    internal class WaterBottles
    {
        public int NumWaterBottles(int numBottles, int numExchange)
        {
            int drank = numBottles, bottles = numBottles;

            while(bottles >= numExchange)
            {
                int exchangable = bottles / numExchange, remaining = bottles % numExchange;
                bottles = exchangable + remaining;
                drank += exchangable;
            }
            return drank;
        }
    }
}
