namespace MXGP.Core.Factories
{
    using Contracts;
    using Models.Riders;
    using Models.Riders.Contracts;

    public class RiderFactory : IRiderFactory
    {
        public IRider CreateRider(string riderName) 
            => new Rider(riderName);
    }
}
