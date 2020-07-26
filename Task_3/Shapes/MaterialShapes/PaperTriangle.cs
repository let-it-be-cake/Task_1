using Shapes.BasicShapes;
using Shapes.Enums;
using Shapes.Interfaces;
using System;

namespace Shapes.MaterialShapes
{
    /// <summary>
    /// Class for paper triangle
    /// </summary>
    public class PaperTriangle : Triangle, Paper
    {
        private bool _isColoring = false;
        private Color _color = Color.White;
        public bool IsColoring { get => _isColoring; }
        public Color Color { get => _color; }

        /// <summary>
        /// Paper triangle constructor
        /// </summary>
        /// <param name="side1">Set the triangle 1 side</param>
        /// <param name="side2">Set the triangle 2 side</param>
        /// <param name="side3">Set the triangle 3 side</param>
        /// <param name="shape">Set the shape to cut</param>
        public PaperTriangle(double side1, double side2, double side3, Shape shape = null)
            : base(side1, side2, side3, shape)
        {
        }

        /// <summary>
        /// Set shape color
        /// </summary>
        /// <param name="color">Shape color</param>
        /// /// //Method of paper interface
        public void Coloring(Color color)
        {
            if (!IsColoring)
            {
                _isColoring = true;
                _color = color;
            }
            else throw new Exception("Shape is colored!");
        }

        public override bool Equals(object obj)
        {
            return obj is PaperTriangle triangle &&
                   Side1 == triangle.Side1 &&
                   Side2 == triangle.Side2 &&
                   Side3 == triangle.Side3 &&
                   IsColoring == triangle.IsColoring &&
                   Color == triangle.Color;
        }

        public override int GetHashCode() =>
            HashCode.Combine(base.GetHashCode(), Side1, Side2, Side3, IsColoring, Color);

        public override string ToString() => base.ToString();
    }
}