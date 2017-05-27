using System;
using System.Reflection;
using System.Collections.Generic;

public class Gen 
{
	static void Show(Type type)
	{
		TypeInfo t = type.GetTypeInfo();

		Console.WriteLine("-----------------------------------");
		Console.WriteLine("Name: {0}", t.Name);
		Console.WriteLine("IsGeneric: {0}", t.IsGenericType);
		Console.WriteLine("IsGenericDefinition: {0}", t.IsGenericTypeDefinition);
		
		Type[] targs = t.GetGenericArguments();
		foreach (Type arg in targs) {
			TypeInfo tiarg = arg.GetTypeInfo();
			Console.WriteLine("    Arg Name: {0}", tiarg.Name);
			Console.WriteLine("    Arg IsGenericParam: {0}", tiarg.IsGenericParameter);
		}
		
		Console.WriteLine("-----------------------------------");
	}

	static void Main()
	{
		Show(typeof(Gen));
		Show(typeof(List<>));
		Show(typeof(List<int>));
		Show(typeof(List<string>));
	}
}
