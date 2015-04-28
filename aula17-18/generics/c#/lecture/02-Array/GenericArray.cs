using System;

public static class Program {
   public static void Main() {
      // Create & initialize a byte array
      Byte[] byteArray = new Byte[] { 5, 1, 4, 2, 3 };

      // Call Byte[] sort algorithm
      Array.Sort<Byte>(byteArray);

      // Call Byte[] binary search algorithm
      Int32 i = Array.BinarySearch<Byte>(byteArray, 1);
      Console.WriteLine(i);   // Displays "0"
   }
}
