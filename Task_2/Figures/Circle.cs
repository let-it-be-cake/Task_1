using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2.Figures
{
    public class Circle : Figure
    {
        //Central point of circle
        private (double x, double y) point;
        //Radius of circle
        double radius;
        double Radius {
            get => radius;
            set => radius = value > 0 ? value : throw new ArgumentException("Wrong radius");
        }
        public Circle(double x, double y, double r)
        {
            point.x = x;
            point.y = y;

            Radius = r;
        }

        public override double Area()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public override double[] GetSides()
        {
            return new double[] { Radius };
        }
        public override double Perimetr()
        {
            return 2 * Math.PI * Radius;
        }

    }
}
