namespace ViceCity.IO
{
    using System;

    using Contracts;

    public class Writer : IWriter
    {
        public void Write(string line)
        {
            Console.Write(line);
        }

        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
