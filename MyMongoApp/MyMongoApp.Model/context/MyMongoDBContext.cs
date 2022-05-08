using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMongoApp.Model
{
    public interface IMyMongoDBContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }

    public class MyMongoDBContext : IMyMongoDBContext
    {
        private IMongoDatabase _db { get; set; }
        private MongoClient _mongoClient { get; set; }
        public IClientSessionHandle Session { get; set; }

        public MyMongoDBContext(IOptions<MongoDatabaseSettings> configuration)
        {
            _mongoClient = new MongoClient(configuration.Value.ConnectionString);
            _db = _mongoClient.GetDatabase(configuration.Value.DatabaseName);
        }

        //public IMongoCollection<Books> GetCollection<Books>(string name)
        //{
        //    throw new NotImplementedException();
        //}

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }
            return _db.GetCollection<T>(name);
        }
    }
}
