using Shapes.BasicShapes;
using Shapes.Enums;
using Shapes.Interfaces;
using System;

namespace Shapes.MaterialShapes
{
    /// <summary>
    /// Class for paper circles
    /// </summary>
    public class PaperCircle : Circle, Paper
    {
        private bool _isColoring = false;
        private Color _color = Color.White;
        public bool IsColoring { get => _isColoring; }
        public Color Color { get => _color; }

        /// <summary>
        /// Paper circle constructor
        /// </summary>
        /// <param name="radius">Set the circle radius</param>
        /// <param name="shape">Set the shape to cut</param>
        public PaperCircle(double radius, Shape shape = null) : base(radius, shape)
        {
        }

        /// <summary>
        /// Set shape color
        /// </summary>
        /// <param name="color">Shape color</param>
        /// //Method of paper interface
        public void Coloring(Color color)
        {
            if (!IsColoring)
            {
                _isColoring = true;
                _color = color;
            }
            else new Exception("Shape is colored!");
        }

        public override bool Equals(object obj)
        {
            return obj is PaperCircle circle &&
                   Radius == circle.Radius &&
                   IsColoring == circle.IsColoring &&
                   Color == circle.Color;
        }

        public override int GetHashCode()
            => HashCode.Combine(base.GetHashCode(), Radius);

        public override string ToString() => base.ToString();
    }
}