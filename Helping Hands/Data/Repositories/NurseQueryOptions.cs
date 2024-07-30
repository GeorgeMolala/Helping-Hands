namespace Helping_Hands.Data.Repositories
{
    public class NurseQueryOptions : QueryOptions<Nurses>
    {
        public void SortFilter(NurseGridBuilder builder)
        {
            if (builder.IsFilterBySuburb)
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

            if (builder.IsSortByName)
            {
                OrderBy = b => b.FirstName;
            }
        }
    }
}
