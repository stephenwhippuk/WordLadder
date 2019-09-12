using System;
using System.Collections.Generic;
using System.Text;

namespace WordLadderAPI.Tests
{
    public class WordWriter_Stub : IWordWriter
    {
        public string Output { get; set; }

        public WordWriter_Stub()
        {
            Output = "";
        }

        public override void Close()
        {
            IsOpen = false;
        }

        public override bool Open()
        {
            IsOpen = true;
            return true;
        }

        public override void Write(IWordNode w)
        {
            Output += w.Word + "\n";
        }
    }
}
