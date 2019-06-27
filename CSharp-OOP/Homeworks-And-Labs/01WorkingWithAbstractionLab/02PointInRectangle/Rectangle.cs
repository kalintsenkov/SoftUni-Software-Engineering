namespace _02PointInRectangle
{
    public class Rectangle
    {
        public Rectangle(Point topLeft, Point bottomRight)
        {
            this.TopLeft = topLeft;
            this.BottomRight = bottomRight;
        }

        public Point TopLeft { get; private set; }

        public Point BottomRight { get; private set; }

        public bool Contains(Point point)
        {
            bool isInHorizontal =
                point.X >= this.TopLeft.X &&
                point.X <= this.BottomRight.X;

            bool isInVertical =
                point.Y >= this.TopLeft.Y &&
                point.Y <= this.BottomRight.Y;

            bool isInRectangle = isInHorizontal && isInVertical;

            return isInRectangle;
        }
    }
}
