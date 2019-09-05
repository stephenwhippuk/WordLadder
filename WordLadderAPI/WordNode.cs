using System;
using System.Collections.Generic;
using System.Text;

namespace WordLadderAPI
{
    /// <summary>
    /// Default implementation of IWordNode
    /// </summary>
    public class WordNode :IWordNode
    {
        public WordNode(string word)
        {
            Word = word;
        }
        public WordNode()
        {

        }

        public override bool isStepAway(IWordNode nod)
        {
            // Trivial Rejections 

            // If words are equal then they are not 1 step away
            if (this.Word.Equals(nod.Word))
            {
                return false;
            }

            // if words differ in length the  they cannot be one step away
            if (nod.Word.Length != this.Word.Length)
            {
                return false;
            }

            // ----------------------------------------------------

            // Take to char array to access character sequence of strings
            char[] nodarray = nod.Word.ToCharArray();
            char[] thisarray = this.Word.ToCharArray();

            // loop through to calculate number of differences
            int difs = 0;
            for (int i = 0; i < this.Word.Length; i++)
            {
                if (nodarray[i] != thisarray[i])
                {
                    difs++;
                }
            }

            // function returns true iff a single difference otherwise false
            if (difs == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
