using System;

public class ImmData<T> {

	T[] data;

	public ImmData(T[] data) {
		if (data == null) throw new ArgumentException();
		this.data = data;
	}

	public int length() { return data.Length; }
	
	public T getItem(int idx) { return data[idx]; }
}

public class ImmDataMain {
	
	public static void Main(String[] args) {
		String[] strs = { "alpha", "beta", "gamma" };
		int[] ints = { 1, 2, 3 };
		
		ImmData<String> immStrs = new ImmData<String>(strs);
		ImmData<int> immInts = new ImmData<int>(ints);
		
		Console.WriteLine("str[0]: " + immStrs.getItem(0));
		
		int val = immInts.getItem(0);
		Console.WriteLine("int[0]: " + val);
	}
}
