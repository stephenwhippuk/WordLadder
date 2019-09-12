using System;
using System.Collections.Generic;
using System.Text;

namespace WordLadderAPI.Tests
{
    public class WordNode_Stub_Fail : IWordNode
    {
        public override bool isStepAway(IWordNode node)
        {
            return false;
        }

        public override bool IsWord(string word = null)
        {
            return false;
        }
    }
}
