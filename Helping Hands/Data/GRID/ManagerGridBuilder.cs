using Microsoft.AspNetCore.Http;

namespace Helping_Hands.Data.GRID
{
    public class ManagerGridBuilder : GridBuilder
    {
        public ManagerGridBuilder(ISession sess) : base(sess) { }

        public ManagerGridBuilder(ISession sess, ManagerGridDTO values, string defaultSortField) : base(sess, values, defaultSortField)
        {
            bool isinitial = values.Status.IndexOf(FilterPrefix.Status) == -1;
            routes.StatusFilter = (isinitial) ?
            FilterPrefix.Status + values.Status : values.Status;
            SaveRouteSegments();
        }

        public void LoadFilterSegments(string[] filter, Managers suburb)
        {
            if (suburb == null)
            {
                routes.StatusFilter = FilterPrefix.Status + filter[0];
            }
            else
            {
                routes.StatusFilter = FilterPrefix.Status + filter[0] + "-" + suburb.Status.Slug();
            }

        }

        public void ClearFilterSegments() => routes.ClearFilters();


        string def = NurseGridDTO.DefaultFilter;
        //  string default = NurseGridDTO.DefaultFilter; 
        public bool IsFilterByStatus => routes.StatusFilter != def;

        public bool IsSortByName => routes.SortField.EqualsNoCase(nameof(Managers));
    }
}
