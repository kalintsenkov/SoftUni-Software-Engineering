namespace SimpleSnake.GameObjects.Foods
{
    public class FoodHash : Food
    {
        private const char InitialFoodSymbol = '#';
        private const int InitialPoints = 3;

        public FoodHash(Wall wall) 
            : base(wall, InitialFoodSymbol, InitialPoints)
        {
        }
    }
}
