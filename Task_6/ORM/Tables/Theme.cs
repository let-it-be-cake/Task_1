using System;

namespace ORM.Tables
{
    /// <summary>
    /// Theme database table
    /// </summary>
    public class Theme :Table
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SubjectId { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Theme theme &&
                   Id == theme.Id &&
                   Name == theme.Name &&
                   SubjectId == theme.SubjectId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, SubjectId);
        }
    }
}