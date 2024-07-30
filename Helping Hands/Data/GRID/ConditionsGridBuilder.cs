using Microsoft.AspNetCore.Http;

namespace Helping_Hands.Data.GRID
{
    public class ConditionsGridBuilder : GridBuilder
    {
        public ConditionsGridBuilder(ISession sess) : base(sess) { }
        public ConditionsGridBuilder(ISession sess, ConditionsGridDTO values, string defaultSortField) : base(sess, values, defaultSortField)
        {
            bool isinitial = values.NoFilter.IndexOf(FilterPrefix.NoFilter) == -1;
            routes.NoFilterFilter = (isinitial) ? FilterPrefix.NoFilter + values.NoFilter : values.NoFilter;


            SaveRouteSegments();
        }

        public void LoadFilterSegments(string[] filter, ChronicInfections infections)
        {
            if (infections == null)
            {
                routes.NoFilterFilter = FilterPrefix.NoFilter + filter[0];
            }
            else
            {
                routes.NoFilterFilter = FilterPrefix.NoFilter + filter[0] + "-" + infections.ConditionName.Slug();
            }



            //  routes.StartDateFilter = FilterPrefix.StartDate + filter[2]; we'll revise when addung date filter
            // routes.EndDateFilter = FilterPrefix.EndDate + filter[3]; will revise when adding date filter


        }

        public void ClearFilterSegments() => routes.ClearFilters();

        string def = ConditionsGridDTO.DefaultFilter;
        public bool IsFilterByNoFilter => routes.NoFilterFilter != def;



        public bool IsSortBy => routes.SortField.EqualsNoCase(nameof(ChronicInfections));
    }
}
