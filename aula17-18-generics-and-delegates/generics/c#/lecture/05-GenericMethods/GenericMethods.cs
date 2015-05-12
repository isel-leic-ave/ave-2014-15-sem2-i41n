using System;

public static class Program {
   public static void Main() {
      GenericType<String> gts = new GenericType<String>("123");
      Int32 n = gts.Converter<Int32>();

      CallingSwap();
      CallingSwapUsingInference();

      Display("Jeff");           // Calls Display(String)
      Display(123);              // Calls Display<T>(T)
      Display<String>("Aidan");  // Calls Display<T>(T)
   }

   private static void Swap<T>(ref T o1, ref T o2) {
      T temp = o1;
      o1 = o2;
      o2 = temp;
   }

   private static void CallingSwap() {
      Int32 n1 = 1, n2 = 2;
      Console.WriteLine("n1={0}, n2={1}", n1, n2);
      Swap<Int32>(ref n1, ref n2);
      Console.WriteLine("n1={0}, n2={1}", n1, n2);

      String s1 = "Aidan", s2 = "Kristin";
      Console.WriteLine("s1={0}, s2={1}", s1, s2);
      Swap<String>(ref s1, ref s2);
      Console.WriteLine("s1={0}, s2={1}", s1, s2);
   }

   static void CallingSwapUsingInference() {
      Int32 n1 = 1, n2 = 2;
      Swap(ref n1, ref n2);	// Calls Swap<Int32>

      String s1 = "Aidan";
      Object s2 = "Kristin";
      // Swap(ref s1, ref s2);	// Error, type can't be inferred
   }

   private static void Display(String s) {
      Console.WriteLine(s);
   }

   private static void Display<T>(T o) {
      Display(o.ToString());  // Calls Display(String)
   }
}

internal sealed class GenericType<T> {
   private T m_value;

   public GenericType(T value) { m_value = value; }

   public TOutput Converter<TOutput>() {
      TOutput result = (TOutput)Convert.ChangeType(m_value, typeof(TOutput));
      return result;
   }
}
