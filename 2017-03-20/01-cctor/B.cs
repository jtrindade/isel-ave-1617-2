using System;

class B
{
	static string s;
	
	static B()
	{
		s = ProduceString();
	}
	
	static string ProduceString()
	{
		string text = "String in B";
		Console.WriteLine("Producing: {0}", text);
		return text;
	}
	
	public override string ToString()
	{
		return s;
	}
}
