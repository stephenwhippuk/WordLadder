using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WordLadderAPI
{
    /// <summary>
    /// Class to load strings from a text file... it assumes one string per line
    /// It uses a generic type argument to allow it to intantiate wordnodes without dependency on concrete type
    /// </summary>
    public class FileWordReader<T> : IWordReader where T: IWordNode, new()
    {
        private StreamReader mFile;

        public FileWordReader(string fname)
        {
            mFile = new StreamReader(fname);
        }

        public override IWordNode Next()
        {
            // attempt to read a node if stream is open and not at EOF
            if (IsOpen && !AtEnd)
            {
                // read string from file (note 1 string per line in data file)
                string read = mFile.ReadLine();

                // create a wordnode to hold it and store, note use of Generic remove dependency on concrete type 
                T myWord = new T();
                myWord.Word = read;

                // determine if at end of file.
                if (mFile.EndOfStream)
                {
                    AtEnd = true;
                }

                // return the created word
                return myWord;
            }
            else
            {
                // returns NULL if the stream is closed or at EOF
                return null;
            }
        }

        public override bool Open()
        {
            IsOpen = true;
            // file opened by constructor but cannot be accessed until  this is called to maintain
            // behaviour pattern of IWordReader
            return true;
        }

        public override void Close()
        {
            mFile.Close();
            IsOpen = false;
        }
    }
}
