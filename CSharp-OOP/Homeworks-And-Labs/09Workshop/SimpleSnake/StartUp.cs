namespace SimpleSnake
{
    using Core;
    using GameObjects;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();

            var wall = new Wall(60, 20);
            var snake = new Snake(wall);

            var engine = new Engine(wall, snake);

            engine.Run();
        }
    }
}
