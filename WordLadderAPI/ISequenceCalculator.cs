using System;
using System.Collections.Generic;
using System.Text;

namespace WordLadderAPI
{
    /// <summary>
    /// A top level interface in the API, this is a the generic interface to path finding actions
    /// implement to produce specific Action classes. 
    /// </summary>
    public abstract class ISequenceCalculator
    {
        public abstract IWordNode Start { get; set; }
        public abstract IWordNode Finish { get; set; }

        public bool FixedWordLength { get; set;  }
        public  int WordLength { get; set; }

        public abstract int WordPoolSize { get; }
        /// <summary>
        ///  Conceptual Word Pool is provided using an IEnumerable collection of IWordNodes
        ///  See implementation notes in design document
        /// </summary>
        public abstract IEnumerable<IWordNode> WordPool { get; set; }
        public abstract bool Load(IWordReader reader);
        public abstract bool GetPath(IWordSequence path);
    }
}
