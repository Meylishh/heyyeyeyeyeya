using System;

namespace stuff.Shapes
{
    public class Circle: Shape
    {
        public readonly float Radius;
        public Circle(float radius)
        {
            Radius = radius;
            if (!Exists())
            {
                throw new Exception(ExceptionMessage);
            }
        }
        public override float Area()
        {
            return (float)Math.PI * (Radius * Radius);
        }

        public override float Perimeter()
        {
            return 2 * (float)Math.PI * Radius;
        }

        protected override bool Exists()
        {
            return Radius > 0;
        }
    }
}