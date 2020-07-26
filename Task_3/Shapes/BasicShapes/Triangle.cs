using Shapes.Interfaces;
using System;

namespace Shapes.BasicShapes
{
    /// <summary>
    /// Abstract base triangle class
    /// </summary>
    public abstract class Triangle : Shape
    {
        private double _side1, _side2, _side3;

        public double Side1
        {
            get => _side1;
            set
            {
                if (value > 0) _side1 = value;
                else throw new ArgumentException("The side can't be negative!");
            }
        }

        public double Side2
        {
            get => _side2;
            private set
            {
                if (value > 0) _side2 = value;
                else throw new ArgumentException("The side can't be negative!");
            }
        }

        public double Side3
        {
            get => _side3;
            private set
            {
                if (value > 0) _side3 = value;
                else throw new ArgumentException("The side can't be negative!");
            }
        }
        /// <summary>
        /// Rectangle constructor
        /// </summary>
        /// <param name="side1">Set the tirangle side1</param>
        /// <param name="side2">Set the tirangle side2</param>
        /// <param name="side3">Set the tirangle side3</param>
        /// <param name="shape">Set the shape to cut</param>
        protected Triangle(double side1, double side2, double side3, Shape shape = null)
        {
            if (CanExist(side1, side2, side3)) new ArgumentException("Shape can't exist");
            Side1 = side1;
            Side2 = side2;
            Side3 = side3;


            if (shape is Paper && this is Membrane ||
                shape is Membrane && this is Paper)
                throw new Exception("Different materials!");

            if (shape != null &&
                shape.Area() < ((Shape)this).Area())
                throw new Exception("Incorrect shape area!");
        }

        private bool CanExist(double side1, double side2, double side3)
        {
            if (side1 + side2 < side3 &&
                side1 + side3 < side2 &&
                side2 + side3 < side1)
                return true;
            else
                return false;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
                throw new ArgumentNullException(nameof(obj));

            return obj is Triangle triangle &&
                   Side1 == triangle.Side1 &&
                   Side2 == triangle.Side2 &&
                   Side3 == triangle.Side3;
        }

        public override int GetHashCode() => HashCode.Combine(Side1, Side2, Side3);

        double Shape.Area()
        {
            var hPer = (Side1 + Side2 + Side3) / 2;
            return Math.Sqrt((hPer - Side1) * (hPer - Side2) * (hPer - Side3) * hPer);
        }

        double Shape.Perimeter() => Side1 + Side2 + Side3;
    }
}