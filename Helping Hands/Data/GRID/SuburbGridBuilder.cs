using Microsoft.AspNetCore.Http;

namespace Helping_Hands.Data.GRID
{
    public class SuburbGridBuilder : GridBuilder
    {
        public SuburbGridBuilder(ISession sess) : base(sess) { }

        public SuburbGridBuilder(ISession sess, SuburbGridDTO values, string defaultSortField) : base(sess, values, defaultSortField)
        {
            bool isinitial = values.CityLoc.IndexOf(FilterPrefix.CityLoc) == -1;
            routes.CityLocFilter = (isinitial) ?
            FilterPrefix.CityLoc + values.CityLoc : values.CityLoc;
            SaveRouteSegments();
        }

        public void LoadFilterSegments(string[] filter, Cities City)
        {
            if (City == null)
            {
                routes.CityLocFilter = FilterPrefix.CityLoc + filter[0];
            }
            else
            {
                routes.CityLocFilter = FilterPrefix.CityLoc + filter[0] + "-" + City.Name.Slug();
            }

        }

        public void ClearFilterSegments() => routes.ClearFilters();


        string def = SuburbGridDTO.DefaultFilter;

        public bool IsFilterByCityLoc => routes.CityLocFilter != def;

        public bool IsSortByName => routes.SortField.EqualsNoCase(nameof(Suburbs));

    }
}

