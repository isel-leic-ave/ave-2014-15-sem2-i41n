using System;

internal sealed class GenObj
{
}

public sealed class Program
{
    public static void Main()
    {
        Console.WriteLine("Maximum generations: " + GC.MaxGeneration);

        // Create a new GenObj in the heap.
        Object o = new GenObj();

        // Because this object is newly created, it is in generation 0.
        Console.WriteLine("Gen " + GC.GetGeneration(o)); // 0

        // Performing a garbage collection promotes the object's generation.
        GC.Collect();
        Console.WriteLine("Gen " + GC.GetGeneration(o)); // 1

        GC.Collect();
        Console.WriteLine("Gen " + GC.GetGeneration(o)); // 2

        GC.Collect();
        Console.WriteLine("Gen " + GC.GetGeneration(o)); // 2 (max)
    }
}







/*

   ~GenObj() {
      Console.WriteLine("In Finalize method");
   } 
 
    Console.WriteLine("Collecting Gen 0");
    GC.Collect(0);                    // Collect generation 0.
    GC.WaitForPendingFinalizers();    // Finalize is NOT called.

    Console.WriteLine("Collecting Gen 1");
    GC.Collect(1);                    // Collect generation 1.
    GC.WaitForPendingFinalizers();    // Finalize is NOT called.

    Console.WriteLine("Collecting Gen 2");
    GC.Collect(2);                    // Same as Collect()
    GC.WaitForPendingFinalizers();    // Finalize IS called.

*/