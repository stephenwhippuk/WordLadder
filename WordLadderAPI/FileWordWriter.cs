﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace WordLadderAPI
{
    public class FileWordWriter : IWordWriter
    {
        private StreamWriter streamWriter;

        int _numwrites; 

        public FileWordWriter(string fname)
        {
            streamWriter = new StreamWriter(fname);
            _numwrites = 0;
        }

        public override void Write(IWordNode w)
        {
            if (IsOpen)
            {
                streamWriter.WriteLine(w.Word);
                _numwrites++;
            }
            else
            {
                throw new InvalidOperationException("Error: Stream is Closed");
            }
        }

        public override bool Open()
        {
            IsOpen = true;
            return true;
        }

        public override void Close()
        {
            IsOpen = false;
            streamWriter.Close();
        }
        public int _testGetNumWrites()
        {
            return _numwrites;
        }
    }
}
