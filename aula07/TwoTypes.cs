class B {

}

class A : B { 
	static A() {
		System.Console.WriteLine("This is the type constructor of A");
	}
	public int x;
	public A(int x) {
		this.x=x;
	}
}

struct S {
	public int x;
	public S(int x) {this.x=x;}
	public void M() {
		System.Console.WriteLine(x);
	}
}

public class TwoTypes {

	public static void Main() {
		A a1 = new A(100);
		S s1 = new S(200);
		S s2 = new S();
		System.Console.WriteLine("a1.x={0} s1.x={1} s2.x={2}", a1.x, s1.x, s2.x);
		
		s1.M();
	}

}