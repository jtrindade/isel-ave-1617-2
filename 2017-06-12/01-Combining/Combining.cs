using System;

class Combining
{
	static void Main()
	{
		Multiple();
		Console.WriteLine("--------");
		WhichRet();
		Console.WriteLine("--------");
		Remove();
		Console.WriteLine("--------");
		RemoveOther();
		Console.WriteLine("--------");
		RemoveYetAnother();
		Console.WriteLine("--------");
	}
	
	public static void Multiple()
	{
		Action<string> a1 = str => Console.WriteLine("Action #1 : {0}", str);
		Action<string> a2 = str => Console.WriteLine("Action #2 : {0}", str);
		Action<string> a3 = str => Console.WriteLine("Action #3 : {0}", str);
		
		Action<string> a = a1 + a2 + a3;
		
		a("AVE");
	}
	
	public static void WhichRet()
	{
		Func<int> f1 = () => 3;
		Func<int> f2 = () => 5;
		
		Func<int> f3 = f1 + f2;
		
		int res = f3();
		
		Console.WriteLine(res);
	}

	public static void Remove()
	{
		Action a1 = () => Console.WriteLine("Action #1");
		Action a2 = () => Console.WriteLine("Action #2");
		Action a3 = () => Console.WriteLine("Action #3");
		Action a4 = a1 + a2 + a3;
		
		Action a = a4 - a2;

		a();
	}

	public static void RemoveOther()
	{
		Action a1 = () => Console.WriteLine("Action #1");
		Action a2 = () => Console.WriteLine("Action #2");
		Action a3 = () => Console.WriteLine("Action #3");
		Action a4 = a1 + a2 + a3;

		Action a2bis = () => Console.WriteLine("Action #2");
		
		Action a = a4 - a2bis;

		a();
	}

	public static void RemoveYetAnother()
	{
		Action a1 = () => Console.WriteLine("Action #1");
		Action a2 = Action2;
		Action a3 = () => Console.WriteLine("Action #3");
		Action a4 = a1 + a2 + a3;

		Action a2bis = Action2;
		
		Action a = a4 - a2bis;

		a();
	}

	private static void Action2()
	{
		Console.WriteLine("Action #2");
	} 
}
