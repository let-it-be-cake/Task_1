using Shapes.BasicShapes;
using Shapes.Interfaces;
using Shapes.MaterialShapes;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;

namespace IO
{
    public class XmlWriter
    {
        /// <summary>
        /// File path
        /// </summary>
        private string _path = null;

        /// <summary>
        /// Create xml writer class
        /// </summary>
        /// <param name="path">File path</param>
        public XmlWriter(string path = null) => _path = path;

        /// <summary>
        /// Sets the file path
        /// </summary>
        /// <param name="path">File path</param>
        public void SetPath(string path) => _path = path;
        /// <summary>
        /// Reading a collection of Shapes from a file
        /// </summary>
        /// <param name="shapes">Shape collection to write</param>
        public void Write(IEnumerable<Shape> shapes)
        {
            XmlDocument xDoc = new XmlDocument();
            XmlElement className = null;
            XmlElement fieldName = null;
            XmlText fieldValue = null;

            XmlElement wrapper = xDoc.CreateElement("Wrap");

            foreach (var shape in shapes)
            {
                #region Write Circle

                if (shape is Circle)
                {
                    var Circle = (Circle)shape;

                    if (shape is Membrane)
                        className = xDoc.CreateElement("MembraneCircle");
                    else if (shape is Paper)
                        className = xDoc.CreateElement("PaperCircle");

                    fieldName = xDoc.CreateElement("Radius");
                    fieldValue = xDoc.CreateTextNode(Circle.Radius.ToString());

                    fieldName.AppendChild(fieldValue);
                    className.AppendChild(fieldName);
                    if (shape is Paper)
                    {
                        var paperCircle = (PaperCircle)shape;

                        fieldName = xDoc.CreateElement("IsColoring");
                        fieldValue = xDoc.CreateTextNode(paperCircle.IsColoring.ToString());

                        fieldName.AppendChild(fieldValue);
                        className.AppendChild(fieldName);

                        fieldName = xDoc.CreateElement("Color");
                        fieldValue = xDoc.CreateTextNode(paperCircle.Color.ToString());

                        fieldName.AppendChild(fieldValue);
                        className.AppendChild(fieldName);
                    }
                }
                else

                #endregion Write Circle

                #region Write Rectangle

                if (shape is Rectangle)
                {
                    var Rectangle = (Rectangle)shape;

                    if (shape is Membrane)
                        className = xDoc.CreateElement("MembraneRectangle");
                    else if (shape is Paper)
                        className = xDoc.CreateElement("PaperRectangle");

                    fieldName = xDoc.CreateElement("Height");
                    fieldValue = xDoc.CreateTextNode(Rectangle.Height.ToString());

                    fieldName.AppendChild(fieldValue);
                    className.AppendChild(fieldName);

                    fieldName = xDoc.CreateElement("Width");
                    fieldValue = xDoc.CreateTextNode(Rectangle.Width.ToString());

                    fieldName.AppendChild(fieldValue);
                    className.AppendChild(fieldName);

                    if (shape is Paper)
                    {
                        var paperRectangle = (PaperRectangle)shape;

                        fieldName = xDoc.CreateElement("IsColoring");
                        fieldValue = xDoc.CreateTextNode(paperRectangle.IsColoring.ToString());

                        fieldName.AppendChild(fieldValue);
                        className.AppendChild(fieldName);

                        fieldName = xDoc.CreateElement("Color");
                        fieldValue = xDoc.CreateTextNode(paperRectangle.Color.ToString());

                        fieldName.AppendChild(fieldValue);
                        className.AppendChild(fieldName);
                    }
                }
                else

                #endregion Write Rectangle

                #region Write Triangle

                if (shape is Triangle)
                {
                    var membraneTriangle = (Triangle)shape;

                    if (shape is Membrane)
                        className = xDoc.CreateElement("MembraneTriangle");
                    else if (shape is Paper)
                        className = xDoc.CreateElement("PaperTriangle");

                    fieldName = xDoc.CreateElement("Side1");
                    fieldValue = xDoc.CreateTextNode(membraneTriangle.Side1.ToString());

                    fieldName.AppendChild(fieldValue);
                    className.AppendChild(fieldName);

                    fieldName = xDoc.CreateElement("Side2");
                    fieldValue = xDoc.CreateTextNode(membraneTriangle.Side2.ToString());

                    fieldName.AppendChild(fieldValue);
                    className.AppendChild(fieldName);

                    fieldName = xDoc.CreateElement("Side3");
                    fieldValue = xDoc.CreateTextNode(membraneTriangle.Side3.ToString());

                    fieldName.AppendChild(fieldValue);
                    className.AppendChild(fieldName);

                    if (shape is Paper)
                    {
                        var paperTriangle = (PaperTriangle)shape;

                        fieldName = xDoc.CreateElement("IsColoring");
                        fieldValue = xDoc.CreateTextNode(paperTriangle.IsColoring.ToString());

                        fieldName.AppendChild(fieldValue);
                        className.AppendChild(fieldName);

                        fieldName = xDoc.CreateElement("Color");
                        fieldValue = xDoc.CreateTextNode(paperTriangle.Color.ToString());

                        fieldName.AppendChild(fieldValue);
                        className.AppendChild(fieldName);
                    }

                    #endregion Write Triangle
                }
                wrapper.AppendChild(className);
            }
            xDoc.AppendChild(wrapper);
            xDoc.Save(_path);
        }

        //Normal realization, with reflection

        #region reflection write

        private void Write(IEnumerable<Shape> shapes, bool reflection)
        {
            List<FieldInfo> fieldInfos = new List<FieldInfo>();

            var bindingFlags = BindingFlags.Instance |
                               BindingFlags.NonPublic |
                               BindingFlags.Public;

            XmlDocument xDoc = new XmlDocument();
            XmlElement className;
            XmlElement fieldName;
            XmlText fieldValue;

            XmlElement wrapper = xDoc.CreateElement("Wrap");

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
                className = null;
                className = xDoc.CreateElement(shape.GetType().Name);

                foreach (var field in fieldInfos)
                {
                    fieldName = xDoc.CreateElement(field.Name);
                    fieldValue = xDoc.CreateTextNode(field.GetValue(shape).ToString());

                    fieldName.AppendChild(fieldValue);
                    className.AppendChild(fieldName);
                }
                wrapper.AppendChild(className);
            }
            xDoc.AppendChild(wrapper);
            xDoc.Save(_path);
        }

        #endregion reflection write
    }
}