using ORM.FabricMethodBasicMethod.Concerns;
using ORM.FabricMethodBasicMethod.Realisations;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ORM
{
    public class DbSet<T> where T : class, new()
    {
        private List<T> _enumerable = new List<T>();
        private DbContext _dbContext;
        private AbstractBasicMethods<T> _basic;

        public IEnumerable<T> Collection { get => _enumerable; }

        public DbSet(string connection)
        {
            _dbContext = new DbContext(connection);
            _basic = new BasicMethod<T>().Create();
            _basic.SetConnection(_dbContext.Connection);
        }

        public void SetConnection(string connection) =>
            _dbContext = new DbContext(connection);

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

        public void Delete(int id)
        {
            _dbContext.Open();
            _basic.Delete(id);
            _dbContext.Close();
        }

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

        public void Update(T obj)
        {
            _dbContext.Open();
            _basic.Update(obj);
            _dbContext.Close();
            Load();
        }

        public void Update(IEnumerable<T> collecion)
        {
            _dbContext.Open();
            collecion
                .ToList()
                .ForEach(o => _basic.Update(o));
            _dbContext.Close();
            Load();
        }

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