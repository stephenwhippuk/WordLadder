using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace WordLadderAPI.Tests
{
    class FileWordReaderTests
    {
        FileWordReader<WordNode> fr;

        [SetUp]
        public void Setup()
        {
            fr = new FileWordReader<WordNode>(".\\testdata.txt");
        }

        [Test]
        public void TestCreateCLosed()
        {      
            Assert.IsFalse(fr.IsOpen, "Error: IsOpen is true");
            Assert.IsNull(fr.Next(), "Error: IsOpen should be false but Next Reading");
        }
        [Test]
        public void TestRead()
        {
            fr.Open();

            IWordNode i = fr.Next();
            Assert.AreEqual(i.Word, "Time", "Error: First Word read is not Time");
        }
        [Test]
        public void TestEnd()
        {
            // tests if ATEnd is correctly calculated
            // test file contains 6 records so 

            fr.Open();
            

            for (int i = 0; i < 6; i++)
            {
                IWordNode nod = fr.Next();
            }

            Assert.IsTrue(fr.AtEnd, "Error: AtEnd is not true (Before Read Attempt)");

            IWordNode nod2 = fr.Next();
            Assert.IsNull(nod2, "Error: Read Word when File is at End of File");

            Assert.IsTrue(fr.AtEnd, "Error: AtEnd is not true (AFter Read Attempt) ");
            

            
        }
        [Test]
        public void TestOpen()
        {
            Assert.IsFalse(fr.IsOpen, "Error: Steam not opened yet IsOpen true");
            fr.Open();
            Assert.IsTrue(fr.IsOpen, "Error: stream opened yet IsOpen is False");
        }

        [Test]
        public void testClose()
        {

            fr.Open();
            Assert.IsTrue(fr.IsOpen, "Error: Steam opened yet IsOpen false");
            fr.Close();
            Assert.IsFalse(fr.IsOpen, "Error: stream closed yet IsOpen is true");
            IWordNode nod = fr.Next();
            Assert.IsNull(nod, "Error: Word Read from Closed File");
        }
    }
}
