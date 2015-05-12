using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Enumerables
{
    class MyForeverEnumerator : IEnumerator<int>
    {
        private int current;

        public MyForeverEnumerator()
        {
            current = 0;
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
            current = current + 1;
            return true;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }

    class MyForeverEnumerable : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            return new MyForeverEnumerator();
        }
        
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new MyForeverEnumerator();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyForeverEnumerable seq = new MyForeverEnumerable();

            IEnumerable sequence = seq;
            IEnumerator e = sequence.GetEnumerator();
            e.MoveNext();
            int v = (int)e.Current;

            foreach (int value in seq)  // IEnumerable<int> seqFE = seq.GetEnumerator()
            {
                Console.Write("{0} ", value);  // value <- seqFE.Current;
                Thread.Sleep(100);
            }                           // if (!seqFE.MoveNext()) break;
        }



        /*
            IEnumerable sequence = seq;
            IEnumerator e = sequence.GetEnumerator();
            e.MoveNext();
            int v = (int) e.Current;
            
        */
    }
}
