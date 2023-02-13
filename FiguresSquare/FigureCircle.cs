using System;

namespace FiguresSquare
{
    public class FigureCircle : FigureBase
    {
        public double Radius { get; private set; }

        public FigureCircle(double radius)
        {
            if (radius < 0)
                throw new ArgumentException("Radius can't be less then 0");

            this.Radius = radius;
        }

        public override double GetSquare()
        {
            //Если будет часто происходить запрашивание доступа к площади фигуры и производительность важнее занимаемой памяти, 
            //то можно не вычислять каждый раз, а сохранить в переменной
            return Radius * Radius * Math.PI;
        }

        public override string ToString()
        {
            return $"Circle with radius: {Radius} and square: {GetSquare()}";
        }
    }
}
