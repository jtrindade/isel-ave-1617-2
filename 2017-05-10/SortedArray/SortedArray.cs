using System;

public class SortedArray<T> where T : class, IComparable<T> /*, new() */
{
    private int count;
    private readonly T[] items;
    
    public SortedArray(int capacity)
    {
        items = new T[capacity];
    }
    
    public int Capacity
    {
        get { return items.Length; }
    }
    
    public int Count
    {
        get { return count; }
    }
    
    /*
    public void AddDefault()
    {
		Add(new T()); // [restriction: new()]
	}
	*/
    
    public void Add(T item)
    {
		if (item == null) // nice for references but not possible for values [restriction: class]
		{
			throw new ArgumentException();
		}
			
        int i;
        for (i = count; i > 0 && items[i-1].CompareTo(item) > 0; --i) // T must be comparable [restriction: IComparable<T>]
        {
            items[i] = items[i-1];
        }
        items[i] = item;
        count += 1;
	}
    
    public T this[int idx]
    {
        get { return items[idx]; }
    }
}

public class UseSortedArray
{
    public static void Main()
    {
        SortedArray<string> coll = new SortedArray<string>(8);
        coll.Add("LEIC");
        coll.Add("ISEL");
        coll.Add("LI41N");
        coll.Add("AVE");
        
        for (int i = 0; i < coll.Count; ++i)
        {
            Console.WriteLine("{0}: \"{1}\"", i, coll[i]);
        }
    }
}
