namespace PrototypePattern
{
    using System.Collections.Generic;

    public class SandwichMenu
    {
        private readonly IDictionary<string, SandwichPrototype> sandwiches;

        public SandwichMenu()
        {
            this.sandwiches = new Dictionary<string, SandwichPrototype>();
        }

        public SandwichPrototype this[string name]
        {
            get { return this.sandwiches[name]; }
            set { this.sandwiches.Add(name, value); }
        }

        public void Add(string name, SandwichPrototype sandwich) 
            => this.sandwiches.Add(name, sandwich);
    }
}
