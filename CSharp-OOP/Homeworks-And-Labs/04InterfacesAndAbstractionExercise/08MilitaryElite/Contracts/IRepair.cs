namespace MilitaryElite.Contracts
{
    public interface IRepair
    {
        string PartName { get; }

        int HoursWorked { get; }
    }
}
