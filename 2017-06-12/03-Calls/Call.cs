using System;

class RefBase
{
	public void NonVirtual_OnReferenceType() {}
	public virtual void Virtual_OnReferenceType() {}
}

class RefDerived : RefBase
{
	public void OtherNonVirtual_OnReferenceType()
	{
		NonVirtual_OnReferenceType();
	}
	
	public override void Virtual_OnReferenceType()
	{
		base.Virtual_OnReferenceType();
	}
}

struct Val
{
	public void NonVirtual_OnValueType() {}

	public override String ToString() { return "Val"; }
}

class Call
{
	static void Main()
	{
		RefBase    rb = new RefBase();
		RefDerived rd = new RefDerived();
		
		Val v = new Val();
		
		rb.NonVirtual_OnReferenceType();
		rb.Virtual_OnReferenceType();
		
		rd.NonVirtual_OnReferenceType();
		rd.Virtual_OnReferenceType();
		
		v.NonVirtual_OnValueType();
		v.ToString();
	}
}
