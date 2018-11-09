namespace CodeWars.Test
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class KataTests
    {
        [Test]
        public void IsPangramTests()
        {
            Assert.AreEqual(true, Kata.IsPangram("The quick brown fox jumps over the lazy dog."));
        }

        [Test]
        public void TestSimple()
        {
            var expected = new int[] { 20, 37, 21 };

            var actual = Kata.DeleteNth(new int[] { 20, 37, 20, 21 }, 1);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void TestSimple2()
        {
            var expected = new int[] { 1, 1, 3, 3, 7, 2, 2, 2 };

            var actual = Kata.DeleteNth(new int[] { 1, 1, 3, 3, 7, 2, 2, 2, 2 }, 3);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase("a clash of KINGS", "a an the of", "A Clash of Kings")]
        [TestCase("THE WIND IN THE WILLOWS", "The In", "The Wind in the Willows")]
        [TestCase("the quick brown fox", "", "The Quick Brown Fox")]
        public void TestTitleCase(string sentence, string exceptions, string expected)
        {
            Assert.AreEqual(expected, Kata.TitleCase(sentence, exceptions));
        }

        [Test]
        public void BasicReverseWordsTests()
        {
            Assert.AreEqual("world! hello", Kata.ReverseWords("hello world!"));
            Assert.AreEqual("this like speak doesn't yoda", Kata.ReverseWords("yoda doesn't speak like this"));
            Assert.AreEqual("foobar", Kata.ReverseWords("foobar"));
            Assert.AreEqual("kata editor", Kata.ReverseWords("editor kata"));
            Assert.AreEqual("boat your row row row", Kata.ReverseWords("row row row your boat"));
        }

        [Test]
        public void SampleReplaceWithAlphabetPositionTest()
        {
            Assert.AreEqual("20 8 5 19 21 14 19 5 20 19 5 20 19 1 20 20 23 5 12 22 5 15 3 12 15 3 11", Kata.AlphabetPosition("The sunset sets at twelve o' clock."));
            Assert.AreEqual("20 8 5 14 1 18 23 8 1 12 2 1 3 15 14 19 1 20 13 9 4 14 9 7 8 20", Kata.AlphabetPosition("The narwhal bacons at midnight."));
        }

        [Test]
        public void Test1()
        {
            Console.WriteLine("****** Basic Tests");
            Assert.AreEqual("2000 103 123 4444 99", Kata.OrderWeight("103 123 4444 99 2000"));
            Assert.AreEqual("11 11 2000 10003 22 123 1234000 44444444 9999", Kata.OrderWeight("2000 10003 1234000 44444444 9999 11 11 22 123"));
        }

        [TestCase(1, "I")]
        [TestCase(5, "V")]
        [TestCase(10, "X")]
        [TestCase(50, "L")]
        [TestCase(100, "C")]
        [TestCase(500, "D")]
        [TestCase(1000, "M")]
        [TestCase(4, "IV")]
        [TestCase(1990, "MCMXC")]
        [TestCase(1666, "MDCLXVI")]
        [TestCase(1444, "MIVXLCD")]
        public void DecimalToRomanTest(int value, string expected)
        {
            Assert.AreEqual(expected, Kata.ConvertDecimalToRoman(value));
        }

        [TestCase("I", 1)]
        [TestCase("V", 5)]
        [TestCase("X", 10)]
        [TestCase("L", 50)]
        [TestCase("C", 100)]
        [TestCase("D", 500)]
        [TestCase("M", 1000)]
        [TestCase("IV", 4)]
        [TestCase("MCMXC", 1990)]
        [TestCase("MDCLXVI", 1666)]
        [TestCase("MIVXLCD", 1444)]
        public void RomanToDecimalTest(string value, int expected)
        {
            Assert.AreEqual(expected, Kata.ConvertRomanToDecimal(value));
        }
    }
}
