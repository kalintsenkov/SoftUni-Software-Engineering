namespace CollectionHierarchy.Models
{
    using Contracts;

    public class MyList : AddRemoveCollection, IMyList
    {
        public int Used => this.Data.Count;

        public override string Remove()
        {
            string item = this.Data[0];
            this.Data.RemoveAt(0);

            return item;
        }
    }
}
