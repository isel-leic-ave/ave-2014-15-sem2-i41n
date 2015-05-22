using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace GarbageCollector
{
    class Program
    {
        class X
        {
            private int[] i = new int[10];
        }
        static int nblocos = 1024 * 1024 * 1024;

        static void Main(string[] args)
        {
            for (; ; )
            {
                for (int j = 0; j < nblocos; ++j)
                {
                    X x = new X();
                }
                Thread.Sleep(10);
            }
        }
    }
}
