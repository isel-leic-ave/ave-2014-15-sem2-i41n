using System;
using System.IO;

namespace FinalizationOrder
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
                GC.SuppressFinalize(this);
                Console.WriteLine("Disposing " + this.GetHashCode());
                this.Flush();
                this.BaseStream.Dispose();
            }
        }
        ~MyWriter()
        {
            Console.WriteLine("Finalizing " + this.GetHashCode());
            Dispose();
        }
    }
    static class Program
    {

        public static void testMyWriterWithOutsideStream()
        {
            StreamWriter writer = new MyWriter(
                new FileStream("tempEager.txt", FileMode.Create));
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
            using (StreamWriter writer = new MyWriter(new FileStream("tempEager.txt", FileMode.Create)))
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
