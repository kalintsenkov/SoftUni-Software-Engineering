namespace Shapes
{
    public class Rectangle : Shape
    {
        private const string InvalidSideExceptionMessage = "{0} must be a positive number!";

        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }

        public double Height
        {
            get => this.height;

            private set
            {
                this.ValidateSide(value, nameof(this.Height));
                this.height = value;
            }
        }

        public double Width
        {
            get => this.width;

            private set
            {
                this.ValidateSide(value, nameof(this.Width));
                this.width = value;
            }
        }

        public override double CalculateArea()
        {
            return this.Width * this.Height;
        }

        public override double CalculatePerimeter()
        {
            return (2 * this.Width) + (2 * this.Height);
        }

        public override string Draw()
        {
            return base.Draw() + $" {this.GetType().Name}";
        }

        private void ValidateSide(double side, string sideName)
        {
            if (side <= 0)
            {
                throw new InvalidSideException(
                    string.Format(InvalidSideExceptionMessage, sideName));
            }
        }
    }
}
