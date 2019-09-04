using System;

namespace WordLadderAPI
{
    public abstract class IWordSequence
    {
        public int Length { get; set; }

        public abstract override string ToString() ;
    }
}
