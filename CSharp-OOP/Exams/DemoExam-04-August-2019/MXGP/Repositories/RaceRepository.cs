namespace MXGP.Repositories
{
    using System.Linq;

    using Models.Races.Contracts;

    public class RaceRepository : Repository<IRace>
    {
        public override IRace GetByName(string name)
        {
            var race = this.GetAll()
                 .FirstOrDefault(x => x.Name == name);

            return race;
        }
    }
}
