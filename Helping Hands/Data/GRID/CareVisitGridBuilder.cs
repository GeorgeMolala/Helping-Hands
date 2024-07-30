using Microsoft.AspNetCore.Http;

namespace Helping_Hands.Data.GRID
{
    public class CareVisitGridBuilder : GridBuilder
    {
        public CareVisitGridBuilder(ISession sess) : base(sess) { }
        public CareVisitGridBuilder(ISession sess, CareVisitGridDTO values, string defaultSortField) : base(sess, values, defaultSortField)
        {
            bool isinitial = values.ContractDate.IndexOf(FilterPrefix.ContractDate) == -1;
            routes.VisitStatusFilter = (isinitial) ? FilterPrefix.VisitStatus + values.VisitStatus : values.VisitStatus;
            routes.PeriodFilter = (isinitial) ? FilterPrefix.Period + values : values.Period;
           // routes.NurseFilter = (isinitial) ? FilterPrefix.Nurse + values : values.Nurse;
            routes.ContractDateFilter = (isinitial) ? FilterPrefix.ContractDate + values.ContractDate : values.ContractDate;
            routes.EndDateFilter = (isinitial) ? FilterPrefix.EndDate + values.EndDate : values.EndDate;

            SaveRouteSegments();
        }

        public void LoadFilterSegments(string[] filter, CareVisits visits)
        {
            if (visits == null)
            {
                routes.VisitStatusFilter = FilterPrefix.VisitStatus + filter[0];
            }
            else
            {
                routes.VisitStatusFilter = FilterPrefix.VisitStatus + filter[0] + "-" + visits.Status.Slug();
            }

            routes.PeriodFilter = FilterPrefix.Period + filter[1];
          //  routes.NurseFilter = FilterPrefix.Nurse + filter[0];
            routes.ContractDateFilter = FilterPrefix.ContractDate + filter[0];

            //  routes.StartDateFilter = FilterPrefix.StartDate + filter[2]; we'll revise when addung date filter
            // routes.EndDateFilter = FilterPrefix.EndDate + filter[3]; will revise when adding date filter


        }

        public void ClearFilterSegments() => routes.ClearFilters();

        string def = CareVisitGridDTO.DefaultFilter;
        public bool IsFilterByVisitStatus => routes.VisitStatusFilter != def;
        public bool IsFilterByPeriod => routes.PeriodFilter != def;
        public bool IsFilterByNurse => routes.NurseFilter != def;
        public bool IsFilterByContractDate => routes.ContractDateFilter != def;
        public bool IsFilterByEndDate => routes.EndDateFilter != def;


        public bool IsSortBy => routes.SortField.EqualsNoCase(nameof(CareVisits));
    }
}
