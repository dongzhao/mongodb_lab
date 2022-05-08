using MyMongoApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMongoApp.Repository
{
    public class BooksRepository : BaseRepository<Books, int>, IBooksRepository
    {
        public BooksRepository(IMyMongoDBContext context) : base(context)
        {
        }
    }
}
