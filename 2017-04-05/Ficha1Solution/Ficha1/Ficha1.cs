using System;
using System.Reflection;

namespace AVE
{
    public class A {}

    public class Ficha1
    {
        public static bool IsReferenceEqualsToSelf(string x)
        {    
            return Object.ReferenceEquals(x, x);
        }

        public static bool IsReferenceEqualsToSelf(int x)
        {    
            return Object.ReferenceEquals(x, x);
        }

        public static bool ConfirmIsTypeA(A obj)
        {    
            return obj.GetType() == typeof(A);
        }

        public class X
        {
            private int count;
            public int Count
            {
                get { return count; }
                set { count = value; }
            }
            public static void None() {}
        }
        
        public static string[] GetMethodsOfX() 
        {
            MethodInfo[] methods = typeof(X).GetTypeInfo().GetMethods();
            
            string[] methodNames = new string[methods.Length];
            for (int i = 0; i < methods.Length; ++i) {
                methodNames[i] = methods[i].Name;
            }

            return methodNames;
        }

        public static bool SetPropertyFromField(object dst, string dstProp, object src, string srcFld)
        {
			// TO DO
            return false;
        }
    }
}
