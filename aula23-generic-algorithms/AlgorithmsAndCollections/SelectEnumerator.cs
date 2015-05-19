using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmsAndCollections
{
    class SelectEnumerator<T, R> : IEnumerator<R>
    {
        private Func<T, R> projection;
        private IEnumerator<T> input;
        private R current;

        public SelectEnumerator(IEnumerable<T> input, Func<T,R> projection) {
            this.input = input.GetEnumerator();
            this.projection = projection;
        }

        public R Current
        {
            get { return current; }
        }

        public bool MoveNext()
        {
            if (input.MoveNext())
            {
                current = projection(input.Current);
                return true;
            }
            return false;
        }

        public void Dispose()
        {
            
        }

        object System.Collections.IEnumerator.Current
        {
            get { return current; }
        }


        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
