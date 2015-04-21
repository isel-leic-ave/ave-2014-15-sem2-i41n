using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutRef
{
    public struct BigValue 
    {
        public long v1;
        public double v2;
        public DateTime v3;
        public override string ToString()
        {
            return String.Format("{0}, {1}, {2}", v1, v2, v3);
        }
    }

    class Program
    {
        public static void SendBigValue(BigValue big)
        {
            long time = big.v3.Ticks;
        }

        public static void GetValueOut(out BigValue v)
        {
            v = new BigValue();
        }

        public static void GetValueRef(ref BigValue v)
        {
            v.v1 = 2048;
        }

        public static void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }

        static void Main(string[] args)
        {
            BigValue big;
            SendBigValue(new BigValue());
            Program.GetValueOut(out big);
            Console.WriteLine(big.ToString());

            BigValue other = new BigValue(); ;
            Program.GetValueRef(ref other);
            Console.WriteLine(other.ToString());

            int a = 10, b = 20;
            Program.Swap(ref a, ref b);
            Console.WriteLine("{0} {1}", a, b);
        }
    }
}
