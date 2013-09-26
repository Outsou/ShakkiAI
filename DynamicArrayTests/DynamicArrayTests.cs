using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ChessEngine.AI;

namespace DynamicArrayTests
{
    [TestClass]
    public class DynamicArrayTests
    {
        int startingSize = 16;
        string wrongStartingSize = "Starting size wrong";
        string wrongArrayContent = "Array content wrong";

        [TestMethod]
        public void CreatingNewArrayReturnsEmptyArraySize16()
        {
            DynamicArray array = new DynamicArray();

            Assert.AreEqual(0, array.Length, "New array has wrong ending index");
            Assert.AreEqual(startingSize, array.TrueSize, wrongStartingSize);
        }

        [TestMethod]
        public void Add5RandomNumbersToArray()
        {
            DynamicArray array = new DynamicArray();
            byte[] checkArray = new byte[5];
            Random randomGenerator = new Random();
            byte randomNumber;

            for (int i = 0; i < 5; i++)
            {
                randomNumber = (byte)(randomGenerator.Next(0, byte.MaxValue + 1));
                array.Add(randomNumber);
                checkArray[i] = randomNumber;
            }

            byte[] checkArray2 = new byte[5];
            int index = 0;

            foreach (byte number in array)
            {
                checkArray2[index] = number;
                index++;
            }

            CollectionAssert.AreEqual(checkArray, checkArray2, wrongArrayContent);
            Assert.AreEqual(startingSize, array.TrueSize, wrongStartingSize);
        }

        [TestMethod]
        public void AddMillionRandomNumbersToArray()
        {
            int million = 1000000;
            DynamicArray array = new DynamicArray();
            byte[] checkArray = new byte[million];
            Random randomGenerator = new Random();
            byte randomNumber;

            for (int i = 0; i < million; i++)
            {
                randomNumber = (byte)(randomGenerator.Next(0, byte.MaxValue + 1));
                array.Add(randomNumber);
                checkArray[i] = randomNumber;
            }

            byte[] checkArray2 = new byte[million];
            int index = 0;

            foreach (byte number in array)
            {
                checkArray2[index] = number;
                index++;
            }

            CollectionAssert.AreEqual(checkArray, checkArray2, wrongArrayContent);

            int expectedTrueSize = startingSize;

            while (expectedTrueSize < million)
            {
                expectedTrueSize *= 2;
            }

            Assert.AreEqual(expectedTrueSize, array.TrueSize, "Expected true size wrong");
        }
    }
}
