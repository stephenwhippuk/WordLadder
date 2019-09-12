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
            try
            {
                Console.WriteLine("\nStart Word is \"" + args[0] + "\"");
                Console.WriteLine("Finish Word is \"" + args[1] + "\"");
                Console.WriteLine("Input File Path is \"" + args[2] + "\"");
                Console.WriteLine("Output File Path is \"" + args[3] + "\"");

                Console.WriteLine("\nLoading Word Pool from input file...");
                IWordReader reader = new FileWordReader<WordNode>(args[2]);
                reader.Open();
                calculator.Load(reader);
                reader.Close();

                Console.WriteLine("Calculating Shortest Path...");
                WordSequence shortest = new WordSequence();
                calculator.GetPath(shortest);

                Console.WriteLine("Saving Results to Output File...");
                var writer = new FileWordWriter(args[3]);
                writer.Open();
                shortest.Save(writer);
                writer.Close();

                Console.WriteLine("\nThe Shortest Path From \"" + args[0] + "\" to \"" + args[1] + "\" is:");
                Console.WriteLine("[" + shortest.ToString() + "]");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
               
            }
            

           
        }
    }
}
