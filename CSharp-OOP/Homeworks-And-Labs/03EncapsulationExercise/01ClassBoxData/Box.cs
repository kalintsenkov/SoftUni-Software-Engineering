namespace ClassBoxData
{
    using System;
    using System.Text;

    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get => this.length;

            private set
            {
                this.ValidateSide(value, nameof(this.Length));
                this.length = value;
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

        public double Height
        {
            get => this.height;

            private set
            {
                this.ValidateSide(value, nameof(this.Height));
                this.height = value;
            }
        }

        public double GetVolume()
        {
            return this.Length * this.Width * this.Height;
        }

        public double GetLateralSurfaceArea()
        {
            return (2 * this.Length * this.Height)
                + (2 * this.Width * this.Height);
        }

        public double GetSurfaceArea()
        {
            return this.GetLateralSurfaceArea()
                + (2 * this.Length * this.Width);
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"Surface Area - {this.GetSurfaceArea():F2}");
            result.AppendLine($"Lateral Surface Area - {this.GetLateralSurfaceArea():F2}");
            result.AppendLine($"Volume - {this.GetVolume():F2}");

            return result.ToString().TrimEnd();
        }

        private void ValidateSide(double value, string sideName)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{sideName} cannot be zero or negative.");
            }
        }
    }
}
