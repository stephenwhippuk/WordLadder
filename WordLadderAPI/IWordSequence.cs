using System;

namespace WordLadderAPI
{
    public abstract class IWordSequence
    {
        public abstract int Length { get;}
        public abstract IWordNode this[int i] { get; }

        // read only properties for first and last word in sequence
        public abstract IWordNode FirstWord { get; }
        public abstract IWordNode LastWord { get; }


        public abstract override string ToString() ;

        public abstract void Append(IWordNode node);

        public abstract bool Contains(IWordNode node);

        public abstract void Copy(IWordSequence node);
        public abstract void Save(IWordWriter writer);

        public abstract IWordNode operator []  (int i);

    }
}
