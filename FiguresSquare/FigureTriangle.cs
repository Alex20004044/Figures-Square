using System;

namespace FiguresSquare
{
    public class FigureTriangle : FigureBase
    {
        public double A { get; private set; }
        public double B { get; private set; }
        public double C { get; private set; }

        public FigureTriangle(double a, double b, double c)
        {
            if (a < 0 || b < 0 || c < 0)
                throw new ArgumentException("Side can't be less then 0");

            if (a >= b + c || b >= a + c || c >= a + b)
                throw new ArgumentException("Triangle with this sides is impossible to create");

            A = a;
            B = b;
            C = c;
        }

        public override double GetSquare()
        {
            double p = (A + B + C) / 2;

            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }

        public bool IsRightTriangle()
        {
            double[] sides = (new double[] { A, B, C });
            Array.Sort(sides, (x, y) => y.CompareTo(x));

            return sides[0] * sides[0] == sides[1] * sides[1] + sides[2] * sides[2];
        }


        public override string ToString()
        {
            return $"Triangle with sides: {{{A}, {B}, {C}}} and square: {GetSquare()}";
        }
    }
}
