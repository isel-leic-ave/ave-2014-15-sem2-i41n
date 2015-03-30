using System;

class A {

	private int i;
	public int GetI() {return i;}
	public void SetI(int v) 
	{ 
		if (v >= 0)
			i = v;
	}

	private int v;
	public int P {
		get {
			return v;
		}
		/*set {
			if (value >= 0)
				v = value;
			else
				throw new Exception("must be greater or equal to 0");
		}*/
	}

	public static void Main() {
		A a = new A();
		
		int v = a.P; // read property P
		a.P = 10; // writes property P
		a.P = -1; // writes property P
		Console.WriteLine(a.P);
		
		//TODO: B b = (B) Mapper(a, typeof(B));
	}
}