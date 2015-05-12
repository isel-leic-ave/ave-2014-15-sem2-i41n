using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpc13
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    namespace code
    {
        interface IFormatter<T>
        {
            string Format(T data);
        }

        public class Student
        {
            [FormatterAttibute(typeof(NameFormatter))]
            public String Name { get; set; }

            //[FormatterAttibute(typeof(BithDateFormatter))]
            [FormatterAttibute(typeof(NameFormatter))]
            public DateTime BirthDate { get; set; }
        }

        class NameFormatter : IFormatter<String>
        {
            public String Format(String src)
            {
                return src.ToUpper();
            }
        }

        class BithDateFormatter : IFormatter<DateTime>
        {
            public String Format(DateTime src)
            {
                return src.ToString();
            }
        }

        [AttributeUsage(AttributeTargets.Property, AllowMultiple=false)]
        public class FormatterAttibute : Attribute
        {
            private Type klass;

            public FormatterAttibute(Type klass)
            {
                this.klass = klass;
            }

            public Type FormatterType
            {
                get { return klass; }
            }
        }

        public class Alinea4
        {
            static public String FormatProps(Object obj)
            {
                String format = "{";
                Type t = obj.GetType();
                PropertyInfo[] pubProperties = t.GetProperties();
                foreach (PropertyInfo pi in pubProperties)
                {
                    FormatterAttibute attr = (FormatterAttibute)
                        Attribute.GetCustomAttribute(pi, typeof(FormatterAttibute));
                    /* eq. a 
                     FormatterAttibute attr =
                        (FormatterAttibute) pi.GetCustomAttribute(typeof(FormatterAttibute));
                     */
                    if (attr != null)
                    {                       
                        Type formatterType = attr.FormatterType;
                        Object formatter = Activator.CreateInstance(formatterType);
                        MethodInfo mi = formatterType.GetMethod("Format");

                        Object value = pi.GetValue(obj);
                        String valueStr = (String) 
                            mi.Invoke(formatter, new Object[] { value });
                        format += " " + valueStr;
                    }
                }
                return format + " }";
            }
        }

        class Program
        {

            static void Main(string[] args)
            {
                Student s = new Student();
                s.BirthDate = DateTime.Now;
                s.Name = "primeiro ultimo";
                Console.WriteLine(Alinea4.FormatProps(s));
            }
        }


    }

}