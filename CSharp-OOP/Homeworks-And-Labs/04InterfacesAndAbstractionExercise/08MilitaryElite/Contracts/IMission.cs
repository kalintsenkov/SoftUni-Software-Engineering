namespace MilitaryElite.Contracts
{
    using Enumerations;

    public interface IMission
    {
        string CodeName { get; }

        State State { get; }

        void CompleteMission();
    }
}
