using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tpc_14
{
    class BetweenRangeEnumerator : IEnumerator<int>
    {
        private int end;
        private int current;

        public BetweenRangeEnumerator(int begin, int end)
        {
            this.end = end;
            this.current = begin-1;
        }

        public int Current
        {
            get { return current; }
        }

        public void Dispose()
        {
           
        }

        object System.Collections.IEnumerator.Current
        {
            get { return current; }
        }

        public bool MoveNext()
        {
            if (current + 1 <= end) 
            {
                current = current + 1;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
