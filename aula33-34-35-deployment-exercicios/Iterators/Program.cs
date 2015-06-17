using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterators
{
    static class Extensions
    {
        public static bool Exists<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (T t in source)
            {
                if (predicate(t))
                {
                    return true;
                }
            }
            return false;
        }

        
        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> source)
        {
            List<T> history = new List<T>();
            foreach (T t in source)
            {
                if (!history.Exists(x => x.Equals(t)))
                {
                    history.Add(t);
                    yield return t;
                }
            }
        }

        
        public static IEnumerable<T> Intersect<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            /*
            IEnumerable<T> firstDistinct = first.Distinct();
            foreach (T t in second) 
            {
                if (!firstDistinct.Exists(x => { return x.Equals(t); }))
                {
                    yield return t;
                }
            }
            */
            IEnumerable<T> firstDistinct = first.Distinct();
            IEnumerable<T> secondDistinct = second.Distinct();
            foreach (T t in secondDistinct) 
            {
                if (!firstDistinct.Exists(x => { return x.Equals(t); }))
                {
                    yield return t;
                }
            }
        }
    }








    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
