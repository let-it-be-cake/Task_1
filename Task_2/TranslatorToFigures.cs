using System;
using System.Collections.Generic;
using System.Linq;
using Task_2.Figures;

namespace Task_2
{
    //Storage types of figures
    public enum Types
    {
        Tri, //Triangle
        Rec, //Rectangle
        Cir, //Circle
        Afi, //Abstract Figure
    }
    //Class to record data from CSVHelper
    public class TranslateContainer
    {
        public Types Type { get; set; }
        public double[] Arguments { get; set; }
    }
    //Analysing TranslateContainer
    internal static class TranslatorToFigures
    {
        public static IEnumerable<Figure> GetFigures(string fileName = @"Figures.csv")
        {
            TranslateContainer[] tc = FileReader.ReadFigures(fileName).ToArray();
            List<Figure> result = new List<Figure>();
            foreach (var value in tc)
            {
                //Sorting all the shapes by type
                switch (value.Type)
                {
                    case Types.Tri:
                        if (value.Arguments.Length == 3)
                        {
                            result.Add(new Triangle(
                                value.Arguments[0],
                                value.Arguments[1],
                                value.Arguments[2]));
                        }
                        else if (value.Arguments.Length == 6)
                        {
                            result.Add(new Triangle(
                                value.Arguments[0],
                                value.Arguments[1],
                                value.Arguments[2],
                                value.Arguments[3],
                                value.Arguments[4],
                                value.Arguments[5]));
                        }
                        else throw new Exception("Array Error! Check input File!");
                        break;

                    case Types.Rec:
                        if (value.Arguments.Length == 2)
                        {
                            result.Add(new Rectangle(
                                value.Arguments[0],
                                value.Arguments[1]));
                        }
                        else if (value.Arguments.Length == 4)
                        {
                            result.Add(new Rectangle(
                                value.Arguments[0],
                                value.Arguments[1],
                                value.Arguments[2],
                                value.Arguments[3]));
                        }
                        else throw new Exception("Array Error! Check input File!");
                        break;

                    case Types.Cir:
                        if (value.Arguments.Length == 3)
                        {
                            result.Add(new Circle(
                                value.Arguments[0],
                                value.Arguments[1],
                                value.Arguments[2]));
                        }
                        else throw new Exception("Array Error! Check input File!");
                        break;

                    case Types.Afi:
                        if (value.Arguments.Length > 3)
                        {
                            result.Add(new AbstractFigure(
                                value.Arguments[0],
                                value.Arguments[1],
                                value.Arguments[2],
                                value.Arguments.Skip(3).ToArray()));
                        }
                        else throw new Exception("Array Error! Check input File!");
                        break;

                    default:
                        break;
                }
            }
            return result;
        }
    }
}