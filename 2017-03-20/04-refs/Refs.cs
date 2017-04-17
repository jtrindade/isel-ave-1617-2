using System;

class Refs
{
	static void Oper(ref int val, out int res)
	{
		val += 3;
		res = 9;
	}
	
	static void Main()
	{
		int x = 88;
		int y;
		
		Oper(ref x, out y);
		
		Console.WriteLine(x);
		Console.WriteLine(y);
	}
}
