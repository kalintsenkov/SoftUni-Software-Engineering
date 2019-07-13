namespace Shapes
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            try
            {
                Shape rectangle = new Rectangle(5.25, 6.5);
                Shape cirle = new Circle(3.25);

                Console.WriteLine(rectangle.CalculateArea());
                Console.WriteLine(rectangle.CalculatePerimeter());

                Console.WriteLine(cirle.CalculateArea());
                Console.WriteLine(cirle.CalculatePerimeter());
            }
            catch (InvalidSideException ise)
            {
                Console.WriteLine(ise.Message);
            }
            catch (InvalidRadiusException ire)
            {
                Console.WriteLine(ire.Message);
            }
        }
    }
}
