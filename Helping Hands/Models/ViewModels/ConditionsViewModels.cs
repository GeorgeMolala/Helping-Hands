using Helping_Hands.Data;
using System.Collections.Generic;

namespace Helping_Hands.Models.ViewModels
{
    public class ConditionsViewModels
    {
        public IEnumerable<ChronicAccoms> ChronicAccoms { get; set; }
        public IEnumerable<ChronicInfections> ChronicInfections { get; set; }
        public IEnumerable<Patients> Patients { get; set; }



        public RouteDictionary CurrentRoute { get; set; }
        public int TotalPages { get; set; }

        public int[] PageSizes => new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    }
}
