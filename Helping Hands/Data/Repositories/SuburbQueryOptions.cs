using Helping_Hands.Data.GRID;

namespace Helping_Hands.Data.Repositories
{
    public class SuburbQueryOptions : QueryOptions<Suburbs>
    {
        public void SortFilter(SuburbGridBuilder builder)
        {

            ///Filter Section
            if (builder.IsFilterByCityLoc)
            {
                int id = builder.CurrentRoute.SuburbFilter.ToInt();
                if (id > 0)
                {
                    Where = b => b.SuburbID == id;
                }


            }





            //Testing

            if (builder.IsSortByName)
            {
                int id = builder.CurrentRoute.EndDateFilter.ToInt();
                OrderBy = b => b.Name;
            }
        }

    }
}

