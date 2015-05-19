using System;
using System.Collections.Generic;
using AlgorithmsAndCollections;

namespace GenericAlgorithms_Iterators
{
    class SelectEnumerable<T, R> : IEnumerable<R>
    {
        private IEnumerable<T> input;
        private Func<T, R> projection;

        public SelectEnumerable(IEnumerable<T> input, Func<T, R> projection)
        {
            this.input = input;
            this.projection = projection;
        }

        public IEnumerator<R> GetEnumerator()
        {
            return new SelectEnumerator<T, R>(input, projection);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
