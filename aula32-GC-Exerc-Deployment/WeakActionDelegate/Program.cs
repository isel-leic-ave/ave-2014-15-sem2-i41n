using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeakActionDelegateExample
{
    class PrettyPrint<T>
    {
        String prefix;
        public PrettyPrint(String prefix)
        {
            this.prefix = prefix;
        }
        public void Print(T t)
        {
            Console.WriteLine("{0} {1}", prefix, t);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PrettyPrint<int> print = new PrettyPrint<int>("***");
            Action<int> a = new Action<int>(print.Print);
            WeakActionDelegate<int> wad = new WeakActionDelegate<int>(a);

            GC.AddMemoryPressure(1024 * 1024 * 5);
            wad.Debug();

            print.ToString();
        }

    }
}
