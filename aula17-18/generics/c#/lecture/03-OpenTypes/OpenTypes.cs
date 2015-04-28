using System;
using System.Collections.Generic;

public static class Program
{

    public class MyGenericType<T>
    {
        public void someMethod(T t)
        {

        }
    }

    public static void Main()
    {

        Console.WriteLine(typeof(MyGenericType<>));

        Console.WriteLine(typeof(MyGenericType<String>));

        Console.WriteLine(typeof(MyGenericType<int>));

        /*
        Object o = null;

        // Dictionary<,> is an open type having 2 type parameters
        Type t = typeof(Dictionary<,>);

        // Try to create an instance of this type (fails)
        o = CreateInstance(t);
        Console.WriteLine();

        // DictionaryStringKey<> is an open type having 1 type parameter
        t = typeof(DictionaryStringKey<>);

        // Try to create an instance of this type (fails)
        o = CreateInstance(t);
        Console.WriteLine();

        // DictionaryStringKey<Guid> is a closed type
        t = typeof(DictionaryStringKey<Guid>);

        // Try to create an instance of this type (succeeds) 
        o = CreateInstance(t);

        // Prove it actually worked
        Console.WriteLine("Object type=" + o.GetType());
         * 
         * */
    }

    private static Object CreateInstance(Type t)
    {
        Object o = null;
        try
        {
            o = Activator.CreateInstance(t);
            Console.Write("Created instance of {0} ", t.ToString());
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
        return o;
    }
}


// A partially specified open type
internal sealed class DictionaryStringKey<TValue> : Dictionary<String, TValue>
{
}