namespace StorageMaster.IO
{
    using System;

    using Contracts;

    public class ConsoleDataReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
