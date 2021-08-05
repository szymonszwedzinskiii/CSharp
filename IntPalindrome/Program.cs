using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace powtorzenie
{
    public class Solution
    {
        public static bool IsPalindrome(int x)
        {
            int rem;
            long reverseTemp = 0;
            int temp = x;
            while (x != 0)
            {
                rem = x % 10;
                reverseTemp = reverseTemp * 10 + rem;
                x = x / 10;
                rem = 0;

            }
            if (reverseTemp < Math.Pow(-2, 31) || reverseTemp > (Math.Pow(2, 31) - 1))
            {
                return false;
            }

            else
            {
                if (temp < 0)
                    return false;
                if (temp == Convert.ToInt32(reverseTemp))
                    return true;

                else
                    return false;
            }

        }

    }

    class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine(Solution.IsPalindrome(12321));




        }
    }
}
