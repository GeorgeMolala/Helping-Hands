using Helping_Hands.Data.GRID;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Helping_Hands.Data
{
    // static class of constants used to add and remove user-friendly
    // prefix from filter route segment values. Public class rather
    // than private constants bc also used by BookstoreGridBuilder class.

    public static class FilterPrefix
    {
        public const string Suburb = "suburb-";
        public const string Nurse = "nurse-";
        public const string ContraType = "status-";
        public const string Location = "location";
        public const string Status = "Managerstatus-";

        //Care Visits
        public const string VisitStatus = "visitstatus-";

        public const string Period = "week-";
        public const string ContractDate = "contractDate-";
        public const string EndDate = "endDate-";
        public const string Patient = "patient-";

        //Suburb
        public const string NoFilter = "nofilter-";

        //City
        public const string CityLoc = "cityloc";

    }


    public class RouteDictionary : Dictionary<string, string>
    {

        public int PageNumber
        {
            get => Get(nameof(GridDTO.PageNumber)).ToInt();
            set => this[nameof(GridDTO.PageNumber)] = value.ToString();
        }

        public int PageSize
        {
            get => Get(nameof(GridDTO.PageSize)).ToInt();
            set => this[nameof(GridDTO.PageSize)] = value.ToString();
        }

        public string SortField
        {
            get => Get(nameof(GridDTO.SortField));
            set => this[nameof(GridDTO.SortField)] = value;
        }

        public string SortDirection
        {
            get => Get(nameof(GridDTO.SortDirection));
            set => this[nameof(GridDTO.SortDirection)] = value;
        }



        private string Get(string key) => Keys.Contains(key) ? this[key] : null;

        public void SetSortAndDirection(string fieldName, RouteDictionary current)
        {

            this[nameof(GridDTO.SortField)] = fieldName;

            if (current.SortField.EqualsNoCase(fieldName) &&
                current.SortDirection == "asc")
                this[nameof(GridDTO.SortDirection)] = "asc";
            else
                this[nameof(GridDTO.SortDirection)] = "asc";
        }

        public string StatusFilter
        {
            get => Get(nameof(ManagerGridDTO.Status)).Replace(FilterPrefix.Status, "");
            set => this[nameof(ManagerGridDTO.Status)] = value;
        }

        public string SuburbFilter
        {
            get
            {
                string s = Get(nameof(NurseGridDTO.Suburb))?.Replace(
                FilterPrefix.Suburb, "");
                int index = s?.IndexOf('-') ?? -1;
                return (index == -1) ? s : s.Substring(0, index);
            }
            set => this[nameof(NurseGridDTO.Suburb)] = value;
        }
        //  Care Visit Filter
        public string PatientFilter
        {
            get
            {
                string s = Get(nameof(CareContractGridDTO.Patient))?.Replace(
                    FilterPrefix.Patient, "");
                int index = s?.IndexOf('-') ?? -1;
                return (index == -1) ? s : s.Substring(0, index);
            }
            set => this[nameof(CareContractGridDTO.Patient)] = value;
        }
        public string VisitStatusFilter
        {
            get => Get(nameof(CareVisitGridDTO.VisitStatus)).Replace(FilterPrefix.VisitStatus, "");
            set => this[nameof(CareVisitGridDTO.VisitStatus)] = value;
        }

        public string ContractDateFilter
        {
            get => Get(nameof(CareVisitGridDTO.ContractDate))?.Replace(FilterPrefix.ContractDate, "");
            set => this[nameof(CareVisitGridDTO.ContractDate)] = value;
        }

        public string EndDateFilter
        {
            get => Get(nameof(CareVisitGridDTO.EndDate))?.Replace(FilterPrefix.EndDate, "");
            set => this[nameof(CareVisitGridDTO.EndDate)] = value;
        }

        public string PeriodFilter
        {
            get => Get(nameof(CareVisitGridDTO.Period))?.Replace(FilterPrefix.Period, "");
            set => this[nameof(CareVisitGridDTO.Period)] = value;
        }

        public string CityLocFilter
        {
            get => Get(nameof(SuburbGridDTO.CityLoc))?.Replace(FilterPrefix.CityLoc, "");
            set => this[nameof(SuburbGridDTO.CityLoc)] = value;
        }


        //Nurse Filter Prefered Suburbs
        public string LocationFilter
        {
            get => Get(nameof(PreferedSuburbGridDTO.Location).Replace(FilterPrefix.Location, ""));
            set => this[nameof(PreferedSuburbGridDTO.Location)] = value;
        }

        public string NurseFilter
        {
            get
            {
                string s = Get(nameof(CareContractGridDTO.Nurse))?.Replace(
                    FilterPrefix.Nurse, "");
                int index = s?.IndexOf('-') ?? -1;
                return (index == -1) ? s : s.Substring(0, index);
            }
            set => this[nameof(CareContractGridDTO.Nurse)] = value;
        }

        public string NoFilterFilter
        {
            get => Get(nameof(CityGridDTO.NoFilter))?.Replace(FilterPrefix.NoFilter, "");
            set => this[nameof(CityGridDTO.NoFilter)] = value;
        }

        public string ContraTypeFilter
        {
            get => Get(nameof(CareContractGridDTO.ContractType))?.Replace(FilterPrefix.ContraType, "");
            set => this[nameof(CareContractGridDTO.ContractType)] = value;
        }

        public void ClearFilters() =>
           SuburbFilter = NurseGridDTO.DefaultFilter;


        public RouteDictionary Clone()
        {
            var clone = new RouteDictionary();
            foreach (var key in Keys)
            {
                clone.Add(key, this[key]);
            }
            return clone;
        }
    }
}
