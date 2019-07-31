namespace SimpleSnake.GameObjects.Foods
{
    public class FoodDollar : Food
    {
        private const char InitialFoodSymbol = '$';
        private const int InitialPoints = 2;

        public FoodDollar(Wall wall) 
            : base(wall, InitialFoodSymbol, InitialPoints)
        {
        }
    }
}
