namespace CompositePattern
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var playstation = new SingleGift("PS4", 650.00m);
            playstation.CalculateTotalPrice();
            
            Console.WriteLine();

            var rootBox = new CompositeGift("RootBox", 0);
            var truckToy = new SingleGift("TruckToy", 155.70m);
            var plainToy = new SingleGift("PlainToy", 325.35m);

            rootBox.Add(truckToy);
            rootBox.Add(plainToy);

            var childBox = new CompositeGift("ChildBox", 0);
            var soldierToy = new SingleGift("SoldierToy", 220m);
            var carToy = new SingleGift("CarToy", 470.99m);

            childBox.Add(soldierToy);
            childBox.Add(carToy);

            rootBox.Add(childBox);

            var rootBoxTotalPrice = rootBox.CalculateTotalPrice();
            Console.WriteLine($"Total price of this composite present is: {rootBoxTotalPrice}");
        }
    }
}
