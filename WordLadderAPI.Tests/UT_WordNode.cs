using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace WordLadderAPI.Tests
{
    public class UT_WordNode
    {
        WordNode word1;
        WordNode word2;

        [SetUp]
        public void Setup()
        {
            word1 = new WordNode();
            word2 = new WordNode();
        }
        /// <summary>
        /// Store and Retrieve value of Words
        /// </summary>
        [Test]
        public void TestWord()
        {
            // test Setting and getting
            word1.Word = "Testing";

            string test = word1.Word;
            Assert.AreEqual(test, "Testing");

        }
        /// <summary>
        /// Store and Retrieve value of Words
        /// </summary>
        [Test]
        public void TestConstructor()
        {
            word2 = new WordNode("Testing");
            string test = word2.Word;
            Assert.AreEqual(test, "Testing");
        }
        [Test]
        public void Test_IsStepAway_FalseOnEqual()
        {
            word1.Word = "Test";
            word2.Word = "Test";
            Assert.IsFalse(word1.isStepAway(word2), "FAIL: IsStepAway true for words that are equal");
        }
        [Test]
        public void Test_IsStepAway_FalseOn2Step()
        {
            word1.Word = "Test";
            word2.Word = "Temp";
            Assert.IsFalse(word1.isStepAway(word2), "FAIL: IsStepAway true for words that are 2 steps away");
        }
        [Test]
        public void Test_IsStepAway_TrueOn1Step()
        {
            word1.Word = "Test";
            word2.Word = "Tent";
            Assert.IsTrue(word1.isStepAway(word2), "FAIL: IsStepAway false for words that are 1 step away");
        }
        [Test]
        public void Test_IsStepAway_FalseOnEmptyStrings()
        {
            word1.Word = "";
            word1.Word = "";
            Assert.IsFalse(word1.isStepAway(word2), "FAIL: IsStepAway true for empty strings");
        }
        [Test]
        public void Test_IsStepAway_FalseOnDifferentLengths()
        {
            word1.Word = "Test";
            word2.Word = "Tests";
            Assert.IsFalse(word1.isStepAway(word2), "FAIL: IsStepAway true for strings of different length");
        }
    }
}
