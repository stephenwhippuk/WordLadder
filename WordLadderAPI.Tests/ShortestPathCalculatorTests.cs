using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace WordLadderAPI.Tests
{
    public class ShortestPathCalculatorTests
    {
        ShortestSequenceCalculator<WordSequence, List<IWordNode>> calculator;
        [SetUp]
        public void Setup ()
        {
            calculator = new ShortestSequenceCalculator<WordSequence, List<IWordNode>>();
            // setup data
            List<IWordNode> wordpool = new List<IWordNode>
            {
                new WordNode{ Word = "Time"},
                new WordNode{ Word = "Tame"},
                new WordNode{ Word = "Take"},
                new WordNode{ Word = "Wake"},
                new WordNode{ Word = "Wane"},
                new WordNode{ Word = "Wine"},
            };
            calculator.WordPool = wordpool;
            calculator.Start = new WordNode { Word = "Wine" };
            calculator.Finish = new WordNode { Word = "Time" };
        }

        [Test]
        public void SimpleRunTest()
        {
            WordSequence seq = new WordSequence();
            calculator.GetPath(seq);
            Console.WriteLine(seq.ToString());
            Assert.IsTrue(seq.Length == 6, "Sequence not complete");
            Assert.IsTrue(seq.FirstWord.Word == calculator.Start.Word, "Sequence doesn;t begin with start");
            Assert.IsTrue(seq.LastWord.Word == calculator.Finish.Word, "sequence doesn;t end with finish");
        }
        [Test]
        public void StartNotIn()
        {
            calculator.Start.Word = "Yale";
            WordSequence seq = new WordSequence();
            try
            {
                calculator.GetPath(seq);
            }
            catch
            {
                Assert.Pass("Correctly Detected no Start Word in WordPool");
            }
            Assert.Fail("Error: StartWord not in WordPool but not detected");
        }
        [Test]
        public void FinishNotIn()
        {
            calculator.Finish.Word = "Yale";
            WordSequence seq = new WordSequence();
            try
            {
                calculator.GetPath(seq);
            }
            catch
            {
                Assert.Pass("Correctly Detected no Finish Word in WordPool");
            }
            Assert.Fail("Error: Finish Word not in WordPool but not detected");
        }

        [Test]
        public void TwoPossiblePaths()
        {
            // change data
            List<IWordNode> wordpool = new List<IWordNode>
            {
                new WordNode{ Word = "Time"},
                new WordNode{ Word = "Tame"},
                new WordNode{ Word = "Take"},
                new WordNode{ Word = "Wake"},
                new WordNode{ Word = "Wane"},
                new WordNode{ Word = "Wine"},
                new WordNode{ Word = "Dine"},
                new WordNode{ Word = "Dime"},
            };
            calculator.WordPool = wordpool;

            WordSequence seq = new WordSequence();
            calculator.GetPath(seq);
            Console.WriteLine(seq.ToString());
            Assert.IsTrue(seq.Length == 4, "Sequence not complete");
            Assert.IsTrue(seq.FirstWord.Word == calculator.Start.Word, "Sequence doesn;t begin with start");
            Assert.IsTrue(seq.LastWord.Word == calculator.Finish.Word, "sequence doesn;t end with finish");
        }
        [Test]
        public void TwoPossiblePathsWithRandomWords()
        {
            // change data
            List<IWordNode> wordpool = new List<IWordNode>
            {
                new WordNode{ Word = "Time"},
                new WordNode{ Word = "Lean"},
                new WordNode{ Word = "Deal"},
                new WordNode{ Word = "Tame"},
                new WordNode{ Word = "Take"},
                new WordNode{ Word = "Adam"},
                new WordNode{ Word = "Wake"},
                new WordNode{ Word = "Mail"},
                new WordNode{ Word = "Wane"},
                new WordNode{ Word = "Heal"},
                new WordNode{ Word = "Wine"},
                new WordNode{ Word = "Dine"},
                new WordNode{ Word = "Dime"},
            };
            calculator.WordPool = wordpool;

            WordSequence seq = new WordSequence();
            calculator.GetPath(seq);
            Console.WriteLine(seq.ToString());
            Assert.IsTrue(seq.Length == 4, "Sequence not complete");
            Assert.IsTrue(seq.FirstWord.Word == calculator.Start.Word, "Sequence doesn;t begin with start");
            Assert.IsTrue(seq.LastWord.Word == calculator.Finish.Word, "sequence doesn;t end with finish");
        }
        [Test]
        public void TwoPossiblePathsWithRepeats()
        {
            // change data
            List<IWordNode> wordpool = new List<IWordNode>
            {
                new WordNode{ Word = "Time"},
                new WordNode{ Word = "Tame"},
                new WordNode{ Word = "Take"},
                new WordNode{ Word = "Wake"},
                new WordNode{ Word = "Wake"},
                new WordNode{ Word = "Wake"},
                new WordNode{ Word = "Wane"},
                new WordNode{ Word = "Wine"},
                new WordNode{ Word = "Dine"},
                new WordNode{ Word = "Dime"},
            };
            calculator.WordPool = wordpool;

            WordSequence seq = new WordSequence();
            calculator.GetPath(seq);
            Console.WriteLine(seq.ToString());
            Assert.IsTrue(seq.Length == 4, "Sequence not complete");
            Assert.IsTrue(seq.FirstWord.Word == calculator.Start.Word, "Sequence doesn;t begin with start");
            Assert.IsTrue(seq.LastWord.Word == calculator.Finish.Word, "sequence doesn;t end with finish");
        }
        [Test]
        public void TwoPossiblePathsRandomised()
        {
            // change data
            List<IWordNode> wordpool = new List<IWordNode>
            {
                new WordNode{ Word = "Time"},
                new WordNode{ Word = "Tame"},
               new WordNode{ Word = "Dine"},
                new WordNode{ Word = "Wake"},
                new WordNode{ Word = "Wane"},
                new WordNode{ Word = "Wine"},
                
                new WordNode{ Word = "Dime"},
                 new WordNode{ Word = "Take"},
            };
            calculator.WordPool = wordpool;

            WordSequence seq = new WordSequence();
            calculator.GetPath(seq);
            Console.WriteLine(seq.ToString());
            Assert.IsTrue(seq.Length == 4, "Sequence not complete");
            Assert.IsTrue(seq.FirstWord.Word == calculator.Start.Word, "Sequence doesn;t begin with start");
            Assert.IsTrue(seq.LastWord.Word == calculator.Finish.Word, "sequence doesn;t end with finish");
        }
    }
}
