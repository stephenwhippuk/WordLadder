using System;
using System.Collections.Generic;
using System.Text;

namespace WordLadderAPI
{
    public class WordSequence: IWordSequence
    {
        List<IWordNode> mData;

        public override int Length => mData.Count;

        public override IWordNode FirstWord
        {
            get
            {
                if (mData.Count != 0)
                {
                    return mData[0];
                }
                else
                {
                    return null;
                }
            }
        }

        public override IWordNode LastWord
        {
            get
            {
                if (mData.Count != 0)
                {
                    return mData[mData.Count - 1];
                }
                else
                {
                    return null;
                }
            }
            
        }

        public override IWordNode this[int i] {
            get => mData[i]; }

        public WordSequence()
        {
            mData = new List<IWordNode>();
            CheckUniqueConstraint = false;
            CheckLinkConstraint = false;
        }

        public override string ToString()
        {
            if (mData.Count > 0)
            {
                string retval = "";
                for (int i = 0; i < mData.Count-1; i++)
                {
                    retval += mData[i].Word + ", ";
                }
                retval += mData[mData.Count - 1].Word;
                return retval;
            }
            return "";
        }

        public override void Append(IWordNode node)
        {
            if (node != null)
            {
                // empty strings may not be in sequence
                if (node.Word == "")
                {
                    return;
                }
                // for efficiency we put these tests behind guards
                // and allow calling code to manage this is desired.
                if (CheckUniqueConstraint)
                {
                    
                    if(Contains(node))
                    {
                        throw new InvalidOperationException("Node being Added to Sequence is not unique");
                    }
                }
                if (CheckLinkConstraint && mData.Count > 0)
                {
                    if (!LastWord.isStepAway(node))
                    {
                        throw new InvalidOperationException("Node Being added to Sequence does not form valid Sequence");
                    }
                }
  
                mData.Add(node);
            }
        }

        public override bool Contains(IWordNode node)
        {
            foreach (var n in mData)
            {
                if (n.Word.Equals(node.Word))
                {
                    
                    return true;
                }
            }
            return false;
        }

        public override void Save(IWordWriter writer)
        {
            if (writer.IsOpen)
            {
                // write each entry
                foreach(var n in mData)
                {
                    writer.Write(n);
                }
            }
            else
            {
                // Let calling code deal with this error
                throw new InvalidOperationException("Connection is Closed");
            }
        }
        /// <summary>
        /// Copy currently only provides a shallow copy 
        /// -- this requires a way of allocating to fix it and would be a future enhancement
        /// -- for purposes of this demonstration it doesn't cause bugs
        /// </summary>
        /// <param name="node"></param>
        public override void Copy(IWordSequence node)
        {
            this.mData.Clear();
            
            for (int i = 0; i < node.Length; i++)
            {
                this.mData.Add(node[i]);   
            }

        }

        public override IWordNode Pop()
        {
            if (mData.Count > 0)
            {
                var retval = mData[mData.Count - 1];
                this.mData.RemoveAt(mData.Count - 1);
                return retval;
            }
            return null;
        }
    }
}
