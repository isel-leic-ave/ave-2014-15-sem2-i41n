using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_Inv1415
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    namespace code
    {
        public class Student
        {
            [FormatterAttibute(typeof(NameFormatter))]
            public String Name { get; set; }

            [FormatterAttibute(typeof(BithDateFormatter))]
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

        public class FormatterAttibute : Attribute
        {
            // T Do
            public FormatterAttibute(Type klass)
            {
                // To Do
            }
        }

        public class Alinea4
        {
            static public String FormatProps(Student s)
            {
                String format = "{";
                Type t = s.GetType();
                PropertyInfo[] pis = t.GetProperties();
                foreach (PropertyInfo pi in pis)
                {
                    FormatterAttibute attr = (FormatterAttibute)
                        Attribute.GetCustomAttribute(pi, typeof(FormatterAttibute));
                    /* eq. a 
                     FormatterAttibute attr =
                        (FormatterAttibute) pi.GetCustomAttribute(typeof(FormatterAttibute));
                     */

                    /* To Do */
                }
                return format + "}";
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
