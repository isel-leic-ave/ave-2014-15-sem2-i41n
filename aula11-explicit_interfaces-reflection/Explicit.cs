using System;

interface IOne {
	void M();
}

interface ITwo {
	void M();
}

class A : IOne, ITwo {

	void IOne.M()
	{
		Console.WriteLine("Explicit IOne.M()");
	}

	void ITwo.M()
	{
		Console.WriteLine("Explicit ITwo.M()");
	}
	
/*
	public virtual void M() 
	{
		Console.WriteLine("Implicit A.M()");
	}
*/
	public static void Main() {
		A a = new A();
		//a.M();
		((IOne)a).M();
		((ITwo)a).M();
	}
}