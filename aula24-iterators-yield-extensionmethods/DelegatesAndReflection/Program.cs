using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndReflection
{
    class Program
    {
        /**
         * MethodInfo for method that returns String and receives void
         */

        class X
        {
            public MethodInfo mi;
            public Object target;
            public String M()
            {
                return (String) mi.Invoke(target, null);
            }
        }

        public static Func<String> CreateDelegateBasedOnMethodInfo_v1(
            MethodInfo mi, 
            Object target)
        {
            return () => (String) mi.Invoke(target, null);

            /*
             * X x = new X(); x.mi = mi; x.target=target;
            return new Func<String>(x.M);
             */
        }


        public static Func<String> CreateDelegateBasedOnMethodInfo_v2(MethodInfo mi, Object target)
        {
            return (Func<String>) 
                Delegate.CreateDelegate(typeof(Func<String>), target, mi);
        }




        static void Main(string[] args)
        {
            Int64 m_startTime = Stopwatch.GetTimestamp();
            Func<String> f = CreateDelegateBasedOnMethodInfo_v1(typeof(A).GetMethod("m"), new A());
            for (int i = 0; i < 10; ++i)
            {
                f();
            }
            Int64 m_finishTime = Stopwatch.GetTimestamp();
            Console.WriteLine("Nanoseconds: {0}", 
                ((m_finishTime - m_startTime) / 10)*100);

            m_startTime = Stopwatch.GetTimestamp();
            f = CreateDelegateBasedOnMethodInfo_v2(typeof(A).GetMethod("m"), new A());
            for (int i = 0; i < 10; ++i)
            {
                f();
            }
            m_finishTime = Stopwatch.GetTimestamp();
            Console.WriteLine("Nanoseconds: {0}", 
                ((m_finishTime - m_startTime) / 10)*100);
        }
    }

    class A
    {
        public String m() { return "AVE"; }
    }
}
