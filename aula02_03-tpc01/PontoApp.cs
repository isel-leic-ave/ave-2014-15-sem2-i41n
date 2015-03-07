using System;

class PontoApp{
	static void OtherMethod() {
		Console.WriteLine("2");		
		Ponto p = new Ponto(5, 7);
		p.Print();
	}
	
	static void Main()
	{
		Console.WriteLine("1");
		OtherMethod();
	}
}