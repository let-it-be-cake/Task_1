using Shapes.Interfaces;
using System;

namespace Shapes.BasicShapes
{
    /// <summary>
    /// Abstract base rectangle class
    /// </summary>
    public abstract class Rectangle : Shape
    {
        private double _height;
        private double _width;

        public double Width
        {
            get => _width;
            private set
            {
                if (value > 0) _width = value;
                else new ArgumentException("The side can't be negative!");
            }
        }

        public double Height
        {
            get => _height;
            private set
            {
                if (value > 0) _height = value;
                else new ArgumentException("The side can't be negative!");
            }
        }

        /// <summary>
        /// Rectangle constructor
        /// </summary>
        /// <param name="width">Set the rectangle width</param>
        /// <param name="height">Set the rectangle height</param>
        /// <param name="shape">Set the shape to cut</param>
        public Rectangle(double width, double height, Shape shape = null)
        {
            Width = width;
            Height = height;


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

            return obj is Rectangle rectangle &&
                   Width == rectangle.Width &&
                   Height == rectangle.Height;
        }

        public override int GetHashCode() => HashCode.Combine(Width, Height);

        double Shape.Area() => Width * Height;

        double Shape.Perimeter() => 2 * (Width + Height);
    }
}