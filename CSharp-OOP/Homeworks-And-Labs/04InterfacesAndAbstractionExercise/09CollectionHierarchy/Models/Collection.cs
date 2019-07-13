namespace CollectionHierarchy.Models
{
    using System.Collections.Generic;
    using Contracts;

    public abstract class Collection : IAddCollection
    {
        protected Collection()
        {
            this.Data = new List<string>();
        }

        protected List<string> Data { get; }

        public virtual int Add(string item)
        {
            var index = 0;
            this.Data.Insert(index, item);

            return index;
        }
    }
}
