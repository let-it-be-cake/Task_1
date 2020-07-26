using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Shapes;
using Shapes.BasicShapes;
using Shapes.Interfaces;
using Shapes.MaterialShapes;
using IO;

namespace Task_3
{
    class Program
    {

        static void Main(string[] args)
        {
            //var bindingFlags = BindingFlags.Instance |
            //       BindingFlags.NonPublic |
            //       BindingFlags.Public;

            //Shapes.MaterialShapes.PaperCircle
            string name = "PaperCircle";
            string property = "_radius";
            int value = 10;

            // Get the type contained in the name string
            var a = Assembly.Load("Shapes")
                .GetTypes()
                .Where(t => t.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                .First();

            // create an instance of that type
            PaperCircle instance = (PaperCircle)Activator.CreateInstance(a, 10, null);

            // Get a property on the type that is stored in the 
            // property string
            //PropertyInfo prop = instance.GetType().GetProperty("_isColoring");
            //prop.SetValue(instance, true);

            // Set the value of the given property on the given instance


            PaperCircle shape = new PaperCircle(10);

            MembraneTriangle triangle = new MembraneTriangle(10,12,15);

            // at this stage instance.Bar will equal to the value
            // Console.WriteLine(((PaperCircle)instance).Equals(shape));

            //PaperCircle shape = new PaperCircle(10);



            //List<FieldInfo> fieldInfos = new List<FieldInfo>();

            ////var fieldValues = shape.GetType();/*.BaseType.GetFields(bindingFlags).ToList();*/
            //var type = shape.GetType();
            //while (type.Name != "Object")
            //{
            //    fieldInfos.AddRange(type.GetFields(bindingFlags));
            //    type = type.BaseType;
            //}
            //Console.WriteLine(fieldInfos[2].Name + " " + fieldInfos[2].GetValue(shape));
            


            List<Shape> shapes = new List<Shape>();

            shapes.Add(new PaperTriangle(10, 12, 11));
            shapes.Add(triangle);
            shapes.Add(shape);
            shapes.Add(new MembraneCircle(11));
            shapes.Add(new PaperRectangle(10, 15));
            shapes.Add(new MembraneRectangle(22, 11));

            XmlReader xml = new XmlReader("test.xml");
            List<Shape> lsit = xml.Read().ToList();


            StreamReader stream = new StreamReader("test.xml");
            List<Shape> list = stream.Read().ToList();
        }
    }
}
