using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_2.Figures
{
    public abstract class Figure
    {
        public static IEnumerable<Figure> Equal(IEnumerable<Figure> figures, Figure figure)
        {
            foreach (Figure value in figures)
            {
                if (value.GetSides().SequenceEqual(figure.GetSides()))
                    yield return value;
            }
        }
        //Calculating the side by points
        protected static double FromPoints(double x1, double y1, double x2, double y2)
        {
            var xSide = Math.Pow((Math.Max(x1, x2) - Math.Min(x1, x2)), 2);
            var ySide = Math.Pow((Math.Max(y1, y2) - Math.Min(y1, y2)), 2);
            return Math.Sqrt(xSide + ySide);
        }

        // Can the shape exist?
        protected static bool CanExist(params double[] sides)
        {
            var maxSide = sides.Max();
            return (sides.Sum() - 2 * maxSide) < 0 ? false : true;
        }
        //Abstract method to calculate perimetr
        public abstract double Perimetr();
        //Abstract method to calculate Area
        public abstract double Area();
        //Abstract method to get sided of shape
        public abstract double[] GetSides();
    }
}