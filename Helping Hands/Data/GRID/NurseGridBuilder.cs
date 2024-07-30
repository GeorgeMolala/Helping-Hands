using Microsoft.AspNetCore.Http;

namespace Helping_Hands.Data
{
    public class NurseGridBuilder : GridBuilder
    {
        public NurseGridBuilder(ISession sess) : base(sess) { }

        public NurseGridBuilder(ISession sess, NurseGridDTO values, string defaultSortField) : base(sess, values, defaultSortField)
        {
            bool isinitial = values.Suburb.IndexOf(FilterPrefix.Suburb) == -1;
            routes.SuburbFilter = (isinitial) ?
            FilterPrefix.Suburb + values.Suburb : values.Suburb;
            SaveRouteSegments();
        }

        public void LoadFilterSegments(string[] filter, Suburbs suburb)
        {
            if (suburb == null)
            {
                routes.SuburbFilter = FilterPrefix.Suburb + filter[0];
            }
            else
            {
                routes.SuburbFilter = FilterPrefix.Suburb + filter[0] + "-" + suburb.Name.Slug();
            }

        }

        public void ClearFilterSegments() => routes.ClearFilters();


        string def = NurseGridDTO.DefaultFilter;
        //  string default = NurseGridDTO.DefaultFilter; 
        public bool IsFilterBySuburb => routes.SuburbFilter != def;

        public bool IsSortByName => routes.SortField.EqualsNoCase(nameof(Nurses));

    }
}
