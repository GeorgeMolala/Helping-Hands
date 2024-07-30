using Helping_Hands.Data;
using System.Collections.Generic;

namespace Helping_Hands.Models.ViewModels
{
    public class CareVisitListViewModel
    {
        public IEnumerable<CareVisits> CareVisit { get; set; }
        public RouteDictionary CurrentRoute { get; set; }

        
        public IEnumerable<CareContracts> CareContracts { get; set; }
        public CareVisits CareVst { get; set; }
        public int TotalPages { get; set; }


        // for filter drop-down data- one hard-coded
        public IEnumerable<Patients> Patients { get; set; }
        public IEnumerable<Nurses> Nurses { get; set; }

        public IEnumerable<CareContracts> Contracts { get; set; }

        public IEnumerable<Cities> Cities { get; set; }

        public IEnumerable<Suburbs> Suburbs { get; set; }

        public Dictionary<string, string> Period =>
           new Dictionary<string, string> {
                { "Week", "Week" },
                { "Month", "Month" },

           };

        public Dictionary<string, string> Status => new Dictionary<string, string>
        {
            {"Open", "Open" },
            {"Closed", "Closed" },
        };



        public int[] PageSizes => new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    }
}
