using System;

namespace WordLadderAPI
{
    public abstract class IWordSequence
    {
        public int Length { get; set; }

        // read only properties for first and last word in sequence
        public IWordNode FirstWord { get; }
        public IWordNode LastWord { get; }


        public abstract override string ToString() ;

        public abstract void Append(IWordNode node);

        public abstract bool Contains(IWordNode node);
    }
}
