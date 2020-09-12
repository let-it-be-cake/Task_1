using System;

namespace ORM.Tables
{
    /// <summary>
    /// Exam database table
    /// </summary>
    public class Exam : Table
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int SubjectId { get; set; }
        public DateTime DateOfExam { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Exam exam &&
                   Id == exam.Id &&
                   GroupId == exam.GroupId &&
                   SubjectId == exam.SubjectId &&
                   DateOfExam.ToShortDateString().Equals(exam.DateOfExam.ToShortDateString());
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, GroupId, SubjectId, DateOfExam);
        }
    }
}