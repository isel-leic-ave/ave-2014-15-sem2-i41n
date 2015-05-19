using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tpc_14
{
    class BetweenRangeEnumerable : IEnumerable<int>
    {
        private int begin, end;

        public BetweenRangeEnumerable(int begin, int end)
        {
            this.begin = begin;
            this.end = end;
        }


        public IEnumerator<int> GetEnumerator()
        {
            return new BetweenRangeEnumerator(begin, end);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
