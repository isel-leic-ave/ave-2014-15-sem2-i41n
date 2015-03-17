using System;

class TypeWithEquals {
	private int aField;
	
	// ...
	
	public TypeWithEquals(int f) {
		aField = f;
	}
	
	public override bool Equals(Object obj) {
		// if base != Object must call base.Equals also
		
		if (obj == null) {
			return false;
		}
		if (obj.GetType() != this.GetType()) {
			return false;
		}
		TypeWithEquals o = (TypeWithEquals) obj;
		return o.aField == aField;
	}

	public override int GetHashCode() {
		return aField;
	}
	
	public static void Main() {
		TypeWithEquals t1 = new TypeWithEquals(10);
		TypeWithEquals t2 = new TypeWithEquals(10);
		
		Console.WriteLine(t1.Equals(t2));
		Console.WriteLine(Object.ReferenceEquals(t1, t2));
	}
}