using System;

class AClass
{
	public int i=0;
}


class App {
	
	public static void Cast() {
		AClass a = new AClass();
		Object o = a;
		a = (AClass) o;	
		a = o as AClass;
		bool b = o is AClass;
	}	

	public static void Main() {
		Object o = new AClass();
		AClass e = (AClass) o;
	}
}

