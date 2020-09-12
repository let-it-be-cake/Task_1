using ORM.FabricMethodBasicMethod.Concerns;
using ORM.FabricMethodBasicMethod.Realisations;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ORM
{
    /// <summary>
    /// DbSet for generic class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DbSet<T> where T : class, new()
    {
        private List<T> _enumerable = new List<T>();
        private DbContext _dbContext;
        private AbstractBasicMethods<T> _basic;

        /// <summary>
        /// Collection for database
        /// </summary>
        public IEnumerable<T> Collection { get => _enumerable; }

        /// <summary>
        /// Create connection
        /// </summary>
        /// <param name="connection"></param>
        public DbSet(string connection)
        {
            _dbContext = new DbContext(connection);
            _basic = new BasicMethod<T>().Create();
            _basic.SetConnection(_dbContext.Connection);
        }

        /// <summary>
        /// Add new object to database
        /// </summary>
        /// <param name="obj"></param>
        public void Add(T obj)
        {
            if (_enumerable.Contains(obj))
            {
                throw new WarningException("The " + typeof(T).Name + " table contains this entry");
            }
            _enumerable.Add(obj);
            _dbContext.Open();
            _basic.Create(obj);
            _dbContext.Close();
        }

        /// <summary>
        /// Add collection to database
        /// </summary>
        /// <param name="collection"></param>
        public void Add(IEnumerable<T> collection)
        {
            _dbContext.Open();

            collection.Where(o => !_enumerable.Contains(o))
                .ToList()
                .ForEach(o =>
                {
                    _basic.Create(o);
                    _enumerable.Add(o);
                });
            _dbContext.Close();
        }

        /// <summary>
        /// Delete object from database
        /// </summary>
        /// <param name="obj">Delete object</param>
        public void Delete(T obj)
        {
            if (!_enumerable.Contains(obj))
            {
                throw new WarningException("The " + typeof(T).Name + " table didn't contains this entry");
            }
            _dbContext.Open();
            _basic.Delete(obj);
            _dbContext.Close();
        }

        /// <summary>
        /// Create object from database
        /// </summary>
        /// <param name="id">Delete an object by id from database</param>
        public void Delete(int id)
        {
            _dbContext.Open();
            _basic.Delete(id);
            _dbContext.Close();
        }

        /// <summary>
        /// Delete collection from database
        /// </summary>
        /// <param name="collection">Collection to delete</param>
        public void Delete(IEnumerable<T> collection)// where T : class, new()
        {
            _dbContext.Open();
            collection.Where(o => _enumerable.Contains(o))
                .ToList()
                .ForEach(o =>
                {
                    _basic.Delete(o);
                    _enumerable.Remove(o);
                });
            _dbContext.Close();
        }

        /// <summary>
        /// Update object in database
        /// </summary>
        /// <param name="obj">Object to update</param>
        public void Update(T obj)
        {
            _dbContext.Open();
            _basic.Update(obj);
            _dbContext.Close();
            Load();
        }

        /// <summary>
        /// Update collection in database
        /// </summary>
        /// <param name="collecion">Updated collection</param>
        public void Update(IEnumerable<T> collecion)
        {
            _dbContext.Open();
            collecion
                .ToList()
                .ForEach(o => _basic.Update(o));
            _dbContext.Close();
            Load();
        }

        /// <summary>
        /// Load a collection from the database
        /// </summary>
        public void Load()
        {
            _dbContext.Open();
            _enumerable = _basic
                .ReadAll()
                .ToList();
            _dbContext.Close();
        }
    }
}