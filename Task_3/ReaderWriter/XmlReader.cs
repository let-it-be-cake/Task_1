using Shapes.Enums;
using Shapes.Interfaces;
using Shapes.MaterialShapes;
using System;
using System.Collections.Generic;
using System.Xml;

namespace IO
{
    public class XmlReader
    {
        /// <summary>
        /// File path
        /// </summary>
        private string _path = null;

        /// <summary>
        /// Create xml reader class
        /// </summary>
        /// <param name="path">File path</param>
        public XmlReader(string path = null) => _path = path;

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
            List<Shape> shapes = new List<Shape>();
            Shape shape = null;

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(_path);
            // получим корневой элемент
            XmlElement xRoot = xDoc.DocumentElement;
            // обход всех узлов в корневом элементе
            foreach (XmlNode xnode in xRoot)
            {
                var children = xnode.ChildNodes;
                switch (xnode.Name)
                {
                    case "PaperTriangle":
                        {
                            double side1 = Convert.ToDouble(children[0].InnerText);
                            double side2 = Convert.ToDouble(children[1].InnerText);
                            double side3 = Convert.ToDouble(children[2].InnerText);

                            shape = new PaperTriangle(side1, side2, side3);

                            if (Convert.ToBoolean(children[3].InnerText))
                            {
                                Color color = (Color)Enum.Parse(typeof(Color), children[4].InnerText);
                                (shape as Paper).Coloring(color);
                            }
                        }
                        break;

                    case "MembraneTriangle":
                        {
                            double side1 = Convert.ToDouble(children[0].InnerText);
                            double side2 = Convert.ToDouble(children[1].InnerText);
                            double side3 = Convert.ToDouble(children[2].InnerText);

                            shape = new MembraneTriangle(side1, side2, side3);
                        }
                        break;

                    case "PaperCircle":
                        {
                            double radius = Convert.ToDouble(children[0].InnerText);

                            shape = new PaperCircle(radius);

                            if (Convert.ToBoolean(children[1].InnerText))
                            {
                                Color color = (Color)Enum.Parse(typeof(Color), children[2].InnerText);
                                (shape as Paper).Coloring(color);
                            }
                        }
                        break;

                    case "MembraneCircle":
                        {
                            double radius = Convert.ToDouble(children[0].InnerText);

                            shape = new MembraneCircle(radius);
                        }
                        break;

                    case "PaperRectangle":
                        {
                            double height = Convert.ToDouble(children[0].InnerText);
                            double width = Convert.ToDouble(children[1].InnerText);

                            shape = new PaperRectangle(width, height);
                            if (Convert.ToBoolean(children[2].InnerText))
                            {
                                Color color = (Color)Enum.Parse(typeof(Color), children[3].InnerText);
                                (shape as Paper).Coloring(color);
                            }
                        }
                        break;

                    case "MembraneRectangle":
                        {
                            double height = Convert.ToDouble(children[0].InnerText);
                            double width = Convert.ToDouble(children[1].InnerText);

                            shape = new MembraneRectangle(width, height);
                        }
                        break;

                    default:
                        break;
                }
                shapes.Add(shape);
            }
            return shapes;
        }
    }
}