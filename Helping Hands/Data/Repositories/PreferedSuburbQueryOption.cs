using Helping_Hands.Data.GRID;

namespace Helping_Hands.Data.Repositories
{
    public class PreferedSuburbQueryOption : QueryOptions<PreferedSuburbs>
    {
        public void SortFilter(PreferedSuburbGridBuilder builder)
        {
            if (builder.IsFilterByLocation)
            {
                if (builder.CurrentRoute.LocationFilter == "")
                    Where = b => b.Suburb.Name == "";

                else
                    Where = b => b.Suburb.Name == "";

            }


            if (builder.IsSortBy)
            {
                int id = builder.CurrentRoute.NurseFilter.ToInt();
                OrderBy = b => b.NurseUserID;
            }
        }
    }
}
