using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Students
{
    /// <summary>
    /// Student class
    /// </summary>
    [Serializable]
    public class Student : IComparable
    {
        /// <summary>
        /// Structure with student test
        /// </summary>
        public struct Test
        {
            public string Tittle { get; set; }
            public DateTime Date { get; set; }
            public int Mark { get; set; }
        }

        public string Name { get; set; }
        public List<Test> tests { get; set; }

        public int CompareTo(object obj)
        {
            if (!(obj is Student))
                throw new ArgumentException("Object must be of type Student.");

            return Name.CompareTo((obj as Student).Name);
        }

        public override string ToString()
        {
            return Name;
        }


        public override bool Equals(object obj)
        {
            return obj is Student student &&
                   Name == student.Name &&
                   EqualityComparer<List<Test>>.Default.Equals(tests, student.tests);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, tests);
        }
    }
}
