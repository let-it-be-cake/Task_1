using System;

namespace ORM.Tables
{
    public class Exam : Table
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int SubjectId { get; set; }
        public DateTime DateOfCredit { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Exam exam &&
                   Id == exam.Id &&
                   GroupId == exam.GroupId &&
                   SubjectId == exam.SubjectId &&
                   DateOfCredit.ToShortDateString().Equals(exam.DateOfCredit.ToShortDateString());
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, GroupId, SubjectId, DateOfCredit);
        }
    }
}