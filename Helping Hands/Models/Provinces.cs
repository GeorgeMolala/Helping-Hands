using Helping_Hands.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Helping_Hands
{
    public class Provinces
    {


        [Key]
        public int ProvinceID { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }

        public ICollection<CareContracts> CareContracts { get; set; }
        public ICollection<Cities> Cities { get; set; }
        public ICollection<Managers> Managers { get; set; }
        public ICollection<Organisations> Organisations { get; set; }
        public ICollection<Patients> Patients { get; set; }
    }
}
