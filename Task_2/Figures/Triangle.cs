using System;

namespace Task_2.Figures
{
    public class Triangle : Figure
    {
        //Points of trianlge
        private (double x, double y) point1, point2, point3;
        //Sides of triangle
        private double side1, side2, side3;

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            side1 = FromPoints(x1, y1, x2, y2);
            side2 = FromPoints(x2, y2, x3, y3);
            side3 = FromPoints(x1, y1, x3, y3);

            point1 = (x1, y1);
            point2 = (x2, y2);
            point3 = (x3, y3);

        }
        public Triangle(double side1, double side2, double side3)
        {
            if (!CanExist(side1, side2, side3)) throw new ArgumentException("This triangle can't exist!");
            this.side1 = side1;
            this.side2 = side2;
            this.side3 = side3;
        }
        //New method for checking existense of triangle
        private new static bool CanExist(params double[] sides)
        {
            if (sides[0] < (sides[1] + sides[2]) &&
                sides[1] < (sides[0] + sides[2]) &&
                sides[2] < (sides[1] + sides[0])) return true;
            return false;
        }

        public override double Area()
        {
            //hPer - Half perimetr of triangle
            var hPer = (side1 + side2 + side3) / 2;
            return Math.Sqrt((hPer - side1) * (hPer - side2) * (hPer - side3) * hPer);
        }
        public override double[] GetSides()
        {
            return new double[] { side1, side2, side3 };
        }
        public override double Perimetr()
        {
            return side1 + side2 + side3;
        }
    }
}