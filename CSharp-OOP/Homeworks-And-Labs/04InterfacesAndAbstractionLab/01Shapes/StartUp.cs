namespace Shapes
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var radius = int.Parse(Console.ReadLine());
            IDrawable cirle = new Circle(radius);

            var width = int.Parse(Console.ReadLine());
            var height = int.Parse(Console.ReadLine());
            IDrawable rectangle = new Rectangle(width, height);

            cirle.Draw();
            rectangle.Draw();
        }
    }
}
