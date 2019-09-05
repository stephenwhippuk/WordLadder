using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace WordLadderAPI.Tests
{
    public class WordWriterTests
    {
        FileWordWriter writer;

        [SetUp]
        public void Setup()
        {
            writer = new FileWordWriter("testoutput.dat");
        }

        [Test]
        public void TestClosed()
        {
            Assert.IsFalse(writer.IsOpen, "Error: COnnectionj stream is open and should be closed");
            writer.Close();
        }

        [Test]
        public void TestNoWriteIfClosed()
        {
            int i = writer._testGetNumWrites();
            WordNode test = new WordNode
            {
                Word = "test"
            };

            writer.Write(test);
            int j = writer._testGetNumWrites();
            Assert.AreEqual(i, j, "Error: a write occured");
            writer.Close();
        }


        [Test]
        public void TestOpen()
        {
            writer.Open();
            Assert.IsTrue(writer.IsOpen, "Error: connection did not open");
            writer.Close();
        }

        [Test]
        public void TestWrite()
        {
            writer.Open();
            int i = writer._testGetNumWrites();
            WordNode test = new WordNode
            {
                Word = "test"
            };
            writer.Write(test);
            int j = writer._testGetNumWrites();
            Assert.AreNotEqual(i, j, "Error: Write did not occur");
            writer.Close();
        }
    }
}
