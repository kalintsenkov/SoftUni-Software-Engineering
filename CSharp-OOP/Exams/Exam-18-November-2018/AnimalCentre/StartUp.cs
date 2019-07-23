namespace AnimalCentre
{
    using Commands;
    using Core;
    using Factories;
    using IO;
    using Models.Entities;

    public class StartUp
    {
        public static void Main()
        {
            var hotel = new Hotel();
            var animalFactory = new AnimalFactory();
            var procedureFactory = new ProcedureFactory();

            var animalCentre = new AnimalCentre(
                hotel, 
                animalFactory,
                procedureFactory);

            var commandParser = new CommandParser();
            var dataWriter = new ConsoleDataWriter();
            var dataReader = new ConsoleDataReader();

            var engine = new Engine(
                animalCentre, 
                commandParser, 
                dataReader,
                dataWriter);

            engine.Run();
        }
    }
}
