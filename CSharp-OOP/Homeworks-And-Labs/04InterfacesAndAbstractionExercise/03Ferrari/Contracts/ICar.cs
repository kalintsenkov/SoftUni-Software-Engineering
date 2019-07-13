namespace Ferrari.Contracts
{
    public interface ICar
    {
        string Model { get; }

        string DriverName { get; }

        string SpeedUp();

        string Stop();
    }
}
