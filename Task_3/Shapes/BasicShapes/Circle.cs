using Shapes.Interfaces;
using System;

namespace Shapes.BasicShapes
{
    /// <summary>
    /// Abstract base circle class
    /// </summary>
    public abstract class Circle : Shape
    {
        private double _radius;

        public double Radius
        {
            get => _radius;
            private set
            {
                if (value > 0) _radius = value;
                else throw new ArgumentException("The radius can't be negative!");
            }
        }

        /// <summary>
        /// Circle constructor
        /// </summary>
        /// <param name="radius">Set the circle radius</param>
        /// <param name="shape">Set the shape to cut</param>
        public Circle(double radius, Shape shape = null)
        {
            Radius = radius;

            if (shape is Paper && this is Membrane ||
                shape is Membrane && this is Paper)
                throw new Exception("Different materials!");

                if (shape != null &&
                    shape.Area() < ((Shape)this).Area())
                throw new Exception("Incorrect shape area!");
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
                throw new ArgumentNullException(nameof(obj));

            return obj is Circle circle &&
                   Radius == circle.Radius;
        }

        public override int GetHashCode() => HashCode.Combine(Radius);

        double Shape.Area() => Math.PI * Radius * Radius;

        double Shape.Perimeter() => 2 * Math.PI * Radius;
    }
}