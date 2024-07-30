using Helping_Hands.Data;
using System.Collections.Generic;

namespace Helping_Hands.Models.ViewModels
{
    public class PatientViewModels
    {
        public IEnumerable<ChangePass> ChangePasses { get; set; }
        public IEnumerable<Patients> Patients { get; set; }
        public IEnumerable<Suburbs> Suburbs { get; set; }
        public IEnumerable<Cities> Cities { get; set; }

        public Dictionary<string, string> ContraType =>
        new Dictionary<string, string> {
                { "Assigned", "Assigned" },
                { "Closed", "Closed" },
                { "New", "New" }
        };

        public int[] PageSizes => new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        public RouteDictionary CurrentRoute { get; set; }
        public int TotalPages { get; set; }

        public IEnumerable<ChronicAccoms> ChronicAccoms { get; set; }
        public IEnumerable<ChronicInfections> ChronicInfections { get; set; }

    }
}
