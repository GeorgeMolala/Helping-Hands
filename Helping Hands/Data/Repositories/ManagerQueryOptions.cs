using Helping_Hands.Data.GRID;

namespace Helping_Hands.Data.Repositories
{
    public class ManagerQueryOptions : QueryOptions<Managers>
    {

        public void SortFilter(ManagerGridBuilder builder)
        {
            if (builder.IsFilterByStatus)
            {
                if (builder.CurrentRoute.StatusFilter == "Active")
                {
                    Where = b => b.Status == "Active";
                }
                if (builder.CurrentRoute.VisitStatusFilter == "InActive")
                {
                    Where = b => b.Status == "InActive";
                }
            }

            //if (builder.IsSortBySuburb)
            //{
            //    OrderBy = b => b.Suburbs.Name;
            //}

            if (builder.IsSortByName)
            {
                OrderBy = b => b.FirstName;
            }
        }
    }
}
