using System;

public struct CanBeNull<T> where T : struct
{
    private bool hasValue;
    private T val;
    
    public CanBeNull(T v)
    {
        hasValue = true;
        val = v;
    }
    
    public static readonly CanBeNull<T> NULL = new CanBeNull<T>();
    
    public bool HasValue
    {
        get { return hasValue; }
    }
    
    public T Value
    {
        get
        {
            if (!hasValue)
                throw new InvalidOperationException("Value is null");

            return val;
        }
    }

    public T GetValueOrDefault()
    {
        return val;
    }
    
    public T GetValueOrDefault(T def)
    {
        return hasValue ? val : def;
    }
    
    public override string ToString()
    {
        return hasValue ? val.ToString() : String.Empty;
    }
    
    public override int GetHashCode()
    {
        return hasValue ? val.GetHashCode() : 0;
    }
    
    public override bool Equals(object that)
    {
        if (that == null)
            return hasValue == false;
        
        if (!(that is CanBeNull<T>))
            return false;
        
        return Equals((CanBeNull<T>)that);
    }

    public bool Equals(CanBeNull<T> that)
    {
        if (that.hasValue != this.hasValue)
            return false;
        
        if (!hasValue)
            return true;
        
        return val.Equals(that.val);
    }
}

public class UseCanBeNull
{
    public static void Main()
    {
        CanBeNull<int> nint1 = CanBeNull<int>.NULL;
        CanBeNull<int> nint2 = new CanBeNull<int>(3);
        CanBeNull<int> nint3 = new CanBeNull<int>(5);
        
        Console.WriteLine("nint1: {0}", nint1);
        Console.WriteLine("nint2: {0}", nint2);
        Console.WriteLine("nint3: {0}", nint3);
        Console.WriteLine("nint1: {0}", nint1.GetValueOrDefault(-1));
        
        Console.WriteLine(nint1.Equals(null));
        Console.WriteLine(nint2.Equals(new CanBeNull<int>(3)));
        
        Console.WriteLine();
        
        Nullable<int> nnint1 = null;
        Nullable<int> nnint2 = new Nullable<int>(3);
        Nullable<int> nnint3 = new Nullable<int>(5);
        
        Console.WriteLine("nint1: {0}", nnint1);
        Console.WriteLine("nint2: {0}", nnint2);
        Console.WriteLine("nint3: {0}", nnint3);
        Console.WriteLine("nint1: {0}", nnint1.GetValueOrDefault(-1));
        
        Console.WriteLine(nnint1.Equals(null));
        Console.WriteLine(nnint2.Equals(new Nullable<int>(3)));
        
        Console.WriteLine();
        
        int? nnnint1 = null;
        int? nnnint2 = 3;
        int? nnnint3 = 5;
        
        Console.WriteLine("nint1: {0}", nnnint1);
        Console.WriteLine("nint2: {0}", nnnint2);
        Console.WriteLine("nint3: {0}", nnnint3);
        Console.WriteLine("nint1: {0}", nnnint1 ?? -1);
        
        Console.WriteLine(nnint1.Equals(null));
        Console.WriteLine(nnint2.Equals(3));
        
	}
}
