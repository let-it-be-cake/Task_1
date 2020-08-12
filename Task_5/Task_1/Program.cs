using Students;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Tree<Student>));

            Tree<Student> tree = new Tree<Student>();
            tree.Add(new Student()
            {
                Name = "People1",
                tests = new List<Student.Test>()
                        {
                            new Student.Test()
                            {
                                Date = new DateTime(1),
                                Mark = 8,
                                Tittle = "Math"
                            }
                        }
            });

            tree.Add(new Student()
            {
                Name = "People2",
                tests = new List<Student.Test>()
                        {
                            new Student.Test()
                            {
                                Date = new DateTime(10),
                                Mark = 2,
                                Tittle = "Not"
                            }
                        }
            });
            tree.Add(new Student()
            {
                Name = "People3",
                tests = new List<Student.Test>()
                        {
                            new Student.Test()
                            {
                                Date = new DateTime(421),
                                Mark = 8,
                                Tittle = "Undewr"
                            }
                        }
            });
            tree.Add(new Student()
            {
                Name = "People4",
                tests = new List<Student.Test>()
                {
                    new Student.Test()
                    {
                        Date = new DateTime(132),
                        Mark = 10,
                        Tittle = "Mathematic"
                    }
                }
            });

            using (FileStream fs = new FileStream("Students.Xml", FileMode.Create))
            {
                xmlSerializer.Serialize(fs, tree);
            }
        }
    }
}