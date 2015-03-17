using System;

public class A {
	int y = 20;
	
	public override bool Equals(Object o) {
		if (o==null)
			return false;
		A tmp = o as A;
		return tmp == null? false : tmp.y == y;
	}	
	
	public override int GetHashCode() {
		return y;
	}
}

public class B : A {
	int x = 10;
	
	public override bool Equals(Object o) {
		if (!base.Equals(o))
			return false;
		B tmp = o as B;
		return tmp == null? false : tmp.x == x;
	}
	
	public override int GetHashCode() {
		return base.GetHashCode() ^ x;
	}
}

public class AB { 

	public static void Main(String[] args) {
		B b = new B();
		A a = new A();
		Console.WriteLine(a.Equals(a));
		Console.WriteLine(a.Equals(b));
		Console.WriteLine(b.Equals(a));
	}

}