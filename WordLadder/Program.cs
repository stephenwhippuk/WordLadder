using System;
using System.Collections.Generic;
using WordLadderAPI;

namespace WordLadder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Blue Prism Technical Assessment Application");

            WordNode first = new WordNode { Word = args[0] };
            WordNode last = new WordNode { Word = args[1] };

            List<IWordNode> pool = new List<IWordNode>();

            ShortestSequenceCalculator<WordSequence, List<IWordNode>> calculator = new ShortestSequenceCalculator<WordSequence, List<IWordNode>> { Start = first, Finish = last, WordPool = pool };
            IWordReader reader = new FileWordReader<WordNode>(args[2]);
            reader.Open();
            calculator.Load(reader);

            WordSequence shortest = new WordSequence();
            calculator.GetPath(shortest);

            var writer = new FileWordWriter(args[3]);
            writer.Open();
            shortest.Save(writer);
            writer.Close();
        }
    }
}
