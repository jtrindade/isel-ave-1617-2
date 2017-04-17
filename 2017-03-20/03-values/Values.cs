using System;

class Values
{
	static void Main()
	{
		string val = 88.ToString();
		Console.WriteLine(val);
		ShowObj(42);
		IsSame(23, 23);
		IsSameInt(23, 23);
	}
	
	static void ShowObj(object obj)
	{
		Console.WriteLine(obj.ToString());
	}
	
	static void IsSame(object obj1, object obj2)
	{
		Console.WriteLine(obj1 == obj2 ? "Same" : "Different");
	}
	
	static void IsSameInt(object obj1, object obj2)
	{
		int i1 = (int)obj1;
		int i2 = (int)obj2;
		Console.WriteLine(i1 == i2 ? "Same" : "Different");
	}
}

