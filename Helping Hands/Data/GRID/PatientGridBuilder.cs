using Helping_Hands.Models;
using Microsoft.AspNetCore.Http;


namespace Helping_Hands.Data.GRID
{
    public class PatientGridBuilder : GridBuilder
    {
        public PatientGridBuilder(ISession sess) : base(sess) { }
        public PatientGridBuilder(ISession sess, PatientGridDTO values, string defaultSortField) : base(sess, values, defaultSortField)
        {
            bool isinitial = values.NoFilter.IndexOf(FilterPrefix.NoFilter) == -1;
            routes.NoFilterFilter = (isinitial) ? FilterPrefix.NoFilter + values.NoFilter : values.NoFilter;


            SaveRouteSegments();
        }

        public void LoadFilterSegments(string[] filter, Patients patients)
        {
            if (patients == null)
            {
                routes.NoFilterFilter = FilterPrefix.NoFilter + filter[0];
            }
            else
            {
                routes.NoFilterFilter = FilterPrefix.NoFilter + filter[0] + "-" + patients.FirstName.Slug();
            }



            //  routes.StartDateFilter = FilterPrefix.StartDate + filter[2]; we'll revise when addung date filter
            // routes.EndDateFilter = FilterPrefix.EndDate + filter[3]; will revise when adding date filter


        }

        public void ClearFilterSegments() => routes.ClearFilters();

        string def = PatientGridDTO.DefaultFilter;
        public bool IsFilterByNoFilter => routes.NoFilterFilter != def;



        public bool IsSortBy => routes.SortField.EqualsNoCase(nameof(Patients));
    }
}

