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
        public IWordNode Start { get; set; }
        public IWordNode Finish { get; set; }
        public IEnumerable<IWordNode> WordPool { get; set; }
        public abstract bool Load(IWordReader reader);
        public abstract bool GetPath(IWordSequence path);
    }
}
