using System;
using System.IO;

namespace FinalizationOrder_v2
{

    class MyWriter : StreamWriter, IDisposable
    {
        bool disposed = false;

        public MyWriter(Stream stream) : base(stream) { }

        public MyWriter(String path) : base(new FileStream(path, FileMode.Create)) { }

        public new void Dispose()
        {
            if (!disposed)
            {
                disposed = true;
                Console.WriteLine("Disposing " + this.GetHashCode());
                Dispose(true);
            }
        }

        private new void Dispose(bool disposing)
        {
            if (disposing)
            {
                /*
                 * Zona Safe de acesso a recursos "Finalizable"
                 */
                GC.SuppressFinalize(this);
                Flush();
                this.BaseStream.Dispose();
            }
            /*
             * liberta recursos nativos
             */
        }
        ~MyWriter()
        {
            Console.WriteLine("Finalizing " + this.GetHashCode());
            Dispose(false);
        }
    }
    static class Program
    {

        public static void testMyWriterWithOutsideStream()
        {
            StreamWriter writer = new MyWriter(new FileStream("tempEager.txt", FileMode.Create));
            writer.Write("Ola ");
            writer.WriteLine("Mundo!");
            writer.WriteLine("Ola Isel");
            // SEM flush e sem dispose
            // contudo esperamos que o Finalize faça o seu trabalho
        }

        public static void testMyWriterWithInsideStream()
        {
            StreamWriter writer = new MyWriter("tempLazy.txt"); // Vai ser o MyWriter a instanciar o Filestream
            writer.Write("Ola ");
            writer.WriteLine("Mundo!");
            writer.WriteLine("Ola Isel");
            // SEM flush e sem dispose
            // contudo esperamos que o Finalize faça o seu trabalho
        }

        public static void testMyWriterWithOutsideStream_Dispose()
        {
            using (StreamWriter writer = 
                new MyWriter(
                    new FileStream("tempEager.txt", FileMode.Create)))
            {
                writer.Write("Ola ");
                writer.WriteLine("Mundo!");
                writer.WriteLine("Ola Isel");
            }
        }

        public static void testMyWriterWithInsideStream_Dispose()
        {
            using (StreamWriter writer = new MyWriter("tempLazy.txt"))
            {  // Vai ser o MyWriter a instanciar o Filestream
                writer.Write("Ola ");
                writer.WriteLine("Mundo!");
                writer.WriteLine("Ola Isel");
            }
        }

        public static void Main()
        {
            testMyWriterWithOutsideStream();
            //testMyWriterWithOutsideStream_Dispose();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.ReadLine();

            testMyWriterWithInsideStream();
            //testMyWriterWithInsideStream_Dispose();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.ReadLine();

        }
    }
}
