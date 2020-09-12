using System;

namespace ORM.Tables
{
    /// <summary>
    /// Gradebook database table
    /// </summary>
    public class Gradebook : Table
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int SessionId { get; set; }
        public int Mark { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Gradebook gradebook &&
                   Id == gradebook.Id &&
                   StudentId == gradebook.StudentId &&
                   SubjectId == gradebook.SubjectId &&
                   SessionId == gradebook.SessionId &&
                   Mark == gradebook.Mark;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, StudentId, SubjectId, SessionId, Mark);
        }
    }
}