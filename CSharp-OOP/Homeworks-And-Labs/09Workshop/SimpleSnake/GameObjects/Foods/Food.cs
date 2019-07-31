namespace SimpleSnake.GameObjects.Foods
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Food : Point
    {
        private readonly Wall wall;
        private readonly Random random;
        private char foodSymbol;

        protected Food(Wall wall, char foodSymbol, int points) 
            : base(wall.LeftX, wall.TopY)
        {
            this.wall = wall;
            this.foodSymbol = foodSymbol;
            this.FoodPoints = points;

            this.random = new Random();
        }

        public int FoodPoints { get; set; }

        public bool IsFoodPoint(Point snakeHead)
        {
            return this.LeftX == snakeHead.LeftX
                && this.TopY == snakeHead.TopY;
        }

        public void SetRandomPosition(Queue<Point> snakeElements)
        {
            this.LeftX = this.random.Next(2, this.wall.LeftX - 2);
            this.TopY = this.random.Next(2, this.wall.TopY - 2);

            var isPointOnSnake = snakeElements
                .Any(p => p.LeftX == this.LeftX && p.TopY == this.TopY);

            while (isPointOnSnake)
            {
                this.LeftX = this.random.Next(2, this.LeftX - 2);
                this.TopY = this.random.Next(2, this.TopY - 2);

                isPointOnSnake = snakeElements
                .Any(p => p.LeftX == this.LeftX && p.TopY == this.TopY);
            }

            Console.BackgroundColor = ConsoleColor.Red;
            this.Draw(this.foodSymbol);
            Console.BackgroundColor = ConsoleColor.White;
        }
    }
}
