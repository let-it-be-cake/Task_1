using System;

namespace ORM.Tables
{
    public class Session : Table
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Session session &&
                   Id == session.Id &&
                   GroupId == session.GroupId &&
                   StartDate.ToShortDateString().Equals(session.StartDate.ToShortDateString()) &&
                   EndDate.ToShortDateString().Equals(session.EndDate.ToShortDateString());
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, GroupId, StartDate, EndDate);
        }
    }
}