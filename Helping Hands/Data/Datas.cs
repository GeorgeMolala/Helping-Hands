using Helping_Hands.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Helping_Hands.Data
{
    public class Datas
    {
        private GRP0452HelpingHandsDBContext _context { get; set; }


        public Datas(GRP0452HelpingHandsDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Nurses> GetNurses(QueryOptions<Nurses> options)
        {
            IQueryable<Nurses> query = _context.Nurses;

            foreach (string include in options.Getincludes())
            {

                query = query.Include(include);

            }

            if (options.HasWhere)
            {
                // = query.Where(options.Where);
            }

            if (options.HasOrderBy)
            {
                query = query.OrderBy(options.OrderBy);
            }

            if (options.HasPaging)
            {
                query = query.PageBy(options.PageNumber, options.PageSize);
            }



            return query.ToList();



        }


    }
}
