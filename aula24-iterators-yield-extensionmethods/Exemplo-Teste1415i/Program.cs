using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemplo_Teste1415i
{
    static class Extensions
    {
        public static List<R> Map<T, R>(this List<T> src, Func<T, R> f)
        {
            List<R> r = new List<R>();
            foreach (T item in src)
            {
                Console.Write(item + " ");
                r.Add(f(item));
            }
            return r;
        }
        
        public static List<T> Filter<T>(this List<T> src, Func<T, bool> p)
        {
            List<T> r = new List<T>();
            foreach (T item in src)
            {
                Console.Write(item + " ");
                if (p(item)) r.Add(item);
            }
            return r;
        }

        public static IEnumerable<R> Map2<T, R>(this IEnumerable<T> src, Func<T, R> f)
        {
            foreach (T item in src)
            {
                Console.Write(item + " ");
                yield return f(item);
            }
        }

        public static IEnumerable<T> Filter2<T>(this IEnumerable<T> src, Func<T, bool> p)
        {
            foreach (T item in src)
            {
                Console.Write(item + " ");
                if (p(item))
                {
                    yield return item;
                }
            }
        }
    }
    
    class Program
    {
        static void Main()
        {
            List<int> l = new List<int> {1, 2, 3, 4, 5, 6};
            int r = l
                .Filter(n => n % 2 == 0)
                .Map(n => n + 1)
                .First();// retorna 3

            Console.WriteLine();

            r = l
                .Filter2(n => n % 2 == 0)
                .Map2(n => n + 1)
                .First();// retorna 3

            Console.WriteLine();
        }
    }
}
