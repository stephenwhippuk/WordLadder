using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace WordLadderAPI.Tests
{
    public class UT_WordSequence
    {
        WordSequence seq;

        [SetUp]
        public void Setup()
        {
            seq = new WordSequence();
        }

        [Test]
        public void Test_Append_NC_NoSequence()
        {
            WordNode_Stub_Fail w1 = new WordNode_Stub_Fail();
            w1.Word = "Fail";
            WordNode_Stub_Fail w2 = new WordNode_Stub_Fail();
            w2.Word = "Random";
            seq.Append(w1);
            seq.Append(w2);
            // insapite of them being fail types they should be appended
            Assert.IsTrue(seq.Length == 2, "Fail: WordSequence with no constraints failing to add word out of sequence");
        }
        [Test]
        public void Test_Append_NC_Duplicate()
        {
            WordNode_Stub_Fail w1 = new WordNode_Stub_Fail();
            w1.Word = "Fail";
            WordNode_Stub_Fail w2 = new WordNode_Stub_Fail();
            w2.Word = "Fail";
            seq.Append(w1);
            seq.Append(w2);
            // inspite of them being fail types they should be appended
            Assert.IsTrue(seq.Length == 2, "Fail: WordSequence with no constraints failing to add duplicate words");
        }

        [Test]
        public void Test_Append_NoDup_Duplicate()
        {
            seq.CheckUniqueConstraint = true;
            WordNode_Stub_Fail w1 = new WordNode_Stub_Fail();
            w1.Word = "Fail";
            WordNode_Stub_Fail w2 = new WordNode_Stub_Fail();
            w2.Word = "Fail";
            try
            {
                seq.Append(w1);
                seq.Append(w2);
            }
            catch
            {
                Console.WriteLine("Exception Correctly Detected");
            }
            Assert.IsTrue(seq.Length == 1, "Fail: no Duplicate COnstraint not stopped duplicate");
        }
        [Test]
        public void Test_Append_NoDup_NoDuplicate()
        {
            seq.CheckUniqueConstraint = true;
            WordNode_Stub_Fail w1 = new WordNode_Stub_Fail();
            w1.Word = "Fail";
            WordNode_Stub_Fail w2 = new WordNode_Stub_Fail();
            w2.Word = "Tail";
            try
            {
                seq.Append(w1);
                seq.Append(w2);
            }
            catch
            {
                Console.WriteLine("Exception Incorrectly Detected");
            }
            Assert.IsTrue(seq.Length == 2, "Fail: no Duplicate COnstraint stopped non-duplicate");
        }
        [Test]
        public void Test_Append_InSeq_InSequence()
        {
            seq.CheckLinkConstraint = true;
            WordNode_Stub_Pass w1 = new WordNode_Stub_Pass();
            w1.Word = "Pass";
            WordNode_Stub_Pass w2 = new WordNode_Stub_Pass();
            w2.Word = "Past";

            try
            {
                seq.Append(w1);
                seq.Append(w2);
            }
            catch
            {
                Console.WriteLine("Exception Incorrectly Detected");
            }
            Assert.IsTrue(seq.Length == 2, "Fail: Sequence InSequence Failed to be added");
        }
        [Test]
        public void Test_Append_InSeq_OutOfSequence()
        {
            seq.CheckLinkConstraint = true;
            WordNode_Stub_Fail w1 = new WordNode_Stub_Fail();
            w1.Word = "Pass";
            WordNode_Stub_Fail w2 = new WordNode_Stub_Fail();
            w2.Word = "Last";

            try
            {
                seq.Append(w1);
                seq.Append(w2);
            }
            catch
            {
                Console.WriteLine("Exception correctly Detected");
            }
            Assert.IsTrue(seq.Length == 1, "Fail: Sequence OutOfSequence added");
        }
        [Test]
        public void Test_Contains_NotDuplicate()
        {
            WordNode_Stub_Fail w1 = new WordNode_Stub_Fail() { Word = "Test" };
            WordNode_Stub_Fail w2 = new WordNode_Stub_Fail() { Word = "Tent" };
            seq.Append(w1);
            bool ret = seq.Contains(w2);
            Assert.IsFalse(ret, "Error: seq does not contain value of word2"); 
        }
        [Test]
        public void Test_Contains_Duplicate()
        {
            WordNode_Stub_Fail w1 = new WordNode_Stub_Fail() { Word = "Test" };
            seq.Append(w1);
            bool ret = seq.Contains(w1);
            Assert.IsTrue(ret, "Error: seq does contain value of word1");
        }
        [Test]
        public void Test_Contains_Empty()
        {
            WordNode_Stub_Fail w1 = new WordNode_Stub_Fail() { Word = "Test" };
            bool ret = seq.Contains(w1);
            Assert.IsFalse(ret, "Error: seq does contain value of word1");
        }

        [Test]
        public void Test_Contains_EmptyString()
        {
            WordNode_Stub_Fail w1 = new WordNode_Stub_Fail() { Word = "" };
            bool ret = seq.Contains(w1);
            Assert.IsFalse(ret, "Error: seq cannot contain empty words");
        }

        [Test]
        public void Test_Contains_NullString()
        {
            WordNode_Stub_Fail w1 = new WordNode_Stub_Fail();
            bool ret = seq.Contains(w1);
            Assert.IsFalse(ret, "Error: seq cannot contain Nulls");
        }

        [Test]
        public void Test_Pop_Empty()
        {
            IWordNode w = null;
            try
            {
                w = seq.Pop();
            }
            catch
            {
                Console.WriteLine("Exception Detected");
            }
            finally
            {
                Assert.IsNull(w);
            }

        }

        [Test]
        public void Test_Pop_Single()
        {
            WordNode_Stub_Pass w = new WordNode_Stub_Pass() { Word = "Hello" };
            seq.Append(w);
            IWordNode r = seq.Pop();
            Assert.IsTrue(r.Word == "Hello", "Error: Incorrect value returned");

        }

        [Test]
        public void Test_Pop_MoreThanOne()
        {
            WordNode_Stub_Pass w1 = new WordNode_Stub_Pass() { Word = "Hello" };
            WordNode_Stub_Pass w2 = new WordNode_Stub_Pass() { Word = "Fred" };
            seq.Append(w1);
            seq.Append(w2);
            IWordNode r = seq.Pop();
            Assert.IsTrue(r.Word == "Fred", "Error: Incorrect value returned");
        }

        [Test]
        public void Test_Index()
        {
            WordNode_Stub_Pass w1 = new WordNode_Stub_Pass() { Word = "Hello" };
            WordNode_Stub_Pass w2 = new WordNode_Stub_Pass() { Word = "Fred" };
            WordNode_Stub_Pass w3 = new WordNode_Stub_Pass() { Word = "It's" };
            WordNode_Stub_Pass w4 = new WordNode_Stub_Pass() { Word = "Weds" };

            seq.Append(w1);
            seq.Append(w2);
            seq.Append(w3);
            seq.Append(w4);

            string result = "";
            for (int i =0; i < seq.Length; i++)
            {
                result += seq[i].Word + " ";
            }
            Assert.IsTrue(result == "Hello Fred It's Weds ", "Error: " + result + "not equal to \"Hello Fred It's Weds \"");
        }

        [Test]
        public void Test_Copy()
        {
            WordNode_Stub_Pass w1 = new WordNode_Stub_Pass() { Word = "Hello" };
            WordNode_Stub_Pass w2 = new WordNode_Stub_Pass() { Word = "Fred" };
            WordNode_Stub_Pass w3 = new WordNode_Stub_Pass() { Word = "It's" };
            WordNode_Stub_Pass w4 = new WordNode_Stub_Pass() { Word = "Weds" };

            seq.Append(w1);
            seq.Append(w2);
            seq.Append(w3);
            seq.Append(w4);

            WordSequence seq2 = new WordSequence();
            seq2.Copy(seq);

            string result = "";
            for (int i = 0; i < seq2.Length; i++)
            {
                result += seq2[i].Word + " ";
            }
            Assert.IsTrue(result == "Hello Fred It's Weds ", "Error: " + result + "not equal to \"Hello Fred It's Weds \"");
        }

        [Test]
        public void Test_ToString_Empty()
        {
            string s = seq.ToString();
            Assert.IsTrue(s == "", "Error: " + s + " not equal to \"\"");
        }

        [Test]
        public void Test_ToString_One()
        {
            WordNode_Stub_Pass w1 = new WordNode_Stub_Pass() { Word = "Hello" };
            seq.Append(w1);
            string s = seq.ToString();
            Assert.IsTrue(s == "Hello", "Error: " + s + " not equal to \"Hello\"");
        }

        [Test]
        public void Test_ToString_Many()
        {
            WordNode_Stub_Pass w1 = new WordNode_Stub_Pass() { Word = "Hello" };
            WordNode_Stub_Pass w2 = new WordNode_Stub_Pass() { Word = "Fred" };
            seq.Append(w1);
            seq.Append(w2);
            string s = seq.ToString();
            Assert.IsTrue(s == "Hello, Fred", "Error: " + s + " not equal to \"Hello, Fred\"");
        }

        [Test]
        public void Test_Save_Empty()
        {
            WordWriter_Stub writer = new WordWriter_Stub();
            writer.Open();
            seq.Save(writer);
            Assert.IsTrue(writer.Output == "", "Error: " + writer.Output + "does not equal \"\"");
        }
        [Test]
        public void Test_Save_One()
        {
            WordWriter_Stub writer = new WordWriter_Stub();
            writer.Open();
            WordNode_Stub_Pass w1 = new WordNode_Stub_Pass() { Word = "Hello" };

            seq.Append(w1);
            
            seq.Save(writer);
            Assert.IsTrue(writer.Output == "Hello\n", "Error: " + writer.Output + "does not equal \"Hello\n\"");
        }

        [Test]
        public void Test_Save_Many()
        {
            WordWriter_Stub writer = new WordWriter_Stub();
            writer.Open();
            WordNode_Stub_Pass w1 = new WordNode_Stub_Pass() { Word = "Hello" };
            WordNode_Stub_Pass w2 = new WordNode_Stub_Pass() { Word = "Fred" };
            seq.Append(w1);
            seq.Append(w2);
            seq.Save(writer);
            Assert.IsTrue(writer.Output == "Hello\nFred\n", "Error: " + writer.Output + "does not equal \"Hello\nFred\n\"");
        }

        [Test]
        public void Test_Save_ClosedConnection()
        {
            bool hasError = false;
            try
            {
                WordWriter_Stub writer = new WordWriter_Stub();
                seq.Save(writer);
            }
            catch
            {
                hasError = true;
            }
            Assert.IsTrue(hasError, "Error: no execption was thrown when using closed Connection");
        }

        [Test]
        public void Test_Length_Empty()
        {
            Assert.IsTrue(seq.Length == 0, "Error: EMpty Sequence not of Length 0");
        }

        [Test]
        public void Test_Length_NonZero()
        {
            WordNode_Stub_Pass w1 = new WordNode_Stub_Pass() { Word = "Hello" };

            seq.Append(w1);
            Assert.IsTrue(seq.Length == 1, "Error: Sequence not of Length 1");
        }
        [Test]
        public void Test_FirstWord_IsNullOnEmpty()
        {
            Assert.IsNull(seq.FirstWord, "Error: First name is not null");
        }

        [Test]
        public void Test_FirstWord_IsFirst()
        {
            WordNode_Stub_Pass w1 = new WordNode_Stub_Pass() { Word = "Hello" };
            WordNode_Stub_Pass w2 = new WordNode_Stub_Pass() { Word = "Fred" };
            seq.Append(w1);
            seq.Append(w2);
            Assert.IsTrue(seq.FirstWord.Word == "Hello", "Error: " + seq.FirstWord + " is not equal to\"Hello\"");
        }
        [Test]
        public void Test_LastWord_IsLast()
        {
            WordNode_Stub_Pass w1 = new WordNode_Stub_Pass() { Word = "Hello" };
            WordNode_Stub_Pass w2 = new WordNode_Stub_Pass() { Word = "Fred" };
            seq.Append(w1);
            seq.Append(w2);
            Assert.IsTrue(seq.LastWord.Word == "Fred", "Error: " + seq.LastWord + " is not equal to \"Fred\"");
        }
    }
}
