using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CountGC
{
    class Spy
    {
        static int GCCounter = 0;
        ~Spy()
        {
            Spy s = null;
            GCCounter++;
            if (!Environment.HasShutdownStarted)
                s = new Spy();
            else
                Console.WriteLine(GCCounter);
        }
    }

    class Program
    {
        class Data
        {
            byte[] b = new byte[1000];
        }
        
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            Data d; 
            for (long i = 0; i < 1024 * 1024; ++i)
            {
                d = new Data();
            }
            Console.WriteLine("GC(0) = " + GC.CollectionCount(0));
            Console.WriteLine("GC(1) = " + GC.CollectionCount(1));
            Console.WriteLine("GC(2) = " + GC.CollectionCount(2));
            GC.WaitForPendingFinalizers();
        }
    }
}
