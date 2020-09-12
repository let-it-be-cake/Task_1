using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;

namespace Orm.FabricMethodBasicMethod.Realisations
{
    /// <summary>
    /// Basic method to work with database
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class BasicMethodsLinqToSql<T> : AbstractBasicMethods<T> where T : class, new()
    {
        private DataBaseClassesDataContext _context;

        private Expression<Func<T, bool>> GenerateExpressionForId(int id)
        {
            var itemParameter = Expression.Parameter(typeof(T), "item");
            return Expression.Lambda<Func<T, bool>>
                (
                Expression.Equal(
                    Expression.Property(
                        itemParameter,
                        "id"
                        ),
                    Expression.Constant(id)
                    ),
                new[] { itemParameter }
                );
        }

        /// <summary>
        /// Create new object in database
        /// </summary>
        /// <param name="obj"></param>
        public override void Create(T obj)
        {
            _context.GetTable<T>().InsertOnSubmit(obj);
            _context.SubmitChanges();
        }

        /// <summary>
        /// Delete object in database
        /// </summary>
        /// <param name="obj"></param>
        public override void Delete(T obj)
        {
            _context.GetTable<T>().DeleteOnSubmit(obj);
            _context.SubmitChanges();
        }

        /// <summary>
        /// Delete object in database
        /// </summary>
        /// <param name="id"></param>
        public override void Delete(int id)
        {
            var table = _context.GetTable<T>();
            var deleteTable = table.First(GenerateExpressionForId(id));
            table.DeleteOnSubmit(deleteTable);
            _context.SubmitChanges();
        }

        /// <summary>
        /// Read object from id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override T Read(int id)
        {
            var table = _context.GetTable<T>();
            return table.First(GenerateExpressionForId(id));
        }

        /// <summary>
        /// Read all collection objects of database
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<T> ReadAll()
        {
            return _context.GetTable<T>();
        }

        /// <summary>
        /// Set connectin in database
        /// </summary>
        /// <param name="connection"></param>
        public override void SetConnection(DbConnection connection)
        {
            _context = new DataBaseClassesDataContext(connection);
        }

        /// <summary>
        /// Update object in database
        /// </summary>
        /// <param name="obj"></param>
        public override void Update(T obj)
        {
            var result = _context.GetTable<T>()
                .First(
                GenerateExpressionForId(
                    (int)obj.GetType().GetProperty("Id").GetValue(obj)
                    )
                );
            foreach (var property in typeof(T).GetProperties())
            {
                property.SetValue(obj, property.GetValue(result));
            }
            _context.SubmitChanges();
        }
    }
}