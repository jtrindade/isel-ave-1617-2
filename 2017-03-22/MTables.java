
class A {
	public void oper1() {
		System.out.println("A.oper1");
	}
	public void oper2() {
		System.out.println("A.oper2");
	}
}

class B extends A {
	public final void oper1() {
		System.out.println("B.oper1");
	}
}

public class MTables {
	public static void main(String[] args) {
		A a = new A();
		B b = new B();

		a.oper1();
		b.oper1();
		
		((A)b).oper1();
		
		System.out.println();

		a.oper2();
		b.oper2();

		((A)b).oper2();
	}
}
