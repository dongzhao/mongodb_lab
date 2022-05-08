using MongoDB.Driver;
using MyMongoApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMongoApp.Repository
{
    public abstract class BaseRepository<T, ID> : IRepository<T, ID> where T : class
    {
        protected readonly IMyMongoDBContext _cfx;
        protected IMongoCollection<T> _dbCollection;

        protected BaseRepository(IMyMongoDBContext context)
        {
            _cfx = context;
            _dbCollection = _cfx.GetCollection<T>(typeof(T).Name);
        }

        public async Task Create(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(typeof(T).Name + " object is null");
            }
            await _dbCollection.InsertOneAsync(obj);
        }

        public virtual void Delete(ID id)
        {
            _dbCollection.DeleteOneAsync(Builders<T>.Filter.Eq("_id", id));
        }

        public async Task<T> Get(ID id)
        {
            FilterDefinition<T> filter = Builders<T>.Filter.Eq("_id", id);
            return await _dbCollection.FindAsync(filter).Result.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> Get()
        {
            var all = await _dbCollection.FindAsync(Builders<T>.Filter.Empty);
            return await all.ToListAsync();
        }

        public virtual void Update(T obj)
        {
            _dbCollection.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", (obj as IEntity<ID>).Id), obj);
        }
    }
}
