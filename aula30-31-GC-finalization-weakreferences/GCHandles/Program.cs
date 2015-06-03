using System;
using System.Runtime.InteropServices;

namespace GCHandles
{
    class Program
    {
        static void Main(string[] args)
        {
            Object o = new object();
            GCHandle handle = GCHandle.Alloc(o, GCHandleType.Weak);

            o = null;
            GC.Collect();

            Console.WriteLine("Target=<{0}>", handle.Target);
        }
    }
}
