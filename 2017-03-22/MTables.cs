using System;

class A {
	public virtual void oper1() {
		Console.WriteLine("A.oper1");
	}
	public virtual void oper2() {
		Console.WriteLine("A.oper2");
	}
}

class B : A {
	public sealed override void oper1() {
		Console.WriteLine("B.oper1");
	}
}

public class MTables {
	public static void Main(String[] args) {
		A a = new A();
		B b = new B();

		a.oper1();
		b.oper1();
		
		((A)b).oper1();
		
		Console.WriteLine();

		a.oper2();
		b.oper2();

		((A)b).oper2();
	}
}
