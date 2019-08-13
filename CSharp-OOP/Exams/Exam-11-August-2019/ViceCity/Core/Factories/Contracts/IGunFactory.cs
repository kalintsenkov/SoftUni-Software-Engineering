namespace ViceCity.Core.Factories.Contracts
{
    using Models.Guns.Contracts;

    public interface IGunFactory
    {
        IGun CreateGun(string type, string name);
    }
}
