using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpc_15
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            while (GC.CollectionCount(0) == 0)
            {
                new Object();
                ++counter;
            }
            Console.WriteLine("Gen 0 size is {0} bytes", counter * 8);

        }
    }
}
