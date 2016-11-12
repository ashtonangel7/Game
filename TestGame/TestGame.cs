namespace TestCommon
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Common.Records;
    using System.Collections.Generic;

    [TestClass]
    public class TestGame
    {
        [TestMethod]
        public void TestPlayGame()
        {
            NumbersGame testGame = new NumbersGame(99, 6, 10);
            List<int> expectedResult = new List<int>()
            {
                4,3,6,1,5
            };

            testGame.SetupNewGame();

            string message;
            Assert.IsTrue(testGame.Play(out message), message);
            Assert.IsTrue(string.IsNullOrWhiteSpace(message));
            CollectionAssert.AreEqual(expectedResult, testGame.ChildrenEliminated);
            Assert.IsTrue(testGame.Winner == 2);
        }

        [TestMethod]
        public void TestGameNoSetup()
        {
            NumbersGame testGame = new NumbersGame(99, 6, 10);

            //testGame.SetupNewGame();

            string message;
            Assert.IsFalse(testGame.Play(out message), message);
            Assert.IsFalse(string.IsNullOrWhiteSpace(message));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGameZero()
        {
            NumbersGame testGame = new NumbersGame(99, 0, 0);

            testGame.SetupNewGame();

            string message;
            Assert.IsFalse(testGame.Play(out message), message);
            Assert.IsFalse(string.IsNullOrWhiteSpace(message));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGameLessThanZero()
        {
            NumbersGame testGame = new NumbersGame(99, -10, 5);

            testGame.SetupNewGame();

            string message;
            Assert.IsFalse(testGame.Play(out message), message);
            Assert.IsFalse(string.IsNullOrWhiteSpace(message));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGameLessThanZero2()
        {
            NumbersGame testGame = new NumbersGame(99, 10, -5);

            testGame.SetupNewGame();

            string message;
            Assert.IsFalse(testGame.Play(out message), message);
            Assert.IsFalse(string.IsNullOrWhiteSpace(message));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGameIdLessThanZero()
        {
            NumbersGame testGame = new NumbersGame(-99, 10, 5);

            testGame.SetupNewGame();

            string message;
            Assert.IsFalse(testGame.Play(out message), message);
            Assert.IsFalse(string.IsNullOrWhiteSpace(message));
        }
    }
}
