using System;
using System.Collections.Generic;
using System.Text;

namespace CodeWars
{
    public class DigPow
    {
        public static long digPow(int n, int p)
        {
            // Caculate the total
            var powered = 0;
            var digits = n.ToString();
            for (var i = 0; i < digits.Length; i++)
            {
                powered += (int)Math.Pow(digits[i] - 48, p + i);
            }

            var k = Math.DivRem(powered, n, out int remainder);

            if (remainder == 0)
            {
                return k;
            }

            return -1;
        }
    }
}
