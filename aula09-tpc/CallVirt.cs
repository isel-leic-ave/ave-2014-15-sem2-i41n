using System;

class A {
	public A() { M(); }
	public virtual void M() { Console.WriteLine("A"); }
}

class B : A {
	public B() {  }
	public override  void M() { Console.WriteLine("B"); }
}

class C : B {
	public int x;
	public C() { x = 1024; }
	public override void M() { Console.WriteLine("C {0}", x); }	
}

class Program {	
	public static void Main(String[] args) {
		A a = new C();
		a.M();
	}
}

