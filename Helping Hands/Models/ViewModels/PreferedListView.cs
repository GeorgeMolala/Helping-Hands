using Helping_Hands.Data;
using System.Collections.Generic;

namespace Helping_Hands.Models.ViewModels
{
    public class PreferedListView
    {
        public IEnumerable<PreferedSuburbs> PreferSub { get; set; }
        public IEnumerable<PreferedSuburbs> PreferModal { get; set; }
        public RouteDictionary CurrentRoute { get; set; }
        public int TotalPages { get; set; }



        // for filter drop-down data- one hard-coded
        public IEnumerable<Suburbs> Suburbs { get; set; }
        public IEnumerable<Cities> Cities { get; set; }

        public int[] PageSizes => new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

    }


}
