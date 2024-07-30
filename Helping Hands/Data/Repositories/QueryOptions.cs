using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace Helping_Hands.Data.Repositories
{
    public class QueryOptions<T> where T : class
    {

        // public properties for sorting, filtering, and paging
        public Expression<Func<T, Object>> OrderBy { get; set; }
        public string OrderByDirection { get; set; } = "asc";


        // public Expression<Func<T, bool>> Where { get; set; } // To be removed
        public int PageNumber { get; set; }
        public int PageSize { get; set; }



        // public write-only property for includes private string array
        private string[] includes;
        public string Includes

        {
            set => includes = value.Replace(" ", "").Split(',');
        }

        // public method returns includes array
        public string[] Getincludes() => includes ?? new string[0];


        public WhereClauses<T> WhereClauses { get; set; }
        public Expression<Func<T, bool>> Where
        {
            set
            {
                if (WhereClauses == null)
                {
                    WhereClauses = new WhereClauses<T>();
                }

                WhereClauses.Add(value);
            }
        }


        // read-only properties
        public bool HasWhere => WhereClauses != null;
        public bool HasOrderBy => OrderBy != null;
        public bool HasPaging => PageNumber > 0 && PageSize > 0;


    }

    public class WhereClauses<T> : List<Expression<Func<T, bool>>> { }
}


