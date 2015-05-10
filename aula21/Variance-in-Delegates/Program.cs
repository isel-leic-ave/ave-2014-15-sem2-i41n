using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variance_in_Delegates
{
    class A { }

    class B : A { }

    class C : B { }

    class D : B { }

    delegate C MyDelegate(A m);

    class Program
    {
        static C MethA(A m) { return new C(); }

        static void Main(string[] args)
        {
            MyDelegate d = new MyDelegate(MethA);

            C d1 = d(new D());
        }
    }
}
