using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpc_14
{
    class Program
    {
        public static IEnumerable<int> BetweenRange(int begin, int end)
        {
            return new BetweenRangeEnumerable(begin, end);
        }

        static void Main(string[] args)
        {
            foreach (int number in BetweenRange(10, 20))
            {
                Console.WriteLine(number);
            }
        }
    }
}
