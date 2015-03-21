using System;

public class SomeType {

	//public static int i = 10;

	/*static SomeType() {
		Console.WriteLine("I'm the type constructor");
	}*/

	public SomeType() {
		Console.WriteLine("I'm the instance constructor");
	}
	
}

public class Program {
	
	public static void Main(String[] args) {
		//Console.WriteLine(SomeType.i);
		//Console.WriteLine(SomeType.i);
		
		SomeType st2 = new SomeType();
		
		SomeType st1 = new SomeType();
	}

}