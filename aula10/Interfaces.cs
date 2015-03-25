using System;

interface I {
	void M();
}

class A : I {
    /* M() will be virtual, with or without the 'virtual' attribute */
	public /*virtual*/ void M() { Console.WriteLine("M of A"); }
	public virtual void T() { Console.WriteLine("T of A"); }
}

class B : I {
	public virtual void Z() {  }
	public virtual void W() {  }
	public void M() { Console.WriteLine("B of A"); }
}

class Program {
	
	public static void CallM(I o) {
		o.M();
	}
	
	public static void Main() {
		A a = new A();
		CallM(a);
		a.T();
		
		CallM(new B());
	}

}