/*
 * Code in "CLR via C#" book
 */
 
using System;
using System.Collections;

public static class Program {
   public static void Main(string[] args) {
      ArrayList a = new ArrayList();
      Point p;            // Allocate a Point (not in the heap).
      for (Int32 i = 0; i < 10; i++) {
         p.x = p.y = i;   // Initialize the members in the value type.
         a.Add(p);        // Box the value type and add the
                          // reference to the Arraylist.
      }
   }

   // Declare a value type.
   private struct Point {
      public Int32 x, y;
   }

   public static void Main2() {
      Int32 x = 5;
      Object o = x;         // Box x; o refers to the boxed object
      Int16 y = (Int16)o;   // Throws an InvalidCastException
   }

   public static void Main3() {
      Int32 x = 5;
      Object o = x;                // Box x; o refers to the boxed object
      Int16 y = (Int16)(Int32)o;   // Unbox to the correct type and cast
   }

   public static void Main4() {
      Point p;
      p.x = p.y = 1;
      Object o = p;   // Boxes p; o refers to the boxed instance

      p = (Point)o;  // Unboxes o AND copies fields from boxed 
      // instance to stack variable
   }

   public static void Main5() {
      Point p;
      p.x = p.y = 1;
      Object o = p;   // Boxes p; o refers to the boxed instance

      // Change Point’s x field to 2
      p = (Point)o;  // Unboxes o AND copies fields from boxed 
      // instance to stack variable
      p.x = 2;        // Changes the state of the stack variable
      o = p;          // Boxes p; o refers to a new boxed instance
   }

   public static void Main6() {
      Int32 v = 5;            // Create an unboxed value type variable.
      Object o = v;            // o refers to a boxed Int32 containing 5.
      v = 123;                 // Changes the unboxed value to 123

      Console.WriteLine(v + ", " + (Int32)o);	// Displays "123, 5"
   }
   
   public static void Main7() {
      Int32 v = 5;                // Create an unboxed value type variable.
      Object o = v;               // o refers to the boxed version of v.

      v = 123;                    // Changes the unboxed value type to 123
      Console.WriteLine(v);       // Displays "123"

      v = (Int32)o;              // Unboxes and copies o into v
      Console.WriteLine(v);       // Displays "5"
   }

   public static void Main8() {
      Int32 v = 5;   // Create an unboxed value type variable.

#if INEFFICIENT
   // When compiling the following line, v is boxed 
   // three times, wasting time and memory.
   Console.WriteLine("{0}, {1}, {2}", v, v, v);
#else
      // The lines below have the same result, execute
      // much faster, and use less memory.
      Object o = v;  // Manually box v (just once).

      // No boxing occurs to compile the following line.
      Console.WriteLine("{0}, {1}, {2}", o, o, o);
#endif
   }
}
