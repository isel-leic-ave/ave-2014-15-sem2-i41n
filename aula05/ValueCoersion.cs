using System;

class ValueCoersion {

	public static void Main()
	{
		Int32 i32 = 1;
		Int64 i64 = 1;

		i64 = i32;
		i32 = (Int32) i64;
		i64 = Int64.MaxValue;
		i32 = (Int32) i64;
		i32 = checked((Int32) i64);
	}

}