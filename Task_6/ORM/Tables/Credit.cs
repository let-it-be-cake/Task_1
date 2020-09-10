using System;

namespace ORM.Tables
{
    public class Credit : Table
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int SubjectId { get; set; }
        public DateTime DateOfCredit { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Credit credit &&
                   Id == credit.Id &&
                   GroupId == credit.GroupId &&
                   SubjectId == credit.SubjectId &&
                   DateOfCredit.ToShortDateString().Equals(credit.DateOfCredit.ToShortDateString());
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, GroupId, SubjectId, DateOfCredit);
        }
    }
}