using System;
using System.Linq;
using System.Reflection;

public class DontLogAttribute : Attribute {}

public class LevelAttribute : Attribute {
	public int Level { get;	private set; }
	public LevelAttribute(int level) { this.Level = level; }
}

public static class Logger 
{
	public const BindingFlags ALL_INSTANCE = 
		BindingFlags.Instance | 
		BindingFlags.FlattenHierarchy |
		BindingFlags.NonPublic |
		BindingFlags.Public;
	
	public static void Log(Object obj, int level)
	{
		Console.WriteLine("LOG of {0}", obj.GetType().Name);
		foreach (FieldInfo fi in obj.GetType().GetTypeInfo().GetFields(ALL_INSTANCE)) {
			if (!fi.IsDefined(typeof(DontLogAttribute), false)) {
				Attribute[] attrs = fi.GetCustomAttributes(typeof(LevelAttribute), false).ToArray();
				if (attrs.Length == 0 || ((LevelAttribute) attrs[0]).Level <= level) { 
					Console.WriteLine("    {0} : {1}", fi.Name, fi.GetValue(obj));
				}
			}
		}
	}
}

public class Info 
{
	public int a;

	public int b;

	[Level(3)]
	public int c;

	[DontLog]
	public int d;
	
	public Info(int a, int b, int c, int d) 
	{
		this.a = a; this.b = b; this.c = c; this.d = d;
	}
}

public class User
{
	[Level(1)]
	private string username;
	
	[DontLog]
	private string password;
	
	private string name;
	
	public User(string uname, string passwd, string fullname) {
		username = uname; password = passwd; name = fullname;
	}
}

public class Logs 
{
	public static void Main()
	{
		Info info = new Info(1, 2, 3, 4);
		User user = new User("jtrindade", "1234", "Joao Trindade");

		Logger.Log(info, 2);
		Logger.Log(user, 2);
	}
}
