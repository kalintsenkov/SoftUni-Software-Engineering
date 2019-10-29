namespace SoftUni.Models
{
    using System.Collections.Generic;

    public partial class Address
    {
        public Address()
        {
            Employees = new HashSet<Employee>();
        }

        public int AddressId { get; set; }

        public string AddressText { get; set; }

        public int? TownId { get; set; }

        public virtual Town Town { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
