using System;

public class B {

	public /*virtual*/ void W() {
		Console.WriteLine("B::W");
	}

}

public class A : B {

	public static void M() {
		Console.WriteLine("A::M");
	}
	
	public /*override*/ void W() {
		Console.WriteLine("A::W");
	}

	public static void Main(String[] args) {
		Base b = new A();
		b.W();
		
		A a = (A) b;
		a.W();
	}
}