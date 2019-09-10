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
        }

        public override string ToString()
        {
            string retval = "";
            for (int i = 0; i < mData.Count-1; i++)
            {
                retval += mData[i].Word + ", ";
            }
            retval += mData[mData.Count - 1].Word;
            return retval;
        }

        public override void Append(IWordNode node)
        {
            if (node != null)
            {
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
                throw new InvalidOperationException();
            }
        }

        public override void Copy(IWordSequence node)
        {
            this.mData.Clear();
            for (int i = 0; i > node.Length; i++)
            {
                this.mData.Add(node[i]);
            }
        }
    }
}
