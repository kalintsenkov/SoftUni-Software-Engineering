namespace StudentSystemCatalog
{
    using Commands;
    using Data;
    using Students;

    public class Engine
    {
        private CommandParser commandParser;
        private StudentSystem studentSystem;

        private IDataReader dataReader;
        private IDataWriter dataWriter;

        public Engine(
            CommandParser commandParser, 
            StudentSystem studentSystem,
            IDataReader dataReader,
            IDataWriter dataWriter)
        {
            this.commandParser = commandParser;
            this.studentSystem = studentSystem;
            this.dataReader = dataReader;
            this.dataWriter = dataWriter;
        }

        public void Run()
        {
            while (true)
            {
                var data = this.dataReader.Read();

                var command = commandParser.Parse(data);

                if (command.Name == "Create")
                {
                    var name = command.Arguments[0];
                    var age = int.Parse(command.Arguments[1]);
                    var grade = double.Parse(command.Arguments[2]);

                    studentSystem.Add(name, age, grade);
                }
                else if (command.Name == "Show")
                {
                    var name = command.Arguments[0];

                    var student = studentSystem.Get(name);

                    this.dataWriter.Write(student);
                }
                else if (command.Name == "Exit")
                {
                    break;
                }
            }
        }
    }
}