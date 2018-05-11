using System;

namespace CodeWars
{
    public class AreTheySame
    {
        public static bool comp(int[] a, int[] b)
        {
            // First some guards against faulty input.
            if (a == null || b == null)
            {
                return false;
            }
            else if (a.Length == 0 && b.Length == 0)
            {
                return true;
            }
            else if (a.Length == 0 || b.Length == 0 || a.Length != b.Length)
            {
                return false;
            }
            else
            {
                // Prepare both arrays for easy comparison.
                Algorithms.Sort(a);
                Algorithms.Sort(b);

                for (var i = 0; i < a.Length; i++)
                {
                    var root = a[i];
                    // a squared should be the same as b.
                    if (root * root != b[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}