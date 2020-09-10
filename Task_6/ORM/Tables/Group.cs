using System;

namespace ORM.Tables
{
    public class Group : Table
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Group group &&
                   Id == group.Id &&
                   Name == group.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name);
        }
    }
}