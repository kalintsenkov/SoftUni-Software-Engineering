namespace Repository
{
    using System.Collections.Generic;
    using System.Linq;

    public class Repository
    {
        private Dictionary<int, Person> people;
        private int id;

        public int Count => this.people.Count;

        public Repository()
        {
            this.people = new Dictionary<int, Person>();
            this.id = 0;
        }

        public void Add(Person person)
        {
            if (!this.people.ContainsKey(this.id))
            {
                this.people.Add(this.id, person);
                this.id++;
            }
        }

        public Person Get(int id)
            => this.people
            .Where(x => x.Key == id)
            .Select(x => x.Value)
            .FirstOrDefault();

        public bool Update(int id, Person newPerson)
        {
            if (this.people.ContainsKey(id))
            {
                this.people[id] = newPerson;

                return true;
            }

            return false;
        }

        public bool Delete(int id)
        {
            if (this.people.ContainsKey(id))
            {
                this.people.Remove(id);

                return true;
            }

            return false;
        }
    }
}
