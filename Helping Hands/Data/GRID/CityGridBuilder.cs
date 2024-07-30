using Microsoft.AspNetCore.Http;

namespace Helping_Hands.Data.GRID
{
    public class CityGridBuilder : GridBuilder
    {
        public CityGridBuilder(ISession sess) : base(sess) { }
        public CityGridBuilder(ISession sess, CityGridDTO values, string defaultSortField) : base(sess, values, defaultSortField)
        {
            bool isinitial = values.NoFilter.IndexOf(FilterPrefix.NoFilter) == -1;
            routes.NoFilterFilter = (isinitial) ? FilterPrefix.NoFilter + values.NoFilter : values.NoFilter;


            SaveRouteSegments();
        }

        public void LoadFilterSegments(string[] filter, Cities visits)
        {
            if (visits == null)
            {
                routes.NoFilterFilter = FilterPrefix.NoFilter + filter[0];
            }
            else
            {
                routes.NoFilterFilter = FilterPrefix.NoFilter + filter[0] + "-" + visits.Name.Slug();
            }



            //  routes.StartDateFilter = FilterPrefix.StartDate + filter[2]; we'll revise when addung date filter
            // routes.EndDateFilter = FilterPrefix.EndDate + filter[3]; will revise when adding date filter


        }

        public void ClearFilterSegments() => routes.ClearFilters();

        string def = CityGridDTO.DefaultFilter;
        public bool IsFilterByNoFilter => routes.NoFilterFilter != def;



        public bool IsSortBy => routes.SortField.EqualsNoCase(nameof(Cities));
    }
}
