using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CodeWars
{
    public class Kata
    {
        /// <summary>
        /// A pangram is a sentence that contains every single letter of the alphabet at least once. For example, the sentence "The quick brown fox jumps over the lazy dog" is a pangram, because it uses the letters A-Z at least once (case is irrelevant).
        /// Given a string, detect whether or not it is a pangram.Return True if it is, False if not.Ignore numbers and punctuation.
        /// </summary>
        /// <param name="str">Sentence</param>
        /// <returns>Whether the sentence is a pangram.</returns>
        public static bool IsPangram(string str)
        {
            var used = new bool[26];
            foreach (var letter in str)
            {
                if (char.IsLetter(letter))
                {
                    used[char.ToUpper(letter) - 65] = true;
                }
            }

            return !used.Where(p => !p).Any();
        }

        /// <summary>
        /// Enough is enough!
        /// Alice and Bob were on a holiday.Both of them took many pictures of the places they've been,
        /// and now they want to show Charlie their entire collection. However, Charlie doesn't like this sessions,
        /// since the motive usually repeats.He isn't fond of seeing the Eiffel tower 40 times.
        /// He tells them that he will only sit during the session if they show the same motive at most N times.
        /// Luckily, Alice and Bob are able to encode the motive as a number.
        /// Can you help them to remove numbers such that their list contains each number only up to N times, without changing the order? 
        /// Task
        /// Given a list lst and a number N, create a new list that contains each number of lst at most N times without reordering.For example if N = 2, and the input is [1,2,3,1,2,1,2,3], you take[1, 2, 3, 1, 2], drop the next[1, 2] since this would lead to 1 and 2 being in the result 3 times, and then take 3, which leads to[1, 2, 3, 1, 2, 3].
        /// Example
        /// Kata.DeleteNth (new int[] {20,37,20,21}, 1) // return [20,37,21]
        /// Kata.DeleteNth(new int[] {1,1,3,3,7,2,2,2,2}, 3) // return [1, 1, 3, 3, 7, 2, 2, 2]
        /// </summary>
        /// <param name="arr">Items, potentially to be removed.</param>
        /// <param name="n">How many times an item may occur.</param>
        /// <returns></returns>
        public static int[] DeleteNth(int[] items, int n)
        {
            // Deleting every occurence above an amount.
            var keeps = new List<int>();
            var occurences = new Dictionary<int, int>();

            foreach (var motive in items)
            {
                if (occurences.ContainsKey(motive))
                {
                    occurences[motive]++;
                }
                else
                {
                    occurences[motive] = 1;
                }

                if (occurences[motive] <= n)
                {
                    keeps.Add(motive);
                }
            }

            return keeps.ToArray();
        }

        /*
        A string is considered to be in title case if each word in the string is either (a) capitalised (that is, only the first letter of the word is in upper case) or (b) considered to be an exception and put entirely into lower case unless it is the first word, which is always capitalised.

        Write a function that will convert a string into title case, given an optional list of exceptions (minor words). The list of minor words will be given as a string with each word separated by a space. Your function should ignore the case of the minor words string -- it should behave in the same way even if the case of the minor word string is changed.

        ###Arguments (Haskell)

            First argument: space-delimited list of minor words that must always be lowercase except for the first word in the string.
            Second argument: the original string to be converted.

        ###Arguments (Other languages)

            First argument (required): the original string to be converted.
            Second argument (optional): space-delimited list of minor words that must always be lowercase except for the first word in the string. The JavaScript/CoffeeScript tests will pass undefined when this argument is unused.

        ###Example

        Kata.TitleCase("a an the of", "a clash of KINGS")   => "A Clash of Kings"
        Kata.TitleCase("The In", "THE WIND IN THE WILLOWS") => "The Wind in the Willows"
        Kata.TitleCase("the quick brown fox")               => "The Quick Brown Fox"
        */
        public static string TitleCase(string title, string minorWords)
        {
            var words = title.Split(' ');
            var exceptions = string.IsNullOrWhiteSpace(minorWords)
                ? new string[0]
                : minorWords.ToLower().Split(' ');

            for (var i = 0; i < words.Length; i++)
            {
                if (i == 0)
                {
                    if (words[i].Length > 0)
                    {
                        words[i] = CapitalizeFirstLetter(words[i]);
                    }
                }
                else
                {
                    var lower = words[i].ToLower();
                    if (exceptions.Contains(lower))
                    {
                        words[i] = lower;
                    }
                    else if (words[i].Length > 0)
                    {
                        words[i] = CapitalizeFirstLetter(words[i]);
                    }
                }
            }

            return string.Join(" ", words);
        }

        private static string CapitalizeFirstLetter(string word)
        {
            return char.ToUpper(word[0]) + word.Substring(1).ToLower();
        }

        public static string ReverseWords(string str)
        {
            return string.Join(" ", str.Split(' ').Reverse());
        }

        /*
In this kata you are required to, given a string, replace every letter with its position in the alphabet.

If anything in the text isn't a letter, ignore it and don't return it.

a being 1, b being 2, etc.

As an example:

Kata.AlphabetPosition("The sunset sets at twelve o' clock.")

Should return "20 8 5 19 21 14 19 5 20 19 5 20 19 1 20 20 23 5 12 22 5 15 3 12 15 3 11" as a string.
        */
        public static string AlphabetPosition(string text)
        {
            return string.Join(" ", text.ToLower().Where(char.IsLetter).Select(letter => letter - 'a' + 1));
        }

        /*
My friend John and I are members of the "Fat to Fit Club (FFC)". John is worried because each month a list with the weights of members is published and each month he is the last on the list which means he is the heaviest.

I am the one who establishes the list so I told him: "Don't worry any more, I will modify the order of the list". It was decided to attribute a "weight" to numbers. The weight of a number will be from now on the sum of its digits.

For example 99 will have "weight" 18, 100 will have "weight" 1 so in the list 100 will come before 99. Given a string with the weights of FFC members in normal order can you give this string ordered by "weights" of these numbers?
Example:

"56 65 74 100 99 68 86 180 90" ordered by numbers weights becomes: "100 180 90 56 65 74 68 86 99"

When two numbers have the same "weight", let us class them as if they were strings and not numbers: 100 is before 180 because its "weight" (1) is less than the one of 180 (9) and 180 is before 90 since, having the same "weight" (9) it comes before as a string.

All numbers in the list are positive numbers and the list can be empty.
Notes

    it may happen that the input string have leading, trailing whitespaces and more than a unique whitespace between two consecutive numbers
    Don't modify the input
    For C: The result is freed.
        */
        public static string OrderWeight(string str)
        {
            var weights = str.Split(' ').Select(weight => new Weight(weight)).ToList();
            weights.Sort();
            return string.Join(" ", weights);
        }

        class Weight : IComparable<Weight>
        {
            string Value { get; set; }
            int Total { get; set; }

            public Weight(string input)
            {
                this.Value = input;

                foreach(var number in input)
                {
                    Total += number - '0';
                }
            }

            public int CompareTo(Weight other)
            {
                var compare = this.Total.CompareTo(other.Total);
                return compare == 0 ? this.Value.CompareTo(other.Value) : compare;
            }
        }

        /*
        https://www.codewars.com/kata/sum-by-factors/train/csharp
        Given an array of positive or negative integers

        I= [i1,..,in]

        you have to produce a sorted array P of the form

        [ [p, sum of all ij of I for which p is a prime factor (p positive) of ij] ...]

        P will be sorted by increasing order of the prime numbers. The final result has to be given as a string in Java, C#, C, C++ and as an array of arrays in other languages.

        Example:

        I = {12, 15}; // result = "(2 12)(3 27)(5 15)"

        [2, 3, 5] is the list of all prime factors of the elements of I, hence the result.

        Notes: It can happen that a sum is 0 if some numbers are negative!

        Example: I = [15, 30, -45] 5 divides 15, 30 and (-45) so 5 appears in the result, the sum of the numbers for which 5 is a factor is 0 so we have [5, 0] in the result amongst others.
        */
        public static string SumOfDivided(int[] list)
        {
            return string.Empty;
        }

        /*
        http://www.codewars.com/kata/51b62bf6a9c58071c600001b/train/csharp
        Roman Numerals Encoder
    Create a function taking a positive integer as its parameter and returning a string containing the Roman Numeral representation of that integer.

Modern Roman numerals are written by expressing each digit separately starting with the left most digit and skipping any digit with a value of zero. In Roman numerals 1990 is rendered: 1000=M, 900=CM, 90=XC; resulting in MCMXC. 2008 is written as 2000=MM, 8=VIII; or MMVIII. 1666 uses each Roman symbol in descending order: MDCLXVI.
        */
        public static string ConvertDecimalToRoman(int n)
        {
            var symbols = GetSymbols();
            var current = n;
            var roman = string.Empty;

            while (current > 0)
            {
                var i = symbols.Count - 1;
                foreach(var symbol in symbols)
                {
                    var div = Math.DivRem(current, symbol.Key, out int remainder);

                    for(var j = 0; j < div; j++)
                    {
                        roman += symbol.Value;
                    }
                }

                i--;
            }

            return roman;
        }

        public static int ConvertRomanToDecimal(string roman)
        {
            var symbols = GetRomanValues();
            var total = 0;
            var current = 0;
            var lastValue = 0;

            foreach(var letter in roman)
            {
                var value = symbols[letter];
                if (value == lastValue)
                {
                    current += value;
                }
                else if (value > lastValue)
                {
                    total -= value;
                }
                else if (value < lastValue)
                {

                }
            }
        }

        private static Dictionary<int, char> _symbols;
        private static Dictionary<char, int> _romanValues;

        public static Dictionary<int, char> GetSymbols()
        {
            if (_symbols == null)
            {
                _symbols = new Dictionary<int, char>
                {
                    { 1, 'I' },
                    { 5, 'V' },
                    { 10, 'X' },
                    { 50, 'L' },
                    { 100, 'C' },
                    { 500, 'D' },
                    { 1000, 'M' }
                };
            }

            return _symbols;
        }

        public static Dictionary<char, int> GetRomanValues()
        {
            if (_romanValues == null)
            {
                _romanValues = new Dictionary<char, int>
                {
                    { 'I', 1 },
                    { 'V', 5 },
                    { 'X', 10 },
                    { 'L', 50 },
                    { 'C', 100 },
                    { 'D', 500 },
                    { 'M', 1000 }
                };
            }

            return _romanValues;
        }
    }
}

/*
public static string OrderWeight(string str)
{
    var weights = str.Split(' ').Select(weight => new Weight(weight)).ToList();
    weights.Sort();
    return string.Join(" ", weights);
}

class Weight : IComparable<Weight>
{
    string Value { get; set; }
    int Total { get; set; }

    public Weight(string input)
    {
        this.Value = input;

        foreach (var number in input)
        {
            Total += number - '0';
        }
    }

    public int CompareTo(Weight other)
    {
        var compare = this.Total.CompareTo(other.Total);
        return compare == 0 ? this.Value.CompareTo(other.Value) : compare;
    }
}

*/
  