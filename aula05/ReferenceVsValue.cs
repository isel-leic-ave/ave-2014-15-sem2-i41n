/*
 * Code in "CLR via C#" book
 */

using System;

public static class Program {
   public static void Main(string[] args) {
      ValueTypeDemo();
   }

   // Reference type (because of 'class')
   class SomeRef { 
		public Int32 x; 
   }

   // Value type (because of 'struct')
   struct SomeVal { public Int32 x; }

   static void ValueTypeDemo() {
      SomeRef r1 = new SomeRef();   // Allocated in heap
      SomeVal v1 = new SomeVal();   // Allocated on stack
      r1.x = 5;                     // Pointer dereference
      v1.x = 5;                     // Changed on stack
      Console.WriteLine(r1.x);      // Displays "5"
      Console.WriteLine(v1.x);      // Also displays "5"
 
 
      SomeRef r2 = r1;              // Copies reference (pointer) only
      SomeVal v2 = v1;              // Allocate on stack & copies members
      r1.x = 8;                     // Changes r1.x and r2.x
      v1.x = 9;                     // Changes v1.x, not v2.x
      Console.WriteLine(r1.x);      // Displays "8"
      Console.WriteLine(r2.x);      // Displays "8"
      Console.WriteLine(v1.x);      // Displays "9"
      Console.WriteLine(v2.x);      // Displays "5"

   }
}
