using Microsoft.AspNetCore.Http;

namespace Helping_Hands.Data
{
    public class CareContractGridBuilder : GridBuilder
    {
        public CareContractGridBuilder(ISession sess) : base(sess) { }

        public CareContractGridBuilder(ISession sess, CareContractGridDTO values, string defaultSortField) : base(sess, values, defaultSortField)
        {
            bool isinitial = values.DateTime.IndexOf(FilterPrefix.ContraType) == -1;
            routes.ContraTypeFilter = (isinitial) ? FilterPrefix.ContraType + values.ContractType : values.ContractType;
            routes.PatientFilter = (isinitial) ? FilterPrefix.Patient + values.Patient : values.Patient;
            routes.PeriodFilter = (isinitial) ? FilterPrefix.Period + values.Period : values.Period;
            routes.NurseFilter = (isinitial) ? FilterPrefix.Nurse + values.Nurse : values.Nurse;

            SaveRouteSegments();
        }

        public void LoadFilterSegments(string[] filter, CareContracts care)
        {
            if (care == null)
            {
                routes.ContraTypeFilter = FilterPrefix.ContraType + filter[0];
            }
            else
            {
                routes.ContraTypeFilter = FilterPrefix.ContraType + filter[0] + "-" + care.PatientUser.FirstName.Slug();
            }

            routes.ContraTypeFilter = FilterPrefix.ContraType + filter[0];
            routes.PatientFilter = FilterPrefix.Patient + filter[1];
            routes.PeriodFilter = FilterPrefix.Period + filter[1];
            routes.NurseFilter = FilterPrefix.Nurse + filter[1];
        }

        public void ClearFilterSegments() => routes.ClearFilters();


        string def = CareContractGridDTO.DefaultFilter;
        //  string default = NurseGridDTO.DefaultFilter; 
        public bool IsFilterByPatient => routes.PatientFilter != def;
        public bool IsFilterByPeriod => routes.PeriodFilter != def;
        public bool IsFilterByNurse => routes.NurseFilter != def;
        public bool IsFilterByContractType => routes.ContraTypeFilter != def;

        public bool IsSortBy => routes.SortField.EqualsNoCase(nameof(CareContracts));
    }
}
