namespace SimpleSnake.GameObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Foods;

    public class Snake
    {
        private const char SnakeSymbol = '\u25CF';

        private readonly Queue<Point> snakeElements;
        private readonly Food[] foods;
        private readonly Wall wall;

        private int nextLeftX;
        private int nextTopY;
        private int foodIndex;

        public Snake(Wall wall)
        {
            this.wall = wall;

            this.foods = new Food[3];
            this.snakeElements = new Queue<Point>();

            this.foodIndex = this.RandomFoodNumber;

            this.GetFoods();
            this.CreateSnake();
        }

        public int RandomFoodNumber
            => new Random().Next(0, this.foods.Length);

        public bool IsMoving(Point direction)
        {
            var snakeHead = this.snakeElements.LastOrDefault();

            this.GetNextPoint(direction, snakeHead);

            var isPointOfSnake = this.snakeElements
                .Any(x => x.LeftX == this.nextLeftX && x.TopY == this.nextTopY);

            if (isPointOfSnake)
            {
                return false;
            }

            var newSnakeHead = new Point(this.nextLeftX, this.nextTopY);

            if (this.wall.IsPointOfWall(newSnakeHead))
            {
                return false;
            }

            this.snakeElements.Enqueue(newSnakeHead);
            newSnakeHead.Draw(SnakeSymbol);

            if (this.foods[this.foodIndex].IsFoodPoint(newSnakeHead))
            {
                this.Eat(direction, snakeHead);
            }

            var snakeTail = this.snakeElements.Dequeue();
            snakeTail.Draw(' ');

            return true;
        }

        public void Eat(Point direction, Point currentSnakeHead)
        {
            var length = this.foods[this.foodIndex].FoodPoints;

            for (int i = 0; i < length; i++)
            {
                this.snakeElements.Enqueue(new Point(this.nextLeftX, this.nextTopY));
                this.GetNextPoint(direction, currentSnakeHead);
            }

            this.foodIndex = this.RandomFoodNumber;
            this.foods[this.foodIndex].SetRandomPosition(this.snakeElements);
        }

        private void GetNextPoint(Point direction, Point snakeHead)
        {
            this.nextLeftX = snakeHead.LeftX + direction.LeftX;
            this.nextTopY = snakeHead.TopY + direction.TopY;
        }

        private void CreateSnake()
        {
            for (int topY = 1; topY <= 6; topY++)
            {
                this.snakeElements.Enqueue(new Point(2, topY));
            }

            this.foods[this.foodIndex].SetRandomPosition(this.snakeElements);
        }

        private void GetFoods()
        {
            this.foods[0] = new FoodAsterisk(this.wall);
            this.foods[1] = new FoodDollar(this.wall);
            this.foods[2] = new FoodHash(this.wall);
        }
    }
}
