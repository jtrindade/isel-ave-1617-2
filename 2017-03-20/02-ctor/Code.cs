using System;

class Base 
{
	protected int a = GetInitialA();
	protected int b;

	static int GetInitialA()
	{
		Console.WriteLine("Initializing Base.a");
		return 3;
	}
	
	public Base()
	{
		Console.WriteLine("Running Base.ctor");
		Console.WriteLine(this.ToString()); // Invoking an overriden method in the base class constructor.
		b = 5;
	}
	
	public override string ToString()
	{
		return String.Format("Base(a = {0}, b = {1})", a, b);
	}
}

class Derived : Base 
{
	int c = GetInitialC();
	int d;

	static int GetInitialC()
	{
		Console.WriteLine("Initializing Derived.c");
		return 7;
	}
	
	public Derived()
	{
		Console.WriteLine("Running Derived.ctor");
		d = 9;
	}
	
	public override string ToString()
	{
		return String.Format("Derived(a = {0}, b = {1}, c = {2}, d = {3})", a, b, c, d);
	}
}

class Code
{
	static void Main()
	{
		Derived obj = new Derived();
	}
}
