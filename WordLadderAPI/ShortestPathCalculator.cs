using System;
using System.Collections.Generic;
using System.Text;

namespace WordLadderAPI
{
    public class ShortestSequenceCalculator<T, T2> : ISequenceCalculator 
        where T: IWordSequence, new( ) 
        where T2: ICollection<IWordNode> , new()
    {

        // field variables for persistence during recursion
        private IWordSequence shortest;
        bool seqFound;

        T2 mWordPool;
        IWordNode mStart;
        IWordNode mFinish;

        public override IWordNode Start { get => mStart; set => mStart = value; }
        public override IWordNode Finish { get => mFinish; set => mFinish=value; }

/// <summary>
/// there is an additional type constraint here in order to allow for This class to load into WordPool
/// ideally this probably needs refactoring to make this cleaner. 
/// </summary>
        public override IEnumerable<IWordNode> WordPool
        {
            get => (IEnumerable<IWordNode>) mWordPool;
            set => mWordPool = (T2) value;
        }

        public override int WordPoolSize => mWordPool.Count;

        // private enumeration to make clear return values 
        private enum return_val { DONE, CONTINUE};

        private return_val find_path(IWordNode next, IWordNode end, IWordSequence seq)
        {
            // trivially reject if path would be longer than existing path
            if (seqFound && seq.Length >= shortest.Length)
            {
                
                return return_val.DONE;
            }
            // valid sequence is found which must be shorter than any already found
            else if (next.Word == end.Word)
            {
              
                seq.Append(next);

                // copy rather than simply use assignment and new as we don't know type of shortest and this object was provided for us
                shortest.Copy(seq);
                seq.Pop();
                seqFound = true;
                return return_val.DONE;
            }
            // find next possible steps
            else
            {                
                foreach (var word in WordPool)
                {
                    
                    if (word.isStepAway(next) && !seq.Contains(word))
                    {
                        // TODO: Work out why Logical Design with append and pop called outside of loop
                        // was failing, for now this works if a less efficient solution.
                        
                        // Add next to seq before moving in
                        seq.Append(next);

                        // recursively call to move in
                        return_val ret = find_path(word, end, seq);

                        // remove next from seq before next iteration
                        seq.Pop();

                        // if path was accepted or rejected by length then exit foreach to step back a recursion level
                        // reasoning, if next was trivially rejected the all possible nexts will be
                        // if next was the end then no shorter path could be found and thus all would be trivailly rejected 
                        // or same path, if Finish is not unique in WordPool.
                        if (ret == return_val.DONE)
                        {
                            break;
                        }
                    }
                }

            }
            return return_val.CONTINUE;
        }

        public ShortestSequenceCalculator()
        {
            mWordPool = new T2();
            mStart = null;
            mFinish = null;
            seqFound = false;
        }

        public override bool GetPath(IWordSequence path)
        {
            
            bool startFound = false, finishFound = false;
            // first test to see that words in dictionary
            foreach (var w in WordPool)
            {
                if (w.Word == Start.Word)
                {
                    startFound = true;
                }
                if (w.Word == Finish.Word)
                {
                    finishFound = true;
                }

            }
            if (startFound && finishFound)
            {
                // providind words are in WOrdPool we can run our search
                // We wil allow our shortestpath to be a reference to an object passed in IOC
                shortest = path;
                seqFound = false;

                // our possible sequence has to be created here using provided generic type parameter
                T seq = new T();

                // start recursive DFS to find shortest path
                find_path(this.Start, this.Finish, seq);

                return seqFound;
            }
            else if (!startFound)
            {
                throw new InvalidOperationException("Start Word is not WordPool");
            }
            else
            {
                throw new InvalidOperationException("Finish Word is not WordPool");
            }
            
        }

        public override bool Load(IWordReader reader)
        {
            if (reader.IsOpen)
            {
                mWordPool.Clear();
                while (!reader.AtEnd)
                {
                    IWordNode tmp = reader.Next();
                    if (FixedWordLength && tmp.Word.Length != WordLength)
                    {
                        continue;
                    }
                    else
                    {
                        if (tmp.IsWord())
                        {
                            mWordPool.Add(tmp);
                        }
                    }
                }
                return true;
            }
            return false;
        }
    }
}
