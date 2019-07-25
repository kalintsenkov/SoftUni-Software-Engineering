namespace StorageMaster.IO
{
    using System;

    using Contracts;

    public class ConsoleDataWriter : IWriter
    {
        public void WriteLine(object obj)
        {
            Console.WriteLine(obj);
        }
    }
}
