using System;
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
    }
}
