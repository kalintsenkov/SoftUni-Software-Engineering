namespace SimpleSnake.GameObjects.Foods
{
    public class FoodAsterisk : Food
    {
        private const char InitialFoodSymbol = '*';
        private const int InitialPoints = 1;

        public FoodAsterisk(Wall wall) 
            : base(wall, InitialFoodSymbol, InitialPoints)
        {
        }
    }
}
