using Shapes.BasicShapes;
using Shapes.Enums;
using Shapes.Interfaces;
using System;

namespace Shapes.MaterialShapes
{
    /// <summary>
    /// Class for paper rectangle
    /// </summary>
    public class PaperRectangle : Rectangle, Paper
    {
        private bool _isColoring = false;
        private Color _color = Color.White;
        public bool IsColoring { get => _isColoring; }
        public Color Color { get => _color; }

        /// <summary>
        /// Paper rectangle constructor
        /// </summary>
        /// <param name="width">Set the rectangle width</param>
        /// <param name="height">Set the rectangle height</param>
        /// <param name="shape">Set the shape to cut</param>
        public PaperRectangle(double width, double height, Shape shape = null)
            : base(width, height, shape)
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
            else new Exception("Shape is colored!");
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return obj is PaperRectangle rectangle &&
                   Width == rectangle.Width &&
                   Height == rectangle.Height &&
                   IsColoring == rectangle.IsColoring &&
                   Color == rectangle.Color;
        }

        public override int GetHashCode() =>
            HashCode.Combine(base.GetHashCode(), Width, Height, IsColoring, Color);

        public override string ToString() => base.ToString();
    }
}