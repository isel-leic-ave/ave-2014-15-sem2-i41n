using System;
using System.IO;

namespace Finalization
{
    class FileStreamClean : FileStream {
        public FileStreamClean(string path) : base(path, FileMode.Create) {}
        ~FileStreamClean() {
            Console.WriteLine("IN FINALIZER");
            throw new Exception("Breaking Finalize"); 
        }
    }

}
