namespace MXGP.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Models.Riders.Contracts;

    public class RiderRepository : Repository<IRider>
    {
        public override IRider GetByName(string name)
        {
            var rider = this.GetAll()
                 .FirstOrDefault(x => x.Name == name);

            return rider;
        }
    }
}
