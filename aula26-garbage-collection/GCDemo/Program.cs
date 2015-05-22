using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace GCDemo_2
{
    interface ITest { }

    class Test2 : ITest
    {
        int val;
        ~Test2() {  }
    }

    class Test1 : ITest
    {
        int val;
    }

    public class Tester
    {
        const int TestSize = 1000000;
        static void Test(string name, Type t)
        {
            ITest[] objects = new ITest[TestSize];
            DateTime ti = DateTime.Now;
            for (int i = 0; i < TestSize; i++)
            {
                objects[i] = t == typeof(Test1) ? (ITest)(new Test1()) : (ITest)(new Test2());
            }
            Console.WriteLine("{0}-A ao fim de {1}ms",
                              name, (DateTime.Now - ti).TotalMilliseconds);
            objects = null;
            GC.Collect();
            Console.WriteLine("{0}-B ao fim de {1}ms",
                             name, (DateTime.Now - ti).TotalMilliseconds);

            GC.Collect();
            Console.WriteLine("{0}-C ao fim de {1}ms",
                            name, (DateTime.Now - ti).TotalMilliseconds);
        }

        static void Main(string[] args)
        {
            Test("Test1", typeof(Test1));
            Test("Test2", typeof(Test2));
        }
    }
}
