using Helping_Hands.Data.GRID;

namespace Helping_Hands.Data.Repositories
{
    public class ConditionsQueryOptions : QueryOptions<ChronicInfections>
    {
        public void SortFilter(ConditionsGridBuilder builder)
        {

            ///Filter Section
            if (builder.IsFilterByNoFilter)
            {
                if (builder.CurrentRoute.CityLocFilter == "All")
                {
                    Where = b => b.Status == "Active";
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
                OrderBy = b => b.ConditionName;
            }
        }
    }
}
