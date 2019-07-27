namespace PlayersAndMonsters.IO
{
    using System;

    using Contracts;

    public class ConsoleWriter : IWriter
    {
        public void Write(object obj) => Console.Write(obj);

        public void WriteLine(object obj) => Console.WriteLine(obj);
    }
}
