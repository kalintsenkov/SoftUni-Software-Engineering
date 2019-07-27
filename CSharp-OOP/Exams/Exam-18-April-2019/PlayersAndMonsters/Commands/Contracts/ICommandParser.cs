namespace PlayersAndMonsters.Commands.Contracts
{
    public interface ICommandParser
    {
        ICommand Parse(string input);
    }
}
