﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Code from CLR via C# 
 */
namespace Properties
{
    using System;

    class ManyProperties
    {
        public int P1 { get; set; }
        public int P2 { get { return 0; } set { } }
        public int P3 { set { } }
        public int P4 { set { } }


    }

    internal sealed class Employee
    {
        
        private String m_Name; // prepended 'm_' to avoid conflict
        private Int32 m_Age;  // prepended 'm_' to avoid conflict

        public String Name
        {
            get { return (m_Name); }
            set { m_Name = value; } // 'value' identifies new value
        }

        public Int32 Age
        {
            get { return (m_Age); }
            set
            {
                if (value <= 0)    // 'value' identifies new value
                    throw new ArgumentOutOfRangeException("value", "must be >0");
                m_Age = value;
            }
        }
        
        /* auto-properties */
        public DateTime BirthDate { get; set; }

        public String Address { get; set; }
    }

    
    public sealed class Program
    {
        public static void Main()
        {
            Employee emp = new Employee();
            emp.Name = "Some Name";
            emp.Age = 36;	   // emp.set_Age(36)
            emp.Address = "aaaa"; // emp.set_Address("aaaa")
            Console.WriteLine("Employee info: Name = {0}, Age = {1}", emp.Name, emp.Age);

            try
            {
                emp.Age = -5;	   // Throws an exception
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("Employee info: Name = {0}, Age = {1}", emp.Name, emp.Age);
        }
    }
}
