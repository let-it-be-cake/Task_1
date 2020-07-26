using Shapes.BasicShapes;
using Shapes.Interfaces;
using Shapes.MaterialShapes;
using System.Collections.Generic;
using System.Reflection;

namespace IO
{
    public class StreamWriter
    {
        /// <summary>
        /// File path
        /// </summary>
        private string _path = null;

        /// <summary>
        /// Create stream writer class
        /// </summary>
        /// <param name="path">File path</param>
        public StreamWriter(string path = null) => _path = path;

        /// <summary>
        /// Sets the file path
        /// </summary>
        /// <param name="path">File path</param>
        public void SetPath(string path) => _path = path;

        /// <summary>
        /// Write a collection of Shapes from a file
        /// </summary>
        /// <param name="shapes">Shape collection to write</param>
        public void Write(IEnumerable<Shape> shapes)
        {
            #region Methods

            string Tabs(int value)
            {
                string tabs = "";
                for (int i = 0; i < value; i++)
                    tabs += " ";
                return tabs;
            }

            #endregion Methods

            var stream = new System.IO.StreamWriter(_path, false, System.Text.Encoding.UTF8);

            stream.WriteLine("<Wrap>");

            foreach (var shape in shapes)
            {
                #region Write Circle

                if (shape is Circle)
                {
                    var Circle = (Circle)shape;

                    if (shape is Membrane)
                        stream.WriteLine(Tabs(2) + "<MembraneCircle>");
                    else if (shape is Paper)
                        stream.WriteLine(Tabs(2) + "<PaperCircle>");

                    stream.WriteLine(Tabs(4)
                                    + "<Radius>"
                                    + Circle.Radius.ToString()
                                    + "</Radius>");

                    if (shape is Paper)
                    {
                        var paperCircle = (PaperCircle)shape;

                        stream.WriteLine(Tabs(4)
                                        + "<IsColoring>"
                                        + paperCircle.IsColoring.ToString()
                                        + "</IsColoring>");

                        stream.WriteLine(Tabs(4)
                                        + "<Color>"
                                        + paperCircle.Color.ToString()
                                        + "</Color>");
                    }

                    if (shape is Membrane)
                        stream.WriteLine(Tabs(2) + "</MembraneCircle>");
                    else if (shape is Paper)
                        stream.WriteLine(Tabs(2) + "</PaperCircle>");
                }
                else

                #endregion Write Circle

                #region Write Rectangle

                if (shape is Rectangle)
                {
                    var Rectangle = (Rectangle)shape;

                    if (shape is Membrane)
                        stream.WriteLine(Tabs(2) + "<MembraneRectangle>");
                    else if (shape is Paper)
                        stream.WriteLine(Tabs(2) + "<PaperRectangle>");

                    stream.WriteLine(Tabs(4)
                                    + "<Height>"
                                    + Rectangle.Height.ToString()
                                    + "</Height>");

                    stream.WriteLine(Tabs(4)
                                    + "<Width>"
                                    + Rectangle.Width.ToString()
                                    + "</Width>");

                    if (shape is Paper)
                    {
                        var paperRectangle = (PaperRectangle)shape;

                        stream.WriteLine(Tabs(4)
                                        + "<IsColoring>"
                                        + paperRectangle.IsColoring.ToString()
                                        + "</IsColoring>");

                        stream.WriteLine(Tabs(4)
                                        + "<Color>"
                                        + paperRectangle.Color.ToString()
                                        + "</Color>");
                    }

                    if (shape is Membrane)
                        stream.WriteLine(Tabs(2) + "</MembraneRectangle>");
                    else if (shape is Paper)
                        stream.WriteLine(Tabs(2) + "</PaperRectangle>");
                }
                else

                #endregion Write Rectangle

                #region Write Triangle

                if (shape is Triangle)
                {
                    var membraneTriangle = (Triangle)shape;

                    if (shape is Membrane)
                        stream.WriteLine(Tabs(2) + "<MembraneTriangle>");
                    else if (shape is Paper)
                        stream.WriteLine(Tabs(2) + "<PaperTriangle>");

                    stream.WriteLine(Tabs(4)
                                    + "<Side1>"
                                    + membraneTriangle.Side1.ToString()
                                    + "</Side1>");

                    stream.WriteLine(Tabs(4)
                                    + "<Side2>"
                                    + membraneTriangle.Side2.ToString()
                                    + "</Side2>");

                    stream.WriteLine(Tabs(4)
                                    + "<Side3>"
                                    + membraneTriangle.Side3.ToString()
                                    + "</Side3>");

                    if (shape is Paper)
                    {
                        var paperTriangle = (PaperTriangle)shape;

                        stream.WriteLine(Tabs(4)
                                        + "<IsColoring>"
                                        + paperTriangle.IsColoring.ToString()
                                        + "</IsColoring>");

                        stream.WriteLine(Tabs(4)
                                        + "<Color>"
                                        + paperTriangle.Color.ToString()
                                        + "</Color>");
                    }

                    if (shape is Membrane)
                        stream.WriteLine(Tabs(2) + "</MembraneTriangle>");
                    else if (shape is Paper)
                        stream.WriteLine(Tabs(2) + "</PaperTriangle>");

                    #endregion Write Triangle
                }
            }
            stream.Write("</Wrap>");
            stream.Close();
        }

        #region reflection write

        //Normal realization, with reflection
        private void Write(IEnumerable<Shape> shapes, bool reflection)
        {
            #region Methods

            string Tabs(int value)
            {
                string tabs = "";
                for (int i = 0; i < value; i++)
                {
                    tabs += " ";
                }
                return tabs;
            }

            #endregion Methods

            List<FieldInfo> fieldInfos = new List<FieldInfo>();

            var bindingFlags = BindingFlags.Instance |
                               BindingFlags.NonPublic |
                               BindingFlags.Public;

            var stream = new System.IO.StreamWriter(_path, false, System.Text.Encoding.UTF8);

            stream.WriteLine("<Wrap>");

            foreach (var shape in shapes)
            {
                fieldInfos.Clear();

                var type = shape.GetType();
                var typeName = type.Name;
                while (type.Name != "Object")
                {
                    fieldInfos.AddRange(type.GetFields(bindingFlags));
                    type = type.BaseType;
                }

                stream.WriteLine(Tabs(2) + "<" + shape.GetType().Name + ">");

                foreach (var field in fieldInfos)
                {
                    stream.WriteLine(Tabs(4)
                                    + "<" + field.Name + ">"
                                    + field.GetValue(shape).ToString()
                                    + "</" + field.Name + ">");
                }
                stream.WriteLine(Tabs(2) + "</" + shape.GetType().Name + ">");
            }
            stream.Write("</Wrap>");
            stream.Close();
        }

        #endregion reflection write
    }
}