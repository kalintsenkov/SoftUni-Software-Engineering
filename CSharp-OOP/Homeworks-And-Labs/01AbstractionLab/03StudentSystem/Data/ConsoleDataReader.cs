namespace StudentSystemCatalog.Data
{
    using System;

    public class ConsoleDataReader : IDataReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
