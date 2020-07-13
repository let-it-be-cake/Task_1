using System;

namespace Task_2.Figures
{
    public class Rectangle : Figure
    {
        private (double x, double y) point1, point2;
        private double side1, side2;

        public Rectangle(double side1, double side2)
        {
            this.side1 = side1;
            this.side2 = side2;
        }

        public Rectangle(double x1, double y1, double x2, double y2)
        {
            point1.x = x1;
            point1.y = y1;
            point2.x = x2;
            point2.y = y2;

            side1 = Math.Max(x1, x2) - Math.Min(x1, x2);
            side2 = Math.Max(y1, y2) - Math.Min(y1, y2);
        }

        public override double Area()
        {
            return side1 * side2;
        }

        public override double[] GetSides()
        {
            return new double[] { side1, side2 };
        }

        public override double Perimetr()
        {
            return 2 * (side1 + side2);
        }
    }
}