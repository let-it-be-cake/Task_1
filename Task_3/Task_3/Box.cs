using Shapes.BasicShapes;
using Shapes.Interfaces;
using IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Girl
{
    /// <summary>
    /// Shape types 
    /// </summary>
    public enum Shapes
    {
        All,
        Membrane,
        Paper,
    }

    /// <summary>
    /// Box class for girl
    /// </summary>
    public class Box
    {
        private List<Shape> _shapes = new List<Shape>();

        /// <summary>
        /// Is there a shape in the box
        /// </summary>
        /// <param name="shape">Shape to check</param>
        /// <returns></returns>
        private bool ShapeInBox(Shape shape)
        {
            foreach (var listShape in _shapes)
            {
                if (shape.Equals(listShape))
                {
                    throw new ArgumentException("This shape is already in the box!");
                }
            }
            return false;
        }

        /// <summary>
        /// Add shape in box
        /// </summary>
        /// <param name="shape">The shape that we are adding</param>
        public void Add(Shape shape)
        {
            if (_shapes.Count < 20 && !ShapeInBox(shape))
                _shapes.Add(shape);
            else throw new OverflowException("Too many shapes!");
        }

        /// <summary>
        /// Get a shape by index
        /// </summary>
        /// <param name="index">Index of shape</param>
        /// <returns>The shape for the index</returns>
        public Shape Peek(int index) => _shapes[index];


        /// <summary>
        /// Get a shape by index and delete it from the box
        /// </summary>
        /// <param name="index">Index of shape</param>
        /// <returns>The shape for the index</returns>
        public Shape Poll(int index)
        {
            var shape = _shapes[index];
            _shapes.RemoveAt(index);
            return shape;
        }


        /// <summary>
        /// Replace shape in box
        /// </summary>
        /// <param name="shape">The shape to replace</param>
        /// <param name="number">Number of the shape to replace</param>
        /// <returns></returns>
        public bool Replace(Shape shape, int number)
        {
            if (!ShapeInBox(shape))
            {
                _shapes[number] = shape;
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Find a similar shape
        /// </summary>
        /// <param name="shape">Original shape</param>
        /// <returns>Collection of shapes</returns>
        public IEnumerable<Shape> Find(Shape shape)
        {
            foreach (var listShape in _shapes)
            {
                if (shape.Area() == listShape.Area() &&
                    shape.Perimeter() == listShape.Perimeter())
                {
                    yield return listShape;
                }
            }
            yield break;
        }

        /// <summary>
        /// Current number of shapes in the box
        /// </summary>
        /// <returns>Number of shapes</returns>
        public int Count() => _shapes.Count;


        /// <summary>
        /// The area of all shapes in the box
        /// </summary>
        /// <returns>Total area</returns>
        public double Area()
        {
            double sumArea = 0;
            foreach (var listShape in _shapes)
                sumArea += listShape.Area();
            return sumArea;
        }

        /// <summary>
        /// The area of all shapes in the box
        /// </summary>
        /// <returns>Total perimeter</returns>
        public double Perimeter()
        {
            double sumPerimeter = 0;
            foreach (var listShape in _shapes)
                sumPerimeter += listShape.Perimeter();
            return sumPerimeter;
        }

        /// <summary>
        /// All circles in box
        /// </summary>
        /// <returns>Collection of circles</returns>
        public IEnumerable<Circle> GetCircles()
        {
            foreach (var listShape in _shapes)
            {
                if (listShape is Circle)
                    yield return (Circle)listShape;
            }
        }

        /// <summary>
        /// All membrane shapes in box
        /// </summary>
        /// <returns>Collection of membrane shapes</returns>
        public IEnumerable<Membrane> GetMembranes()
        {
            foreach (var listShape in _shapes)
            {
                if (listShape is Membrane)
                    yield return (Membrane)listShape;
            }
        }

        /// <summary>
        /// All paper shapes in box
        /// </summary>
        /// <returns>Collection of paper shapes</returns>
        public IEnumerable<Paper> GetPapers()
        {
            foreach (var listShape in _shapes)
            {
                if (listShape is Paper)
                    yield return (Paper)listShape;
            }
        }


        /// <summary>
        /// Save all shapes in a file by type using System.IO.StreamWriter
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <param name="type">Type of shapes</param>
        public void SaveShapesStream(string path, Shapes type)
        {
            StreamWriter stream = new StreamWriter(path);

            switch (type)
            {
                case Shapes.All:
                    stream.Write(_shapes);
                    break;

                case Shapes.Membrane:
                    stream.Write((IEnumerable<Shape>)GetMembranes());
                    break;

                case Shapes.Paper:
                    stream.Write((IEnumerable<Shape>)GetPapers());
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Save all shapes in a file by type using System.IO.StreamWriter
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <param name="type">Type of Shapes</param>
        public void LoadShapesStream(string path, Shapes type)
        {
            StreamReader stream = new StreamReader(path);

            switch (type)
            {
                case Shapes.All:
                    _shapes = stream.Read().ToList();
                    break;

                case Shapes.Membrane:
                    _shapes = stream.Read().ToList(); ;
                    break;

                case Shapes.Paper:
                    _shapes = stream.Read().ToList();
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Save all shapes in a file by type using System.Xml.XmlWriter
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <param name="type">Type of shapes</param>
        public void SaveShapesXml(string path, Shapes type)
        {
            XmlWriter stream = new XmlWriter(path);

            switch (type)
            {
                case Shapes.All:
                    stream.Write(_shapes);
                    break;

                case Shapes.Membrane:
                    stream.Write((IEnumerable<Shape>)GetMembranes());
                    break;

                case Shapes.Paper:
                    stream.Write((IEnumerable<Shape>)GetPapers());
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Save all shapes in a file by type using System.Xml.XmlWriter
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <param name="type">Type of shapes</param>
        public void LoadShapesXml(string path, Shapes type)
        {
            XmlReader stream = new XmlReader(path);

            switch (type)
            {
                case Shapes.All:
                    _shapes = stream.Read().ToList();
                    break;

                case Shapes.Membrane:
                    _shapes = stream.Read().ToList(); ;
                    break;

                case Shapes.Paper:
                    _shapes = stream.Read().ToList();
                    break;

                default:
                    break;
            }
        }
    }
}