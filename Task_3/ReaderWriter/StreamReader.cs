using Shapes.Enums;
using Shapes.Interfaces;
using Shapes.MaterialShapes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace IO
{
    public class StreamReader
    {
        /// <summary>
        /// File path
        /// </summary>
        private string _path = null;

        /// <summary>
        /// Create stream reader class
        /// </summary>
        /// <param name="path">File path</param>
        public StreamReader(string path = null) => _path = path;

        /// <summary>
        /// Sets the file path
        /// </summary>
        /// <param name="path">File path</param>
        public void SetPath(string path) => _path = path;

        /// <summary>
        /// Reading a collection of Shapes from a file
        /// </summary>
        /// <returns>Shape collection</returns>
        public IEnumerable<Shape> Read()
        {
            var stream = new System.IO.StreamReader(_path, Encoding.GetEncoding("UTF-8"));

            Regex regex = new Regex(@"(?<=>).*(?=<\/)");

            List<Shape> shapes = new List<Shape>();
            Shape shape = null;
            string line = null;

            stream.ReadLine();

            while ((line = stream.ReadLine()) != "</Wrap>")
            {
                line = line.Trim();
                line = line.Substring(1);
                line = line.Remove(line.Length - 1);
                switch (line)
                {
                    case "PaperTriangle":
                        {
                            line = stream.ReadLine();
                            double side1 = Convert.ToDouble(regex.Match(line).Value);
                            line = stream.ReadLine();
                            double side2 = Convert.ToDouble(regex.Match(line).Value);
                            line = stream.ReadLine();
                            double side3 = Convert.ToDouble(regex.Match(line).Value);

                            shape = new PaperTriangle(side1, side2, side3);

                            line = stream.ReadLine();
                            if (Convert.ToBoolean(regex.Match(line).Value))
                            {
                                line = stream.ReadLine();
                                Color color = (Color)Enum.Parse(typeof(Color), regex.Match(line).Value);
                                (shape as Paper).Coloring(color);
                            }
                            else stream.ReadLine();
                        }
                        break;

                    case "MembraneTriangle":
                        {
                            line = stream.ReadLine();
                            double side1 = Convert.ToDouble(regex.Match(line).Value);
                            line = stream.ReadLine();
                            double side2 = Convert.ToDouble(regex.Match(line).Value);
                            line = stream.ReadLine();
                            double side3 = Convert.ToDouble(regex.Match(line).Value);

                            shape = new MembraneTriangle(side1, side2, side3);
                        }
                        break;

                    case "PaperCircle":
                        {
                            line = stream.ReadLine();
                            double radius = Convert.ToDouble(regex.Match(line).Value);

                            shape = new PaperCircle(radius);

                            line = stream.ReadLine();
                            if (Convert.ToBoolean(regex.Match(line).Value))
                            {
                                line = stream.ReadLine();
                                Color color = (Color)Enum.Parse(typeof(Color), regex.Match(line).Value);
                                (shape as Paper).Coloring(color);
                            }
                            else stream.ReadLine();
                        }
                        break;

                    case "MembraneCircle":
                        {
                            line = stream.ReadLine();
                            double radius = Convert.ToDouble(regex.Match(line).Value);

                            shape = new MembraneCircle(radius);
                        }
                        break;

                    case "PaperRectangle":
                        {
                            line = stream.ReadLine();
                            double height = Convert.ToDouble(regex.Match(line).Value);
                            line = stream.ReadLine();
                            double width = Convert.ToDouble(regex.Match(line).Value);

                            shape = new PaperRectangle(width, height);

                            line = stream.ReadLine();
                            if (Convert.ToBoolean(regex.Match(line).Value))
                            {
                                line = stream.ReadLine();
                                Color color = (Color)Enum.Parse(typeof(Color), regex.Match(line).Value);
                                (shape as Paper).Coloring(color);
                            }
                            else stream.ReadLine();
                        }
                        break;

                    case "MembraneRectangle":
                        {
                            line = stream.ReadLine();
                            double height = Convert.ToDouble(regex.Match(line).Value);
                            line = stream.ReadLine();
                            double width = Convert.ToDouble(regex.Match(line).Value);

                            shape = new MembraneRectangle(width, height);
                        }
                        break;

                    default:
                        break;
                }
                stream.ReadLine();
                shapes.Add(shape);
            }
            stream.Close();
            return shapes;
        }
    }
}