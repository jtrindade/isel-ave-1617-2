using System;

class A
{
	static String s = ProduceString();
	
	static String ProduceString()
	{
		String text = "String in A";
		Console.WriteLine("Producing: {0}", text);
		return text;
	}
	
	public override String ToString()
	{
		return s;
	}
}
