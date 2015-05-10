using System;

public enum Color { Red }


namespace DefiningCustomAttribute
{

    [AttributeUsage(AttributeTargets.All, AllowMultiple=true)]
    public sealed class AuthorAttribute : Attribute
    {
        public AuthorAttribute(String Name)
        {
            this.Name = Name;
        }

        public string Name { get; set; }
        public string Date { get; set; }
    }

    [Author("Jose", Date = "1-1-1989")]
    [Author("Joao", Date = "1-1-1990")]
    public sealed class SomeType
    {
    }

    public class Program
    {
        [Author("Manuel")]
        static void Main(string[] args)
        {
            Type t = typeof(SomeType);
            Console.WriteLine(t.IsDefined(typeof(AuthorAttribute), false));
            AuthorAttribute[] ta = 
                (AuthorAttribute[]) t.GetCustomAttributes(typeof(AuthorAttribute), false);
            foreach (AuthorAttribute a in ta) {
                Console.WriteLine(a.Name);
            }
        }
    }
}









