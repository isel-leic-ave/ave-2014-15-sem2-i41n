using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Files
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] bytesToWrite = {1,2,3,4,5};
            FileStream fs = new FileStream("temp.dat", FileMode.Create);
            fs.Write(bytesToWrite, 0, bytesToWrite.Length);
        }
    }
}
