namespace MortalEngines.IO
{
    using System;

    using Contracts;

    public class ConsoleDataReader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
