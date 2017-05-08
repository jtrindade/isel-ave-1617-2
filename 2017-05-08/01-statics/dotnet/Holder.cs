using System;

public class Holder<T> {
	
	private static T lastValue = default(T);
	
	private T val;
	
	public Holder() {
		val = lastValue;
	}
	
	public T Item {
		get { return val; }
		set { lastValue = val = value; }
	}
}

public class HolderMain {
	
	public static void Main() {
		
		Holder<int> hi01 = new Holder<int>();
		hi01.Item = 8;
		
		Holder<string> hs01 = new Holder<string>();
		hs01.Item = "alpha";
		
		Holder<int>    hi02 = new Holder<int>();
		Holder<string> hs02 = new Holder<string>();
		
		Console.WriteLine("hi02: " + hi02.Item);
		Console.WriteLine("hs02: " + hs02.Item);
	}
}
