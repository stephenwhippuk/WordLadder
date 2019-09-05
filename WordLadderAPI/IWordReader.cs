using System;
using System.Collections.Generic;
using System.Text;

namespace WordLadderAPI
{
    /// <summary>
    /// Interface to class that reads a source of strings and wraps into WordNodes
    /// </summary>
    public abstract class IWordReader
    {
        // true if open ran successfully
        public bool IsOpen { get; set; }
        // true if EOF etc
        public bool AtEnd { get; set; }
        /// <summary>
        /// WordReader provides sequential access to the stream only. 
        /// </summary>
        /// <returns> A WordNode of a type determined elsewhere</returns>
        public abstract IWordNode Next();

        /// <summary>
        /// Open prepares the reader to read words, as reader can wrap many types
        /// of data source. It will throw any exceptions generated so this should always in in a try catch
        /// but also returns boolean for sourecs tat dont threow exceptions but never the less may fail
        /// </summary>
        /// <returns>boolean success value, for none exception throwing sources</returns>
        public abstract bool Open();
        
        // closes the datasource connection
        public abstract void Close();
    }
}
