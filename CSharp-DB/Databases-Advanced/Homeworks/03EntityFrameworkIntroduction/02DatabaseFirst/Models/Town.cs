namespace SoftUni.Models
{
    using System.Collections.Generic;

    public partial class Town
    {
        public Town()
        {
            Addresses = new HashSet<Address>();
        }

        public int TownId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
