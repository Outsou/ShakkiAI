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
        DynamicArray array;
        Random randomGenerator = new Random();
        int million = 1000000;

        [TestMethod]
        public void CreatingNewArrayReturnsEmptyArrayWithCorrectStartingSize()
        {
            array = new DynamicArray();

            Assert.AreEqual(0, array.Count, "New array has wrong ending index");
            Assert.AreEqual(startingSize, array.TrueSize, wrongStartingSize);
        }

        [TestMethod]
        public void Add5RandomNumbersToArray()
        {
            array = new DynamicArray();
            byte[] checkArray = AddRandomNumbers(5, array);

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
            array = new DynamicArray();
            byte[] checkArray = AddRandomNumbers(million, array);

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

        [TestMethod]
        public void Add5RandomNumbersToArrayAndRemoveLast()
        {
            array = new DynamicArray();
            byte[] checkArray = AddRandomNumbers(5, array);

            array.RemoveLast();

            Assert.AreEqual(4, array.Count);

            int i = 0;

            foreach (byte number in array)
            {
                Assert.AreEqual(checkArray[i], number);
                i++;
            }
        }

        [TestMethod]
        public void AddMillionRandomNumbersToArrayAndRemoveLast()
        {
            array = new DynamicArray();
            byte[] checkArray = AddRandomNumbers(million, array);

            array.RemoveLast();

            Assert.AreEqual(million-1, array.Count);

            int i = 0;

            foreach (byte number in array)
            {
                Assert.AreEqual(checkArray[i], number);
                i++;
            }
        }

        [TestMethod]
        public void Add5NumbersToArrayAndRemoveThird()
        {
            array = new DynamicArray();

            array.Add(5);
            array.Add(3);
            array.Add(8);
            array.Add(7);
            array.Add(235);

            array.Remove(8);

            byte[] checkArray = new byte[4] {5, 3, 7, 235};

            Assert.AreEqual(4, array.Count);

            int i = 0;

            foreach (byte number in array)
            {
                Assert.AreEqual(checkArray[i], number);
                i++;
            }
        }

        private byte[] AddRandomNumbers(int amount, DynamicArray array)
        {
            byte[] arrayOfGeneratedNumbers = new byte[amount];
            byte randomNumber;

            for (int i = 0; i < amount; i++)
            {
                randomNumber = (byte)(randomGenerator.Next(0, byte.MaxValue + 1));
                array.Add(randomNumber);
                arrayOfGeneratedNumbers[i] = randomNumber;
            }

            return arrayOfGeneratedNumbers;
        }
    }
}
