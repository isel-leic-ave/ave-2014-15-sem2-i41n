using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateMaxCalls
{
    class Handlers
    {
        [MaxCalls(2)]
        static public void M1(NotifyArgs arg) { Console.WriteLine("M1"); }
        [MaxCalls(1)]
        static public void M2(NotifyArgs arg) { Console.WriteLine("M2(NotifyArgs)"); }
        [MaxCalls(7)]
        public void M2(string arg)
        {
            // nao é compativel, logo nao é chamado
            Console.WriteLine("M2(string)");
        }
        public void M4(NotifyArgs arg)
        {
            // nao é anotado, logo não é chamado
        }
    }
}
