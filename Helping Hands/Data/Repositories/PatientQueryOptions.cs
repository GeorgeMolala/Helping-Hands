using Helping_Hands.Data.GRID;
using Helping_Hands.Models;

namespace Helping_Hands.Data.Repositories
{
    public class PatientQueryOptions : QueryOptions<Patients>
    {
        public void SortFilter(PatientGridBuilder builder)
        {
            if (builder.IsFilterByNoFilter)
            {
                //  Where = b => b.SuburbID == builder.CurrentRoute.SuburbFilter;
                int id = builder.CurrentRoute.SuburbFilter.ToInt();
                if (id > 0)
                    Where = b => b.SuburbID == id;
            }

            //if (builder.IsSortBySuburb)
            //{
            //    OrderBy = b => b.Suburbs.Name;
            //}

            if (builder.IsSortBy)
            {
                OrderBy = b => b.FirstName;
            }
        }
    }
}
