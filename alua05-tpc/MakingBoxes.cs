using System;

public struct V {
	public object other;
	public int i;
	public V(int i) { 
		this.i = i; 
		this.other = null; 
	}
	public override string ToString() {   
		return String.Format("i={0}", i);  
	}
}

class Program {
	private static V BoxV() {
		V v = new V(10);
		v.other = v;
		v.i++;
		Console.WriteLine("{0}", (object)(v.other));
		return (V) v.other;
	}
	
	public static void Main(string[] args) {
		BoxV();
	}
}
