using System;

struct Point
{
	public int x;
	public int y;
	
	public Point(int a, int b) { x = a; y = b; }
	
	public static bool operator ==(Point p1, Point p2)
	{
		Console.WriteLine("Comparing Points for ==");
		return p1.x == p2.x && p1.y == p2.y;
	}
	
	public static bool operator !=(Point p1, Point p2)
	{
		Console.WriteLine("Comparing Points for !=");
		return !(p1 == p2);
	}
	
	public override bool Equals(object other)
	{
		if (Object.ReferenceEquals(this, other) {
			return true;
		}
		if (!(other is Point)) {
			return false;
		}
		return this == (Point)other;
	}
	
	public bool Equals(Point other)
	{
		return this == other;
	}
	
	public override int GetHashCode()
	{
		return x.GetHashCode() ^ y.GetHashCode();
	}
}

class IdEq 
{
	static void Main()
	{
		string s1 = "ave";
		string s2 = "cave";
		string s3 = s2.Substring(1);
		
		Console.WriteLine("s1 == s3 : {0}", s1 == s3);
		
		Console.WriteLine(
			"Object.ReferenceEquals(s1, s3) : {0}",
			Object.ReferenceEquals(s1, s3)
		);

		Console.WriteLine(
			"s1.Equals(s3) : {0}",
			s1.Equals(s3)
		);
		
		object o1 = s1;
		object o3 = s3;
		
		Console.WriteLine("o1 == o3 : {0}", o1 == o3);
		
		// ==================
		
		Point p1 = new Point(3, 4);
		Point p2 = new Point(3, 4);
		Point p3 = new Point(4, 5);
		
		Console.WriteLine(
			"Object.ReferenceEquals(p1, p2) : {0}",
			Object.ReferenceEquals(p1, p2)
		);
		
		Console.WriteLine("p1.Equals(p2) : {0}", p1.Equals(p2));
		
		Console.WriteLine("p1 == p2 : {0}", p1 == p2);
		Console.WriteLine("p2 == p3 : {0}", p2 == p3);
		
	}
}
