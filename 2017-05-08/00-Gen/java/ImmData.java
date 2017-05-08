public class ImmData<T> {

	T[] data;

	public ImmData(T[] data) {
		if (data == null) throw new IllegalArgumentException();
		this.data = data;
	}
	
	public int length() { return data.length; }
	
	public T getItem(int idx) { return data[idx]; }
	
	public static void main(String[] args) {
		String[] strs = { "alpha", "beta", "gamma" };
		Integer[] ints = { 1, 2, 3 };
		
		ImmData<String> immStrs = new ImmData<>(strs);
		ImmData<Integer> immInts = new ImmData<>(ints);
		
		System.out.println("str[0]: " + immStrs.getItem(0));
		
		int val = immInts.getItem(0);
		System.out.println("int[0]: " + val);
	}
}
