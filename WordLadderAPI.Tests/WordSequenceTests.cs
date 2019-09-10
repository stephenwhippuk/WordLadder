using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace WordLadderAPI.Tests
{
    class WordSequenceTests
    {
        WordSequence seq;
        string[] stringlist;

        [SetUp]
        public void Setup()
        {
            // setup our strings
            stringlist = new string[6];
            stringlist[0] = "Time";
            stringlist[1] = "Tame";
            stringlist[2] = "Take";
            stringlist[3] = "Wake";
            stringlist[4] = "Wane";
            stringlist[5] = "Wine";

            seq = new WordSequence();

        }

        [Test]
        public void TestSize()
        {
            Assert.IsTrue(seq.Length == 0, "Error: List is not empty");
        }
        [Test]
        public void TestNotAppendNull()
        {
            int len = seq.Length;
            seq.Append(null);
            Assert.AreEqual(len, seq.Length, "Error: null reference added");

        }
        [Test]
        public void TestAppendWord()
        {
            int len = seq.Length;

            IWordNode w = new WordNode
            {
                Word = stringlist[0]
            };

            seq.Append(w);
            Assert.AreNotEqual(len, seq.Length, "Error: Word not appended");
        }
        [Test]
        public void TestContains()
        {
            IWordNode w = new WordNode
            {
                Word = stringlist[0]
            };

            seq.Append(w);
            bool b = seq.Contains(w);
            Assert.IsTrue(b, "Error: Sequence should contain word");
        }
        [Test]
        public void TestToString()
        {
            string intended = "Time, Tame";
            seq.Append(new WordNode(stringlist[0]) );
            seq.Append(new WordNode(stringlist[1]) );
            Assert.AreEqual(seq.ToString(), intended, "Error: ToString is not creating proper Output");
        }

        [Test]
        public void TestSave()
        {
            // Add all string list to sequence
            // save to file
            // use a stream reader to open foile and load contents into a list
            // test each element to make sure correct
            for(int i = 0; i < 6; i++)
            {
                seq.Append(new WordNode( stringlist[i]));
            }

            FileWordWriter writer = new FileWordWriter("testsave.dat");
            writer.Open();
            seq.Save(writer);
            writer.Close();

            FileWordReader<WordNode> reader = new FileWordReader<WordNode>("testsave.dat");
            reader.Open();
            for (int i = 0; i < 6; i++)
            {
                string wrd = reader.Next().Word;
                Assert.AreEqual(stringlist[i], wrd, "Error: string {0} is not correct", i);
            }
            reader.Close();
        }
    }
}
