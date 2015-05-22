using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GCDemo_3
{
    class Program
    {

        const int NUMBER_OF_ALLOCATIONS = 1024 * 1024, BUFFER_SIZE = 10;
        //struct A { long field; public A(int i) { field = i; } }

        
        class A { 
            long field = 1; 
            public A(int i) {
                field = i;
            } 
            ~A() { }
        }
        

        static void Main(string[] args)
        {
            A[] buffer = new A[BUFFER_SIZE];
            for (int pos = 0, i = 0; i < NUMBER_OF_ALLOCATIONS; ++i)
            {
                buffer[pos] = new A(1);
                pos = (pos + 1) % BUFFER_SIZE;
            }
            Console.WriteLine("Collections @ 0,1,2 = {0}, {1}, {2}",
                GC.CollectionCount(0),
                GC.CollectionCount(1), 
                GC.CollectionCount(2));
        }
    }
}
