using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMongoApp.Repository
{
    public interface IRepository<T, ID> where T : class
    {
        Task Create(T obj);
        void Update(T obj);
        void Delete(ID id);
        Task<T> Get(ID id);
        Task<IEnumerable<T>> Get();
    }
}
