using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WordLadderAPI.Tests
{
    public class UT_FileWordReader
    {
        FileWordReader<WordNode_Stub_Pass> reader;

        [SetUp]
        public void Setup()
        {
            using (StreamWriter writer = new StreamWriter("testreader.txt"))
            {
                writer.Write("Hello\nFred\nIt's\nWeds\n");
            }

            reader = new FileWordReader<WordNode_Stub_Pass>("testreader.txt");

        }
        [Test]
        public void Test_IsClosedOnCreate()
        {
            Assert.IsFalse(reader.IsOpen, "Error: COnnection is Open");
            reader.Close();
        } 
        [Test]
        public void Test_Open_Opens()
        {
            reader.Open();
            Assert.IsTrue(reader.IsOpen, "Error: COnnection is Closed");
            reader.Close();
        }
        [Test]
        public void Test_CLose_Closes()
        {
            reader.Open();
            reader.Close();
            Assert.IsFalse(reader.IsOpen, "Error: COnnection is Open");
        }
        [Test]
        public void Test_Next_Reads()
        {
            reader.Open();
            var w = reader.Next();
            Assert.IsTrue(w.Word == "Hello", "Error: " + w.Word + " not equal to \"Hello\"");
            reader.Close();
        }
        [Test]
        public void Test_Next_DetectsEOF()
        {

            reader.Open();
            for (int i = 0; i < 4; i++)
            {
                reader.Next();
            }
            bool atEnd = reader.AtEnd;

            reader.Close();
            Assert.IsTrue(atEnd, "Error: Not at End of Stream");
        }
        [Test]
        public void Test_Next_CannotReadPastEOF()
        {
            try
            {
                reader.Open();
                for (int i = 0; i < 5; i++)
                {
                    reader.Next();
                }
                
            }
            catch
            {
                Assert.Pass();
            }
            finally
            {
                reader.Close();
            }
            Assert.Fail("Error: End of Stream not reached");
        }

        [Test]
        public void Test_Next_CannotReadIfCLosed()
        {
            try
            {
                reader.Next();
                Assert.Fail("Error: Reading from Closed STream");
            }
            catch
            {
                Assert.Pass();
            }
            finally
            {
                reader.Close();
            }
            
        }
    }
}
