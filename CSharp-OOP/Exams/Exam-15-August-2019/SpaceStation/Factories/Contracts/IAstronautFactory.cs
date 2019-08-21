namespace SpaceStation.Factories.Contracts
{
    using Models.Astronauts.Contracts;

    public interface IAstronautFactory
    {
        IAstronaut CreateAstronaut(string type, string astronautName);
    }
}
