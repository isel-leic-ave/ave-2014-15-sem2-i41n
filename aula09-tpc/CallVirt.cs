using System;

class A {
	public A() { /*this.M();*/ }
	public virtual void M() { Console.WriteLine("A"); }
}

class B : A {
	public B() {  }
	public override void M() { Console.WriteLine("B"); }
}

class C : B {
	public int x;
	public C() { x = 1024; }
	public new void M() { Console.WriteLine("C {0}", x); }	
	public void E() { }
	
	public override String ToString() {
		return base.ToString() + " My C";
	}
}

struct V {
	int x;
	public V(int x) { this.x=x; }
	
	public override String ToString() { return "My V"; }
}

class Program {

	public static void F(A a) {
		a.M();
	}

	
	public static void Main(String[] args) {
		A a = new C();
		a.M(); 
		
		F(a);
		
		C c = (C) a;
		c.M();
		
		V v = new V(100);
		Console.WriteLine(v.ToString());  // chamada virtual
	}
}

