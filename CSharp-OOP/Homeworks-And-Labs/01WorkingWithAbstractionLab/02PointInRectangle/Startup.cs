namespace _02PointInRectangle
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var coordinates = Console.ReadLine().Split();
            var n = int.Parse(Console.ReadLine());

            var topLeftX = int.Parse(coordinates[0]);
            var topLeftY = int.Parse(coordinates[1]);
            var bottomRightX = int.Parse(coordinates[2]);
            var bottomRightY = int.Parse(coordinates[3]);

            var topLeftPoint = new Point(topLeftX, topLeftY);
            var bottomRightPoint = new Point(bottomRightX, bottomRightY);

            var rectangle = new Rectangle(topLeftPoint, bottomRightPoint);

            for (int i = 0; i < n; i++)
            {
                var pointInfo = Console.ReadLine().Split();

                var x = int.Parse(pointInfo[0]);
                var y = int.Parse(pointInfo[1]);

                var point = new Point(x, y);

                Console.WriteLine(rectangle.Contains(point));
            }
        }
    }
}
