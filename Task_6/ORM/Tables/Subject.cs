using System;

namespace ORM.Tables
{
    public class Subject : Table
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Subject subject &&
                   Id == subject.Id &&
                   Name == subject.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name);
        }
    }
}