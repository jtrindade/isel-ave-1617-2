using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

public static class GenLog
{
	private static readonly Dictionary<TypeInfo, ILog> loggers =
		new Dictionary<TypeInfo, ILog>();

	public static ILog For(TypeInfo typeInfo)
	{
		if (!loggers.ContainsKey(typeInfo)) {
			loggers[typeInfo] = GenerateFor(typeInfo);
		}
		return loggers[typeInfo];
	}

	private static ILog GenerateFor(TypeInfo typeInfo)
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
		Type type = typeInfo.AsType();

		ILGenerator il = metBuilder.GetILGenerator();
		LocalBuilder tobj = il.DeclareLocal(type);

		il.Emit(OpCodes.Ldarg_1);
		il.Emit(OpCodes.Castclass, type);
		il.Emit(OpCodes.Stloc, tobj);

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
				Label noLog = il.DefineLabel();
				// if (LogOps.GetLogLevel(fi) <= level)
				int defLevel = LogOps.GetLogLevel(fi);
				if (defLevel > 0) {
					il.Emit(OpCodes.Ldc_I4, defLevel);
					il.Emit(OpCodes.Ldarg_2);
					il.Emit(OpCodes.Cgt);
					il.Emit(OpCodes.Brtrue, noLog);
				}
				// Console.Write("{0}: {1}; ", fi.Name, fi.GetValue(obj));
				il.Emit(OpCodes.Ldstr, fi.Name + ": {0}; ");
				il.Emit(OpCodes.Ldloc, tobj);
				il.Emit(OpCodes.Ldfld, fi);
				if (fi.FieldType.GetTypeInfo().IsValueType) {
					il.Emit(OpCodes.Box, fi.FieldType);
				}
				il.Emit(OpCodes.Call,
					typeof(Console).GetTypeInfo().GetMethod(
						"Write",
						new Type[] { typeof(string), typeof(object) }
					)
				);
				il.MarkLabel(noLog);
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
