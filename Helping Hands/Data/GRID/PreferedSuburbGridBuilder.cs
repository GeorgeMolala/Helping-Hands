using Microsoft.AspNetCore.Http;

namespace Helping_Hands.Data.GRID
{
    public class PreferedSuburbGridBuilder : GridBuilder
    {



        public PreferedSuburbGridBuilder(ISession sess) : base(sess)
        {

        }



        public PreferedSuburbGridBuilder(ISession sess, PreferedSuburbGridDTO values, string defaultSortField) : base(sess, values, defaultSortField)
        {
            bool isinitial = values.Location.IndexOf(FilterPrefix.Suburb) == -1;
            routes.LocationFilter = (isinitial) ? FilterPrefix.Suburb + values.Location : values.Location;


            SaveRouteSegments();
        }


        public void LoadFilterSegments(string[] filter, PreferedSuburbs sub)
        {
            if (sub == null)
            {
                routes.LocationFilter = FilterPrefix.Suburb + filter[0];
            }
            else
            {
                routes.LocationFilter = FilterPrefix.Suburb + filter[0] + "-" + sub.Suburb.Name.Slug();
            }

            routes.LocationFilter = FilterPrefix.Suburb + filter[0];

        }

        public void ClearFilterSegments() => routes.ClearFilters();


        string def = PreferedSuburbGridDTO.DefaultFilter;
        //  string default = NurseGridDTO.DefaultFilter; 

        public bool IsFilterByLocation => routes.LocationFilter != def;

        public bool IsSortBy => routes.SortField.EqualsNoCase(nameof(PreferedSuburbs));

    }
}
