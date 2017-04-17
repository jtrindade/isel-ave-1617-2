using System;
using System.Reflection;
using System.Reflection.Emit;

public static class GenLog
{
	public static ILog For(TypeInfo typeInfo)
	{
		string TheName = "LoggerFor" + typeInfo.Name;

		string ASM_NAME = TheName;
		string MOD_NAME = TheName;
		string TYP_NAME = TheName;

		// string DLL_NAME = TheName + ".dll";

		// Define assembly
		AssemblyBuilder asmBuilder =
			AssemblyBuilder.DefineDynamicAssembly(
				new AssemblyName(ASM_NAME),
				AssemblyBuilderAccess.Run 	// consider using: RunAndSave
			);

		// Define module in assembly
		ModuleBuilder modBuilder =
			asmBuilder.DefineDynamicModule(MOD_NAME /*, DLL_NAME */);
		
		// Define type in module
		TypeBuilder typBuilder = modBuilder.DefineType(TYP_NAME);

		// Make the type implement ILog
		typBuilder.AddInterfaceImplementation(typeof(ILog));

		// The type will have a method Log
		MethodBuilder LogMethodBuilder =
			typBuilder.DefineMethod(
				"Log",
				MethodAttributes.Public  |
				MethodAttributes.Virtual |
				MethodAttributes.ReuseSlot,
				null,
				new Type[2] { typeof(object), typeof(int) }
			);
		
		// Generate method Log
		ImplementLogMethod(LogMethodBuilder, typeInfo);

		// Create type 
		Type loggerType = typBuilder.CreateTypeInfo().AsType();

		// Save the assembly
		// asmBuilder.Save(DLL_NAME);

		// Create instance
		ILog logger = (ILog) Activator.CreateInstance(loggerType);

		// Return
		return logger; 
	}
	
	private static void ImplementLogMethod(MethodBuilder metBuilder, TypeInfo typeInfo)
	{
		ILGenerator il = metBuilder.GetILGenerator();
		
		// Console.Write("{0} {{ ", obj.GetType().Name);
		il.Emit(OpCodes.Ldstr, typeInfo.Name + " { ");
		il.Emit(OpCodes.Call,
			typeof(Console).GetTypeInfo().GetMethod(
				"Write",
				new Type[] { typeof(string) }
			)
		);

		foreach (FieldInfo fi in typeInfo.GetFields(LogOps.ALL_INSTANCE)) {
			if (LogOps.CanLog(fi)) {
				// Console.Write("{0}: {1}; ", fi.Name, fi.GetValue(obj));
				il.Emit(OpCodes.Ldstr, fi.Name + ": ???; ");
				il.Emit(OpCodes.Call,
					typeof(Console).GetTypeInfo().GetMethod(
						"Write",
						new Type[] { typeof(string) }
					)
				);
			}
		}

		// Console.WriteLine('}');
		il.Emit(OpCodes.Ldc_I4_S, '}');
		il.Emit(OpCodes.Call,
			typeof(Console).GetTypeInfo().GetMethod(
				"WriteLine",
				new Type[] { typeof(char) }
			)
		);

		il.Emit(OpCodes.Ret);
	}
}
