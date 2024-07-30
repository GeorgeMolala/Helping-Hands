using System.Linq;

namespace Helping_Hands.Data
{
    public static class QueryExtensions
    {
        public static IQueryable<T> PageBy<T>(this IQueryable<T> query, int pageNumber, int pageSize)
        {

            return query.Skip((pageNumber - 1) * pageSize).Take(pageSize);

        }

    }
}
