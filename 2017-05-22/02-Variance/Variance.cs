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

class Variance
{
    static void Main()
    {
        B[] data1 = new B[] { new B(), new B(), new B() };
        B[] data2 = new B[] { new C(), new B(), new C() };
        C[] data3 = new C[] { new C(), new C(), new C() };
        
        List<B> list1 = new List<B>(data1);
        // List<B> list2 = new List<C>(data3); 
        List<C> list3 = new List<C>(data3);
        
        ArraysVariance.ShowBs(data1);
        ArraysVariance.ShowBs(data2);
        ArraysVariance.ShowBs(data3);
        
        ArraysVariance.ReplaceB(data1, new B());
        ArraysVariance.ReplaceB(data1, new C());
        ArraysVariance.ReplaceB(data3, new C());
        try
        {
            ArraysVariance.ReplaceB(data3, new B());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }    
    
        GenericsInvariance.ShowListOfBs(list1);
        //GenericsInvariance.ShowListOfBs(list3);

	}
}
