namespace CollectionHierarchy.Core
{
    using System;
    using System.Collections.Generic;
    using Contracts;

    public class Engine
    {
        private readonly IAddCollection addCollection;
        private readonly IAddRemoveCollection addRemoveCollection;
        private readonly IMyList myList;

        public Engine(
            IAddCollection addCollection,
            IAddRemoveCollection addRemoveCollection,
            IMyList myList)
        {
            this.addCollection = addCollection;
            this.addRemoveCollection = addRemoveCollection;
            this.myList = myList;
        }

        public void Run()
        {
            var input = Console.ReadLine().Split();
            var removeOperationsCount = int.Parse(Console.ReadLine());

            this.PrintResults(input, removeOperationsCount);
        }

        private void PrintResults(string[] input, int removeOperationsCount)
        {
            this.PrintAddedResults(input, this.addCollection);
            this.PrintAddedResults(input, this.addRemoveCollection);
            this.PrintAddedResults(input, this.myList);

            this.PrintRemovedResults(removeOperationsCount, this.addRemoveCollection);
            this.PrintRemovedResults(removeOperationsCount, this.myList);
        }

        private void PrintRemovedResults(int removeOperationsCount, IAddRemoveCollection collection)
        {
            var removedResults = new List<string>();

            for (int j = 0; j < removeOperationsCount; j++)
            {
                removedResults.Add(collection.Remove());
            }

            Console.WriteLine(string.Join(" ", removedResults));
        }

        private void PrintAddedResults(string[] input, IAddCollection collection)
        {
            var addedResults = new List<int>();

            foreach (var text in input)
            {
                addedResults.Add(collection.Add(text));
            }

            Console.WriteLine(string.Join(" ", addedResults));
        }
    }
}
