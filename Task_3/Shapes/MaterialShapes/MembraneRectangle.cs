using Shapes.BasicShapes;
using Shapes.Interfaces;
using System;

namespace Shapes.MaterialShapes
{
    /// <summary>
    /// Class for membrane rectangle
    /// </summary>
    public class MembraneRectangle : Rectangle, Membrane
    {
        /// <summary>
        /// Membrane rectangle constructor
        /// </summary>
        /// <param name="width">Set the rectangle width</param>
        /// <param name="height">Set the rectangle height</param>
        /// <param name="shape">Set the shape to cut</param>
        public MembraneRectangle(double width, double height, Shape shape = null)
            : base(width, height, shape)
        {
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
                throw new ArgumentNullException(nameof(obj));

            return obj is MembraneRectangle rectangle &&
                   Width == rectangle.Width &&
                   Height == rectangle.Height;
        }

        public override int GetHashCode()
            => HashCode.Combine(base.GetHashCode(), Width, Height);

        public override string ToString() => base.ToString();
    }
}