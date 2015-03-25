
class Program {
	static Program() {
		System.Console.WriteLine("Program");
	}

	static void Main() {
	  new A().M1(null, new C());
	 
	}
}
class A { 
	
	static A() {
		System.Console.WriteLine("A");
	}

	public void M1(B b, C c) { c.M3(); } 
	
}

class B { 
	static B() {
		System.Console.WriteLine("B");
	}

	public void M2() { } 
	
}


class C { 

	static C() {
		System.Console.WriteLine("C");
	}

	public void M3() { D.M4(); } 
}

class D {

	static D() {
		System.Console.WriteLine("D");
	}

	public static void M4() { }
	public static void M5(E e) { }
}

class E { 
	static E() {
		System.Console.WriteLine("E");
	}
	
	public static void M6() { } 

}