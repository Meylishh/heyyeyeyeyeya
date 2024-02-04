using System;
using stuff.ZOOO;

namespace stuff.Shapes
{
    public class Rectangle: Shape
    {
        public readonly float A;
        public readonly float B;
        public Rectangle(float a, float b)
        {
            A = a;
            B = b;
            if (!Exists())
            {
                throw new Exception(ExceptionMessage);
            }
        }
        public override float Area()
        {
            return A * B;
        }

        public override float Perimeter()
        {
            return A + B * 2;
        }

        protected override bool Exists()
        {
            return A > 0 && B > 0;
        }
    }
}