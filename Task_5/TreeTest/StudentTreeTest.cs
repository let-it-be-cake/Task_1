using Students;
using System;
using System.Collections.Generic;
using Xunit;

namespace TreeTest
{
    public class StudentTreeTest
    {
        /// <summary>
        /// Collection of students
        /// </summary>
        /// <returns>Collection of students</returns>
        public static IEnumerable<object[]> Data()
        {
            yield return new object[] {
                new List<Student> {
                    new Student()
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
                    },
                    new Student()
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
                    },
                    new Student()
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
                    },
                    new Student()
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
                    },
                },
            };
            yield return new object[] {
                new List<Student> {
                    new Student()
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
                    },
                    new Student()
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
                    },
                    new Student()
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
                    },
                    new Student()
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
                    },
                    new Student()
                    {
                        Name = "People5",
                        tests = new List<Student.Test>()
                        {
                            new Student.Test()
                            {
                                Date = new DateTime(132),
                                Mark = 5,
                                Tittle = "Language"
                            }
                        }
                    },
                },
            };
            yield return new object[] {
                new List<Student> {
                    new Student()
                    {
                        Name = "People2",
                        tests = new List<Student.Test>()
                        {
                            new Student.Test()
                            {
                                Date = new DateTime(1),
                                Mark = 8,
                                Tittle = "Math"
                            }
                        }
                    },
                    new Student()
                    {
                        Name = "People1",
                        tests = new List<Student.Test>()
                        {
                            new Student.Test()
                            {
                                Date = new DateTime(10),
                                Mark = 2,
                                Tittle = "Not"
                            }
                        }
                    },
                    new Student()
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
                    },
                },
            };
        }

        /// <summary>
        /// Search for students in the tree
        /// </summary>
        /// <param name="numbers">Collection of students</param>
        [Theory]
        [MemberData(nameof(Data))]
        public void Add_IEnumberable_int_Collection_in_the_tree_and_found_this_using_FindNode(List<Student> numbers)
        {
            //arrange
            Tree<Student> tree = new Tree<Student>();
            foreach (var value in numbers)
                tree.Add(value);
            //assert
            foreach (var value in numbers)
                Assert.Equal(value, tree.FindNode(value).Value);
        }
    }
}