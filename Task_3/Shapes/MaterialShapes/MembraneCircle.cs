using Shapes.BasicShapes;
using Shapes.Interfaces;
using System;

namespace Shapes.MaterialShapes
{
    /// <summary>
    /// Class for membrane circles
    /// </summary>
    public class MembraneCircle : Circle, Membrane
    {
        /// <summary>
        /// Membrane circle constructor
        /// </summary>
        /// <param name="radius">Set the circle radius</param>
        /// <param name="shape">Set the shape to cut</param>
        public MembraneCircle(double radius, Shape shape = null)
            : base(radius, shape)
        {
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
                throw new ArgumentNullException(nameof(obj));

            return obj is MembraneCircle circle &&
                   Radius == circle.Radius;
        }

        public override int GetHashCode()
            => HashCode.Combine(base.GetHashCode(), Radius);

        public override string ToString() => base.ToString();
    }
}