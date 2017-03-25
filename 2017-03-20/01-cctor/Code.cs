using System;

class Code
{
	static void Main()
	{
		Console.WriteLine(":: Starting ::");
		
		Console.ReadLine();
		
		Console.WriteLine(":: Creating an A ::");
		A someA = new A();
		
		Console.ReadLine();
		
		Console.WriteLine(":: Creating an B ::");
		B someB = new B();
		
		Console.ReadLine();
	
		Console.WriteLine(":: Using an A ::");
		Console.WriteLine(someA);
		
		Console.ReadLine();
	
		Console.WriteLine(":: Using an B ::");
		Console.WriteLine(someB);
		
		Console.ReadLine();
	
		Console.WriteLine(":: Using an A ::");
		Console.WriteLine(someA);
		
		Console.ReadLine();
	
		Console.WriteLine(":: Using an B ::");
		Console.WriteLine(someB);
	} 
}
