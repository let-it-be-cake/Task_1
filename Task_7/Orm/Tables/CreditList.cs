using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Tables
{
    public class CreditList : Table
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int SessionId { get; set; }
        public bool Passed { get; set; }

        public override bool Equals(object obj)
        {
            return obj is CreditList list &&
                   Id == list.Id &&
                   StudentId == list.StudentId &&
                   SubjectId == list.SubjectId &&
                   SessionId == list.SessionId &&
                   Passed == list.Passed;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, StudentId, SubjectId, SessionId, Passed);
        }
    }
}
