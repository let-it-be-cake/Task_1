using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task_2.Figures
{
    public class AbstractFigure : Figure
    {
        double[] sides;
        //If number of sides<4 then this is a triangle, we need an abstract shape, like polygon
        public AbstractFigure(double side1, double side2, double side3, params double[] sides)
        {

            var tmp = new List<double>();
            tmp.Add(side1);
            tmp.Add(side2);
            tmp.Add(side3);
            tmp.AddRange(sides);
            this.sides = tmp.ToArray();
            if (!CanExist(this.sides)) throw new ArgumentException("This figure can't exist!");
        }
        public override double Area()
        {
            //Higher mathematics has left us
            return 0;
        }
        
        public override double[] GetSides()
        {
            return sides;
        }

        public override double Perimetr()
        {
            return sides.Sum();
        }
    }
}
