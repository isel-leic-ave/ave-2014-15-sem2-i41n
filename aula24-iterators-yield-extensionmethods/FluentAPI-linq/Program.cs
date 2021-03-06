﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI_linq
{
    class Program
    {

        struct Student
        {
            public int Number { get; set; }
            public String Name { get; set; }
            public double CurrAverage { get; set; }
            public override string ToString()
            {
                return String.Format("[ Number={0} Name={1} CurrAverage={2}]", Number, Name, CurrAverage);
            }
        }

        #region V1
        public static void v1()
        {
            List<Student> list = new List<Student>();
            list.Add(new Student { Name = "jose", Number = 1234, CurrAverage = 12.5 });
            list.Add(new Student { Name = "maria", Number = 1023, CurrAverage = 18.1 });
            list.Add(new Student { Name = "ana", Number = 1223, CurrAverage = 12.3 });
            list.Add(new Student { Name = "anacleto", Number = 1123, CurrAverage = 17.5 });

            // filtrar, ordernar, projectar
            List<Student> tmp = Collections.Filter(list, x => x.CurrAverage > 14);
            tmp = Collections.Sort(tmp, (x, y) => x.Number - y.Number);
            List<String> lstStr = Collections.Select(tmp, x => x.Name + ", ");

            // mostrar todos os elementos
            Collections.ForEach(lstStr, x => Console.Write(x));
            Console.WriteLine();
        }
        #endregion


        #region V2
        public static void v2()
        {
            List<Student> list = new List<Student>();
            list.Add(new Student { Name = "jose", Number = 1234, CurrAverage = 12.5 });
            list.Add(new Student { Name = "maria", Number = 1023, CurrAverage = 18.1 });
            list.Add(new Student { Name = "ana", Number = 1223, CurrAverage = 12.3 });
            list.Add(new Student { Name = "anacleto", Number = 1123, CurrAverage = 17.5 });

            // filtrar, ordernar, projectar
            List<String> lstStr =
                Collections.Select(
                    Collections.Sort(
                        Collections.Filter(list, x => x.CurrAverage > 14),
                        (x, y) => x.Name.CompareTo(y.Name)),
                    x => x.Name + ", ");

            // mostrar todos os elementos
            Collections.ForEach(lstStr, x => Console.Write(x));
            Console.WriteLine();
        }
        #endregion

        #region V3
        public static void v3()
        {
            
            List<Student> list = new List<Student>();
            list.Add(new Student { Name = "jose", Number = 1234, CurrAverage = 12.5 });
            list.Add(new Student { Name = "maria", Number = 1023, CurrAverage = 18.1 });
            list.Add(new Student { Name = "ana", Number = 1223, CurrAverage = 17.3 });
            list.Add(new Student { Name = "rui", Number = 1123, CurrAverage = 15.1 });

            // filtras, mostrar resultado
            list.Filter(x => x.CurrAverage > 15)
                .ForEach(x => Console.Write(x + ", "));

            list.Filter(x => x.CurrAverage > 10)
                .First();
            
        }
        #endregion

        static void Main(string[] args)
        {
        }
    }
}
