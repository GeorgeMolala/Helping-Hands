using Helping_Hands.Data.GRID;

namespace Helping_Hands.Data.Repositories
{
    public class CityQueryOptions : QueryOptions<Cities>
    {
        public void SortFilter(CityGridBuilder builder)
        {

            ///Filter Section
            if (builder.IsFilterByNoFilter)
            {
                if (builder.CurrentRoute.CityLocFilter == "Open")
                {
                    Where = b => b.Status == "Open";
                }
                if (builder.CurrentRoute.CityLocFilter == "Closed")
                {
                    Where = b => b.Status == "Closed";
                }

            }




            //Testing

            if (builder.IsSortBy)
            {
                int id = builder.CurrentRoute.CityLocFilter.ToInt();
                OrderBy = b => b.Name;
            }
        }

    }
}

