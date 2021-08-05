using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace powtorzenie
{
    public class Solution
    {
        public static int Reverse(int x)
        {
            int rem;
            long reverseTemp = 0;
            while (x != 0)
            {
                rem = x % 10;
                reverseTemp = reverseTemp * 10 + rem;
                x = x / 10;
                rem = 0;

            }
            if (reverseTemp < Math.Pow(-2, 31) || reverseTemp > (Math.Pow(2, 31) - 1))
            {
                return 0;
            }

                return Convert.ToInt32(reverseTemp);

        }

    }

    class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine(Solution.Reverse(1534236469));




        }
    }
}
