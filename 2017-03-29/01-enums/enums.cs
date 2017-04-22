using System;

public enum Color { Red, Green, Blue, Yellow };

[Flags]
public enum Options { OptA = 0x01, OptB = 0x02, OptC = 0x04, OptD = 0x08 }

public class Enums 
{
	public const int FOUNDATION = 1143;
	
	public readonly long START_TIME = DateTime.Now.Ticks;

	public static void Main()
	{
		Color color = Color.Red;
		
		Options opts = Options.OptA | Options.OptC;
		
		Console.WriteLine(color);
		
		Console.WriteLine(opts);
	}
}
