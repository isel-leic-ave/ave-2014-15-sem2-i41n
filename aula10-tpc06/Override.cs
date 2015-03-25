using System;

class A {
	public virtual void M() {  Console.WriteLine("A"); }
}

class B : A {
	
}

class C : B {
	public virtual void M() { Console.WriteLine("C"); }
}

class Program {
	static void Main() {
		A a = new C();
		a.M();       
		((B)a).M();
	}
}