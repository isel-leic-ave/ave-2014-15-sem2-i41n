using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finalization_Dispose_Pattern
{
    using System;
    using System.IO;

    static class App
    {
        class FileWrapper : IDisposable
        {
            FileStream fs; // Campo do tipo IDisposable
            bool disposed = false;

            public FileWrapper(string path)
            {
                fs = new FileStream(path, FileMode.Create);
            }

            public void Dispose()
            {
                if (!disposed)
                {
                    disposed = true;
                    fs.Dispose();
                    GC.SuppressFinalize(this);
                }
            }
            ~FileWrapper()
            {
                Dispose();
            }

            public void Operation(byte[] bytes, int offset, int count)
            {
                // make some modification to bytesToWrite and write them
                // ...
                fs.Write(bytes, offset, count);
            }
        }

        public static void Main()
        {
            Byte[] bytesToWrite = new Byte[] { 65, 66, 67, 68 };
            
            FileStream fs = new FileStream("out.txt", FileMode.Create);

            fs.Write(bytesToWrite, 0, bytesToWrite.Length);

            fs.Dispose();

            // throws ObjectDisposedException
            //fs.Write(bytesToWrite, 0, bytesToWrite.Length);

            // 
            // <=> ao Try-with-resources do Java
            //
            using (FileStream otherfs = new FileStream("other-out.txt", FileMode.Create))
            {
                otherfs.Write(bytesToWrite, 0, bytesToWrite.Length);
            }

            Console.WriteLine("Wait for user to hit <Enter>");

            using (FileWrapper wrapper = new FileWrapper("wrapper-out.txt"))
            {
                wrapper.Operation(bytesToWrite, 0, bytesToWrite.Length);
            }
            
            Console.ReadLine();
        }

    }

}
