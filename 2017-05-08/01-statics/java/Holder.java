import java.util.*;

public class Holder<T> {
	
	private static Map<Class, Object> lastValues = new HashMap<>();
	
	private Class<T> myType;
	private T val;

	@SuppressWarnings("unchecked")
	private Holder(Class<T> type) {
		myType = type;
		val = (T)lastValues.get(type);
	}

	public static <E> Holder<E> create(Class<E> type) { return new Holder<>(type); }

	public T getItem() { return val; }
	public void setItem(T value) { lastValues.put(myType, val = value); }

	public static void main(String[] args) {
		
		Holder<Integer> hi01 = Holder.create(Integer.class);
		hi01.setItem(8);
		
		Holder<String> hs01 = Holder.create(String.class);
		hs01.setItem("alpha");
		
		Holder<Integer> hi02 = Holder.create(Integer.class);
		Holder<String>  hs02 = Holder.create(String.class);
		
		System.out.println("hi02: " + hi02.getItem());
		System.out.println("hs02: " + hs02.getItem());
	}
}

