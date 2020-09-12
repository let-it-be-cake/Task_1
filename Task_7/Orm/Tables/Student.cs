using System;

namespace ORM.Tables
{
    public class Student : Table
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int GroupId { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Student student &&
                   Id == student.Id &&
                   Name == student.Name &&
                   LastName == student.LastName &&
                   DateOfBirth.Date.ToShortDateString().Equals(student.DateOfBirth.ToShortDateString()) &&
                   GroupId == student.GroupId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, LastName, DateOfBirth, GroupId);
        }
    }
}