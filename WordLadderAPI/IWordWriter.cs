using System;
using System.Collections.Generic;
using System.Text;

namespace WordLadderAPI
{
    public abstract class IWordWriter
    {
        // true if open ran successfully
        public bool IsOpen { get; set; }

        /// <summary>
        /// WordWriter Writes Words one at a time to stream
        /// </summary>
        public abstract void Write(IWordNode w);

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
