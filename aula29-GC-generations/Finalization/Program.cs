using System;
using System.IO;

namespace Finalization
{
    class Program
    {
        static void PrintRunningGC()
        {
            Console.WriteLine("Running GC...");
            GC.Collect();
        }

        public static void V1()
        {
            // 
            // Uma instância de FileStream mantém um handle para um recurso nativo, i.e. um ficheiro.
            //
            FileStream fs = new FileStream("out.txt", FileMode.Create);
            // Wait for user to hit <Enter>
            Console.WriteLine("Wait for user to hit <Enter>");
            Console.ReadLine();

            PrintRunningGC();
            Console.WriteLine("Wait for user to hit <Enter>");
            Console.ReadLine();
        }

        public static void V2()
        {
            // 
            // Uma instância de FileStream mantém um handle para um recurso nativo, i.e. um ficheiro.
            //
            FileStream fs = new FileStreamClean("out.txt");
            // Wait for user to hit <Enter>
            Console.WriteLine("Wait for user to hit <Enter>");
            Console.ReadLine();

            PrintRunningGC();

            Console.WriteLine("Wait for user to hit <Enter>");
            Console.ReadLine();
        }

        public static void V3()
        {
            // 
            // <=> ao Try-with-resources do Java
            //
            using(FileStream fs = new FileStreamClean("out.txt")){
                // Wait for user to hit <Enter>
                Console.WriteLine("Wait for user to hit <Enter>");
                Console.ReadLine();
            } 
        
            Console.WriteLine("Wait for user to hit <Enter>");
		    Console.ReadLine();
        }

        public static void Main()
        {
            //V1();
            V2();
            V3();
        }
    }
}
