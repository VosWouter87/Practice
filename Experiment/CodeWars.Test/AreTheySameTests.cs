using System;
using NUnit.Framework;
using CodeWars;

[TestFixture]
public class AreTheySameTests
{
    [Test]
    public void TestBubbleSort()
    {
        // Arrange
        Console.WriteLine("test");
        var numbers = new int[] { 2, 6, 1, 5, 3, 4 };
        
        // Act
        //AreTheySame.Sort(numbers);

        // Assert
        for (var i = 0; i < numbers.Length; i++)
        {
            Assert.AreEqual(i + 1, numbers[i]);
        }
    }
    /*
      [Test]
      public void Test1() {
        int[] a = new int[] {121, 144, 19, 161, 19, 144, 19, 11};
        int[] b = new int[] {11*11, 121*121, 144*144, 19*19, 161*161, 19*19, 144*144, 19*19};
        bool r = AreTheySame.comp(a, b); // True
        Assert.AreEqual(true, r);
      }*/
}