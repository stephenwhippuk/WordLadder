using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace WordLadderAPI.Tests
{
    class UT_FileWordWriter
    {
        FileWordWriter writer;
        [SetUp]
        public void Setup()
        {
            writer = new FileWordWriter("TestFile2.txt");
        }

        [Test]
        public void Test_Connection_Closed()
        {
            Assert.IsFalse(writer.IsOpen, "Error: Connection should be created Closed");
            writer.Close();
        }

        [Test]
        public void Test_Open_OpensConnection()
        {
            writer.Open();
            Assert.IsTrue(writer.IsOpen, "Error: Connection should be Open");
            writer.Close();
        }

        [Test]
        public void Test_Close_ClosesConnection()
        {
            writer.Open();
            writer.Close();
            Assert.IsFalse(writer.IsOpen, "Error: Connection should be Closed");
            writer.Close();
        }

        [Test]
        public void Test_Write_FailsifCLosed()
        {
            bool hasError = false;
            try
            {
                WordNode_Stub_Pass w = new WordNode_Stub_Pass() { Word = "Hello" };
                writer.Write(w);
            }
            catch
            {
                hasError = true;
            }
            Assert.IsTrue(hasError, "Error: COnnection should be closed for writing");
            writer.Close();
        }

        [Test]
        public void Test_Write_One()
        {
            WordNode_Stub_Pass w = new WordNode_Stub_Pass() { Word = "Hello" };
            try
            {
                writer.Open();
                writer.Write(w);
            }
            catch
            {
                Assert.Fail("The Connection is closed");
            }
            writer.Close();
            string txt = "";
            using (System.IO.StreamReader reader = new System.IO.StreamReader("TestFile2.txt"))
            {
                txt = reader.ReadLine();
                Console.WriteLine(txt);
            }
            Assert.IsTrue(txt == "Hello", "Error: " +txt + "is not equal \"Hello\"");
        }
        [Test]
        public void Test_Write_MultipleLines()
        {
            WordNode_Stub_Pass w = new WordNode_Stub_Pass() { Word = "Hello" };
            WordNode_Stub_Pass w2 = new WordNode_Stub_Pass() { Word = "Fred" };
            try
            {
                writer.Open();
                writer.Write(w);
                writer.Write(w2);
            }
            catch
            {
                Assert.Fail("The Connection is Closed");
            }
            writer.Close();
            List<string> lst = new List<string>();
            using (System.IO.StreamReader reader = new System.IO.StreamReader("TestFile2.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    lst.Add(line);
                    Console.WriteLine(line);
                }
                
            }
            string txt = "";
            for (int i = 0; i < lst.Count-1; i++)
            {
                txt += lst[i] + ", ";
            }
            txt += lst[lst.Count - 1];
            Assert.IsTrue(txt == "Hello, Fred", "Error: " + txt + "is not equal \"Hello, Fred\"");
        }
    }
}
