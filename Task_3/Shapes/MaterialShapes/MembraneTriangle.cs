using Shapes.BasicShapes;
using Shapes.Interfaces;
using System;

namespace Shapes.MaterialShapes
{
    /// <summary>
    /// Class for membrane triangle
    /// </summary>
    public class MembraneTriangle : Triangle, Membrane
    {
        /// <summary>
        /// Membrane triangle constructor
        /// </summary>
        /// <param name="side1">Set the triangle 1 side</param>
        /// <param name="side2">Set the triangle 2 side</param>
        /// <param name="side3">Set the triangle 3 side</param>
        /// <param name="shape">Set the shape to cut</param>
        public MembraneTriangle(double side1, double side2, double side3, Shape shape = null)
            : base(side1, side2, side3, shape)
        {
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return obj is MembraneTriangle triangle &&
                   Side1 == triangle.Side1 &&
                   Side2 == triangle.Side2 &&
                   Side3 == triangle.Side3;
        }

        public override int GetHashCode()
            => HashCode.Combine(base.GetHashCode(), Side1, Side2, Side3);

        public override string ToString() => base.ToString();
    }
}