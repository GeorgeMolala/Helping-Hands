using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helping_Hands.Data.Repositories
{
    interface IRepository<T> where T : class
    {
        IEnumerable<T> List(QueryOptions<T> options );
        T Get(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();

    }
}
