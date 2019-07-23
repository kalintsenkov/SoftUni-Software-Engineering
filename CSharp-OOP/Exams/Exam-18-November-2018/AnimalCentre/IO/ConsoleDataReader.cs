namespace AnimalCentre.IO
{
    using System;

    using Contracts;

    public class ConsoleDataReader : IDataReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
