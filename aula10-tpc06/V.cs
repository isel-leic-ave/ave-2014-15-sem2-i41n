
struct V {
	public override System.String ToString() { return "My V"; }
}

class Program {
	public static void Main() {
		V v = new V();
		v.ToString();
	}
}