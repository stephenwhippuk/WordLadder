using System;
using System.Collections.Generic;
using System.Text;

namespace WordLadderAPI
{
    /// <summary>
    /// classes to wrap the words in the ladder, providing API specific string processing
    /// </summary>
    public abstract class IWordNode
    {
        public string Word { get; set; }

        /// <summary>
        /// Primary String comparison function 
        /// </summary>
        /// <param name="node">word to be compared against</param>
        /// <returns>return true iff there is only a single step difference  </returns>
        public abstract bool isStepAway(IWordNode node);
    }
}
