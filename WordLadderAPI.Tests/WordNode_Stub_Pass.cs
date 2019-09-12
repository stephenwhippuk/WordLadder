using System;
using System.Collections.Generic;
using System.Text;

namespace WordLadderAPI.Tests
{
    public class WordNode_Stub_Pass : IWordNode
    {
        public override bool isStepAway(IWordNode node)
        {
            return true;
        }

        public override bool IsWord(string word = null)
        {
            return true;
        }
    }
}
