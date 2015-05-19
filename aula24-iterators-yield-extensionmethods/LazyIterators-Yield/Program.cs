using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyIterators_Yield
{
    class Program
    {
        struct Student
        {
            public int Number { get; set; }
            public String Name { get; set; }
            public double CurrAverage { get; set; }
            public override string ToString()
            {
                return String.Format("[ Number={0} Name={1} CurrAverage={2}]", Number, Name, CurrAverage);
            }
        }

        public static IEnumerable<E> Skip<E>(IEnumerable<E> input, Func<E, bool> predicate)
        {
            foreach (E e in input)
            {
                if (!predicate(e))
                    yield return e;
            }
        }

        public static IEnumerable<int> BetweenRange(int begin, int end)
        {
            for (int i = begin; i <= end; ++i)
            {
                yield return i;
            }
        }

        public static IEnumerable<int> ThreeValues()
        {
            yield return 0;
            yield return 1;
            yield return 2;
        }

        static void Main(string[] args)
        {
        }
    }
}
