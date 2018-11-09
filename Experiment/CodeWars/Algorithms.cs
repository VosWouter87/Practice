using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CodeWars
{
    public class Algorithms
    {
        public static void Sort(int[] numbers)
        {
            QuickSort(numbers, 0, numbers.Length - 1);
        }

        public static void Sort<T>(T[] items, IComparable<T> compare)
        {

        }

        public static void QuickSort(int[] numbers, int initLeft, int initRight)
        {
            // If left and right are close, use BubbleSort instead.
            if ((initRight - initLeft) < 4)
            {
                BubbleSort(numbers, initLeft, initRight);
                return;
            }

            var left = initLeft;
            var right = initRight;
            var pivot = numbers[(left + right) / 2];

            do
            {
                // Pivot around the centre.
                while (numbers[left] < pivot)
                {
                    left++;
                }

                while (pivot < numbers[right])
                {
                    right--;
                }

                if (left < right)
                {
                    Swap(numbers, left, right);
                    left++;
                    right--;
                }
            } while (left < right);

            if (initLeft < right)
            {
                QuickSort(numbers, initLeft, right);
            }
            if (left < initRight)
            {
                QuickSort(numbers, left, initRight);
            }
        }

        public static void BubbleSort(int[] numbers, int left, int right)
        {
            if (right >= numbers.Length)
            {
                right = numbers.Length - 1;
            }

            var swapped = false;
            do
            {
                swapped = false;
                for (var i = left + 1; i <= right; i++)
                {
                    var previousIndex = i - 1;
                    if (numbers[previousIndex] > numbers[i])
                    {
                        Swap(numbers, previousIndex, i);
                        swapped = true;

                        var beforeIndex = i - 2;
                        if (beforeIndex >= 0 && numbers[beforeIndex] > numbers[previousIndex])
                        {
                            Swap(numbers, beforeIndex, previousIndex);
                        }
                    }
                }
            } while (swapped);
        }

        public static void Swap(int[] numbers, int a, int b)
        {
            var temp = numbers[a];
            numbers[a] = numbers[b];
            numbers[b] = temp;
        }

        public static List<int> GetPrimeFactors(int number)
        {
            var factors = new List<int>();

            if (number < 0)
            {
                return factors;
            }

            if (number == 1 || number == 5 || number == 7)
            {
                factors.Add(number);
                return factors;
            }

            var sqrt = Math.Sqrt(number);
            var sumOfDigits = SumOfDigits(number);
            
            while ((number & 1) == 0)
            {
                factors.Add(2);
            }

            // There is a special case with 3 and 9, where the number can be divided by 3 or 9 when the total of it's digits can be divided by 3 or 9.
            while (sumOfDigits % 3 == 0)
            {
                factors.Add(3);
                number /= 3;
                sumOfDigits = SumOfDigits(number);
            }

            while (number % 5 == 0)
            {
                number /= 5;
                factors.Add(5);
            }

            while (number % 7 == 0)
            {
                number /= 7;
                factors.Add(7);
            }

            sumOfDigits = SumOfDigits(number);
            while (sumOfDigits % 9 == 0)
            {
                factors.Add(9);
            }
            
            for (var i = 11; i < sqrt; i += 6)
            {
                if (number % i == 0)
                {
                    number /= i;
                    factors.Add(number);
                }
            }

            return factors;
        }

        public static bool IsPrime(int number)
        {
            if (number < 1)
            {
                return false;
            }
            
            if (number == 1 || number == 5 || number == 7 || (number & 1) == 0)
            {
                return true;
            }

            var sumOfDigits = SumOfDigits(number);

            // There is a special case with 3 and 9, where the number can be divided by 3 or 9 when the total of it's digits can be divided by 3 or 9.
            if (sumOfDigits % 3 == 0 || sumOfDigits % 9 == 0)
            {
                return true;
            }

            // Divisors 2 and 3 have been checked already
            if (number % 5 == 0 || number % 7 == 0)
            {
                return true;
            }

            var sqrt = Math.Sqrt(number);
            for (var i = 11; i < sqrt; i += 6)
            {
                if (number % i == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public static List<int> PrimeNumbers(int max)
        {
            if (max < 1)
            {
                return null;
            }

            var results = new List<int>();
            results.Add(1);

            var sieve = new System.Collections.BitArray(max, true);
            sieve[0] = false;
            sieve[1] = true;

            for (var i = 2; i < max; i++)
            {
                if (sieve[i])
                {
                    results.Add(i);
                    for (var j = i += i; j < max; j += i)
                    {
                        sieve[j] = false;
                    }
                }
            }

            return results;
        }

        public static int SumOfDigits(int number)
        {
            return SumOfDigits(number.ToString());
        }

        public static int SumOfDigits(string number)
        {
            var total = 0;

            foreach(var digit in number)
            {
                total += digit - '0';
            }

            return total;
        }
    }
}
