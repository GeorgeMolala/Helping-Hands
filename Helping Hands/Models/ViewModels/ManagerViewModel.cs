using Helping_Hands.Data;
using System.Collections.Generic;

namespace Helping_Hands.Models.ViewModels
{
    public class ManagerViewModel
    {
        public Dictionary<string, string> Status => new Dictionary<string, string>
        {
            {"Active", "Active" },
            {"InActive", "InActive" },
        };

        public IEnumerable<Nurses> Nurses { get; set; }
        public IEnumerable<Managers> Managers { get; set; }

        public RouteDictionary CurrentRoute { get; set; }
        public int TotalPages { get; set; }
        public int[] PageSizes => new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    }
}
