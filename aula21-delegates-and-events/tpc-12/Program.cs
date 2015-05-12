using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpc_12
{
    class TargetMethods
    {
        public delegate void Action(int x);
        public delegate void OtherAction(int x);

        public static void DoAction(Action a, int i) { a(i); }

        public static void SomeAction(int i) { Console.WriteLine(i); }

        public static void Main()
        {
            OtherAction o = new OtherAction(SomeAction);
            DoAction(SomeAction, 10);
            //DoAction(o, 10);

            Action a0 = delegate(int x) { Console.Beep(2000, x); };
            Action a1 = SomeAction;
            Action a2 = (Action) Delegate.Combine(a1, a0);
            Action a3 = (y) => { Console.WriteLine("*" + y + "*"); };
            
            a3 += a2;
            a3(1000);

            a3 -= new Action(SomeAction);
            a3(1100);
        }
    }
}
