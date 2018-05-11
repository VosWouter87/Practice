namespace CodeWars.Test
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class DigPowTests
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual(1, DigPow.digPow(89, 1));
        }
        [Test]
        public void Test2()
        {
            Assert.AreEqual(-1, DigPow.digPow(92, 1));
        }
        [Test]
        public void Test3()
        {
            Assert.AreEqual(51, DigPow.digPow(46288, 3));
        }
    }
}
