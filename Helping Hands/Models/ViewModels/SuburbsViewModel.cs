using Helping_Hands.Data;
using System.Collections.Generic;

namespace Helping_Hands.Models.ViewModels
{
    public class SuburbsViewModel
    {

        public IEnumerable<Suburbs> Suburbs { get; set; }
        public IEnumerable<Cities> Cities { get; set; }

        public IEnumerable<Provinces> Provinces { get; set; }

        public RouteDictionary CurrentRoute { get; set; }
        public int TotalPages { get; set; }
        public int[] PageSizes => new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

    }
}
