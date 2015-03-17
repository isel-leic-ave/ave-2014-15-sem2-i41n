using System;

public struct V {
	public object other;
	public int i;
	public V(int i) { 
		this.i = i; 
		this.other = null; 
	}
	public override string ToString() {   
		Console.WriteLine("In tostring");
		return String.Format("i={0}", i);  
	}
}

public struct U {
	public object other;
	public int i;
}

class Program {
	static Object o;

	private static V BoxV() {
		V v = new V(10);
		v.other = v;
		o = v.other;
		v.i++;
		Console.WriteLine("{0}", (object)(v.other));
		U u = (U) v.other;
		return (V) v.other;
	}
	
	public static void Main(string[] args) {
		BoxV();
		
		Console.WriteLine(o);
		
	}
}
