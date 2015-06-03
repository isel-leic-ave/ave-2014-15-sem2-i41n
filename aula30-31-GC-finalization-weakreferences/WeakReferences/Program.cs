using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WeakReferences
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Object o = new object();
            WeakReference wr = new WeakReference(o);

            o = null;
            GC.Collect();

            Console.WriteLine("Target=<{0}> alive=<{1}>", wr.Target, wr.IsAlive);
        }
    }
}
