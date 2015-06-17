using System;
using System.Reflection;
using System.Threading;


namespace StrongNames
{
    class Program
    {
        
        static void Main(string[] args)
        {

         for (; ; )
         {
            object [] o = new object[1000];
            Thread.Yield();
         }

        }
    }
}
