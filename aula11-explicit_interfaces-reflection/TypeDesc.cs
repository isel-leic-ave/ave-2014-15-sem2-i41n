using System;
using System.Reflection;

class Program {

	public void M(int v) {
		Console.WriteLine("Value is {0}", v);
	}

	public static void Main() {
		System.Console.WriteLine("in Main()");
		
		Program p1 = new Program();
		Program p2 = new Program();
		Program p3 = new Program();
		
		Type t1 = p1.GetType();
		Type t2 = p2.GetType();
		Type t3 = p3.GetType();
		
		System.Console.WriteLine(Object.ReferenceEquals(t1, t2));
		System.Console.WriteLine(Object.ReferenceEquals(t2, t3));
		
		MethodInfo mi = t1.GetMethod("M");
		System.Console.WriteLine(mi.ToString());
		
		Object param = (float)1.0;
		Console.WriteLine(param.GetType());
		mi.Invoke(p1, new Object[] { param } );
		
		System.Console.WriteLine("out of the cycle");
	}
}