using System;
using System.Collections.Generic;
using System.Text;

namespace WordLadderAPI.Tests
{
    public class WordReader_Stub : IWordReader
    {
        int mCount, mcur;
        WordNode_Stub_Pass[] words; 
        public WordReader_Stub()
        {
            words = new WordNode_Stub_Pass[6]
            {
                new WordNode_Stub_Pass { Word = "Time" },
                new WordNode_Stub_Pass { Word = "Tame" },
                new WordNode_Stub_Pass { Word = "Take" },
                new WordNode_Stub_Pass { Word = "Wake" },
                new WordNode_Stub_Pass { Word = "Wane" },
                new WordNode_Stub_Pass { Word = "Wine" }
            };
            mcur = 0;
            mCount = 6;
            AtEnd = false;
            IsOpen = false;
        }

        public override void Close()
        {
            IsOpen = false;
        }

        public override IWordNode Next()
        {
            if (IsOpen && !AtEnd)
            {
                IWordNode ret = words[mcur];
                mcur++;
                if (mcur == mCount)
                {
                    AtEnd = true;
                }
                return ret;
            }
            else if (!IsOpen)
            {
                throw new InvalidOperationException("Error: Connection is CLosed");
            }
            else
            {
                throw new InvalidOperationException("Error at End of File");
            }
            
        }

        public override bool Open()
        {
            IsOpen = true;
            return true;
        }
    }
}
