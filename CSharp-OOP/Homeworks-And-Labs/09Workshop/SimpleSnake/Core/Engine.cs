namespace SimpleSnake.Core
{
    using System;
    using System.Threading;

    using Enums;
    using GameObjects;

    public class Engine
    {
        private readonly Point[] directionPoints;

        private Direction direction;
        private Snake snake;
        private Wall wall;

        private double sleepTime;

        public Engine(Wall wall, Snake snake)
        {
            this.wall = wall;
            this.snake = snake;
            this.sleepTime = 100;

            this.directionPoints = new Point[4];
        }

        public void Run()
        {
            this.CreateDirections();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    this.GetNextDirection();
                }

                var isMoving = this.snake.IsMoving(this.directionPoints[(int)this.direction]);

                if (!isMoving)
                {
                    this.AskUserForRestart();
                }

                this.sleepTime -= 0.01;

                Thread.Sleep((int)this.sleepTime);
            }
        }

        private void AskUserForRestart()
        {
            var leftX = this.wall.LeftX + 1;
            var topY = 3;

            Console.SetCursorPosition(leftX, topY);
            Console.Write("Would you like to continue? yes/no");
            Console.SetCursorPosition(leftX, topY + 1);

            var input = Console.ReadLine().ToLower();

            if (input == "yes")
            {
                StartUp.Main();
            }
            else if (input == "no")
            {
                this.StopGame();
            }
        }

        private void StopGame()
        {
            Console.SetCursorPosition(20, 10);
            Console.Write("Game Over!");
            Environment.Exit(0);
        }

        private void GetNextDirection()
        {
            var userInput = Console.ReadKey();

            if (userInput.Key == ConsoleKey.LeftArrow)
            {
                if (this.direction != Direction.Right)
                {
                    this.direction = Direction.Left;
                }
            }
            else if (userInput.Key == ConsoleKey.RightArrow)
            {
                if (this.direction != Direction.Left)
                {
                    this.direction = Direction.Right;
                }
            }
            else if (userInput.Key == ConsoleKey.UpArrow)
            {
                if (this.direction != Direction.Down)
                {
                    this.direction = Direction.Up;
                }
            }
            else if (userInput.Key == ConsoleKey.DownArrow)
            {
                if (this.direction != Direction.Up)
                {
                    this.direction = Direction.Down;
                }
            }

            Console.CursorVisible = false;
        }

        private void CreateDirections()
        {
            this.directionPoints[0] = new Point(1, 0);
            this.directionPoints[1] = new Point(-1, 0);
            this.directionPoints[2] = new Point(0, 1);
            this.directionPoints[3] = new Point(0, -1);
        }
    }
}
