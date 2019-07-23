namespace AnimalCentre.IO
{
    using System;

    using Contracts;

    public class ConsoleDataWriter : IDataWriter
    {
        public void WriteLine(object obj)
        {
            Console.WriteLine(obj);
        }
    }
}
