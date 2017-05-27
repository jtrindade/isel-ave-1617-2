using System;
using System.Collections.Generic;

class A {}

class B : A {}

class C : B {}


class ArraysVariance
{
    public static void ShowBs(B[] bbs)
    {
        foreach (B obj in bbs) 
        {
            Console.Write("{0} ", obj.GetType().Name);
        }
        Console.WriteLine();
    }
    
    public static void ReplaceB(B[] bbs, B aNewB)
    {
        Console.WriteLine("Replacing {0} with {1} ",
            bbs[0].GetType().Name,
            aNewB.GetType().Name);
        
        bbs[0] = aNewB;
    }

}

class GenericsInvariance
{
    public static void ShowListOfBs(List<B> bbs)
    {
        foreach (B obj in bbs) 
        {
            Console.Write("{0} ", obj.GetType().Name);
        }
        Console.WriteLine();
    }
}

class OverridesInvariance
{
    class Base
    {
        public virtual B oper() { return new B(); }
    }

    class Derived : Base
    {
        public override B oper() { return new C(); }
    }
}

class DelegatesVariance
{
	public delegate B SupplyB();
	public delegate void ConsumeB(B obj);

	// Methods possibly compatible with SupplyB
    public static A makeA() { return new A(); } // !!! Not a SupplyB   
    public static B makeB() { return new B(); }    
    public static C makeC() { return new C(); }    
    
	// Methods possibly compatible with ConsumeB
    public static void PrintA(A obj) { Console.WriteLine("A: {0} ", obj.GetType().Name); }    
    public static void PrintB(B obj) { Console.WriteLine("B: {0} ", obj.GetType().Name); }    
    public static void PrintC(C obj) { Console.WriteLine("C: {0} ", obj.GetType().Name); } // !!! Not a ConsumeB

    public static void CreateAndShow(SupplyB supply)
    {
        B aNewB = supply();
        Console.WriteLine("{0}", aNewB.GetType().Name);
    }
    
    public static void CallConsumeB(ConsumeB consume, B someB)
    {
        consume(someB);
    }

}

class Variance
{
    static void Main()
    {
        B[] data1 = new B[] { new B(), new B(), new B() };
        B[] data2 = new B[] { new C(), new B(), new C() };
        C[] data3 = new C[] { new C(), new C(), new C() };
        
        List<B> list1 = new List<B>(data1);
        // List<B> list2 = new List<C>(data3); // List<C> is not a List<B>
        List<C> list3 = new List<C>(data3);
        
        ArraysVariance.ShowBs(data1);
        ArraysVariance.ShowBs(data2);
        ArraysVariance.ShowBs(data3); // C[] is a B[] (for reading)
 
		Console.WriteLine();
        
        ArraysVariance.ReplaceB(data1, new B());
        ArraysVariance.ReplaceB(data1, new C());
        ArraysVariance.ReplaceB(data3, new C());
        try
        {
            ArraysVariance.ReplaceB(data3, new B()); // C[] is not a B[] for writing
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }    
 
		Console.WriteLine();
    
        GenericsInvariance.ShowListOfBs(list1);
        // GenericsInvariance.ShowListOfBs(list3); // List<C> is not a List<B>
 
		Console.WriteLine();

        // DelegatesVariance.CreateAndShow(DelegatesVariance.makeA);
        DelegatesVariance.CreateAndShow(DelegatesVariance.makeB);
        DelegatesVariance.CreateAndShow(DelegatesVariance.makeC);
 
		Console.WriteLine();

        DelegatesVariance.CallConsumeB(DelegatesVariance.PrintA, new C());
        DelegatesVariance.CallConsumeB(DelegatesVariance.PrintB, new C());
        //DelegatesVariance.CallConsumeB(DelegatesVariance.PrintC, new B());
		
	}
}
