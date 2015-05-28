
using System;
using System.IO;


internal sealed class GCBeep {
   // This is the Finalize method
   ~GCBeep() {
      // We're being finalized, beep.
      Console.Beep(1500,500);

      // If the AppDomain isn't unloading and if the process isn’t
      // shutting down, create a new object that will get finalized 
      // at the next collection.
      if (!AppDomain.CurrentDomain.IsFinalizingForUnload() &&
          !Environment.HasShutdownStarted)
         new GCBeep();
   }
}

public sealed class Program {
   public static void Main() {
      // Constructing a single GCBeep object causes a beep to
      // occur every time a garbage collection starts.
      GCBeep a = new GCBeep();

      // Construct a lot of 100-byte objects.
      for (Int32 x = 0; x < 1000; x++) {
         Console.WriteLine(x);
         Byte[] b = new Byte[100];
      }
   }
}

