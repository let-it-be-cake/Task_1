using System.Collections.Generic;
using System.Data.Common;

namespace ORM.FabricMethodBasicMethod.Realisations
{
    /// <summary>
    /// Abstract realisation for basic methods
    /// </summary>
    /// <typeparam name="T"></typeparam>
    abstract public class AbstractBasicMethods<T> where T : class, new()
    {
        public abstract void Create(T obj);

        public abstract void Update(T obj);

        public abstract T Read(int Id);

        public abstract IEnumerable<T> ReadAll();

        public abstract void Delete(T obj);

        public abstract void Delete(int id);

        public abstract void SetConnection(DbConnection connection);
    }
}