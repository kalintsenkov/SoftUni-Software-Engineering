namespace CollectionHierarchy
{
    using Core;
    using Models;

    public class StartUp
    {
        public static void Main()
        {
            var addCollection = new AddCollection();
            var addRemoveCollection = new AddRemoveCollection();
            var myList = new MyList();

            var engine = new Engine(
                addCollection, 
                addRemoveCollection, 
                myList);

            engine.Run();
        }
    }
}
