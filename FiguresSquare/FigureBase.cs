using System.Collections;
using System.Linq;

namespace FiguresSquare
{
    public abstract class FigureBase : IFigure
    {

        public abstract double GetSquare();
        public override string ToString()
        {
            return $"Some figure with square: {GetSquare()}";
        }
    }
}
