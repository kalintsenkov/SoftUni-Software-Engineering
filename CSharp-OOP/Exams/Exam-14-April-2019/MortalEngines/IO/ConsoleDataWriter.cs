namespace MortalEngines.IO
{
    using System;

    using Contracts;

    public class ConsoleDataWriter : IWriter
    {
        public void Write(object obj)
        {
            Console.WriteLine(obj);
        }
    }
}
