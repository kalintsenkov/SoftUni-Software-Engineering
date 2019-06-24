using System;
using System.Collections.Generic;
using System.Text;

namespace StudentSystemCatalog.Data
{
    public class ConsoleDataWriter : IDataWriter
    {
        public void Write(object obj)
        {
            Console.WriteLine(obj);
        }
    }
}
