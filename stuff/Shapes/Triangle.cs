using System;

namespace stuff.Shapes
{
    public class Triangle: Shape
    {
        public readonly float A;
        public readonly float B;
        public readonly float C;
        public Triangle(float a, float b, float c)
        {
            A = a;
            B = b;
            C = c;
            if (!Exists())
            {
                throw new Exception(ExceptionMessage);
            }
        }

        protected override bool Exists()
        {
            if (A > 0 && B > 0 && C > 0)
            {
                if (A + B > C && B + C > A && A + C > B)
                {
                    return true;
                }
            }
            return false;
        }
        public override float Area()
        {
            float p = (A + B + C) / 2;
            return (float)Math.Sqrt(p * (p - A) * (p - B) * (p - A));
        }

        public override float Perimeter()
        {
            return A + B + C;
        }
    }
}