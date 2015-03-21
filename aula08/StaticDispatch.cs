using System;

public struct A {

	static void StaticMethod() {
	
	}
	
	void InstanceMethod() {
	
	}

	public static void Main(String[] args) {
		A a = new A();
		
		A.StaticMethod();
	
		a.InstanceMethod();
	}
}