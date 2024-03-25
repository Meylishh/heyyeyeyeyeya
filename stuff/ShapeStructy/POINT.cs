using System;
using System.Drawing;

namespace stuff.ShapeStructy
{
    public struct POINT
    {
        public POINT(double x, double y)
        {
            X = x;
            Y = y;
        }
        public double X;
        public double Y;
    }

    public struct Rectangle
    {
        public Rectangle(POINT topLeft, POINT bottomRight)
        {
            TopLeft = topLeft;
            BottomRight = bottomRight;
        }
        public POINT TopLeft;
        public POINT BottomRight;

        public double Area()
        {
            var x = Math.Abs(TopLeft.X - BottomRight.X);
            var y = Math.Abs(TopLeft.Y - BottomRight.Y);
            return x * y;
        }

        public bool Contains(POINT point)
        {
            if (TopLeft.X <= point.X && point.X <= BottomRight.X)
            {
                if (BottomRight.Y <= point.Y && point.Y <= TopLeft.Y)
                {
                    return true;
                }
            }
            return false;
        }
    }
}