using System;
using System.Reflection;

class Pair
{
	class UselessType 
	{
		public int x;
	}
	
	int first;
	int second;

	public Pair(int a, int b)
	{
		first = a;
		second = b;
	}
	
	public int GetFirst()  { return first; }
	public int GetSecond() { return second; }
	
	public int First
	{
		get { return first; }
		set { first = value; }
	}
	
	public int Second
	{
		get { return second; }
		set { second = value; }
	}
	
	// Indexer
	public int this[int idx]
	{
		get 
		{
			if (idx > 1) throw new IndexOutOfRangeException();
			return idx == 0 ? first : second;
		}
		set
		{
			switch (idx)
			{
				case 0: first  = value; break;
				case 1: second = value; break;
				default: throw new IndexOutOfRangeException();
			}
		}
	}
	
	public static void Explore(object obj)
	{
		TypeInfo ti = obj.GetType().GetTypeInfo();
		
		Console.WriteLine();
		Console.WriteLine("Methods of {0}", ti.FullName);
		foreach (MethodInfo mi in ti.GetMethods())
		{
			Console.WriteLine(mi.Name);
		}
	}
	
	static void Main()
	{
		Console.WriteLine("Hello, AVE!");
		
		Pair p1 = new Pair(2, 3);
		Console.WriteLine("({0}, {1})", p1.First, p1.Second);
		p1.First = 5;
		Console.WriteLine("({0}, {1})", p1.GetFirst(), p1.GetSecond());
		p1[1] = 7;
		Console.WriteLine("({0}, {1})", p1[0], p1[1]);
		
		Explore(p1);
	}
}
