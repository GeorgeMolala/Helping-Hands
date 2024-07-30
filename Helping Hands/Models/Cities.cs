using Helping_Hands.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Helping_Hands
{
    public partial class Cities
    {


        [Key]
        public int CityID { get; set; }
        public string Name { get; set; }
        public string Abbrev { get; set; }
        public int ProvinceID { get; set; }
        public string Status { get; set; }

        public Provinces Province { get; set; }
        public ICollection<CareContracts> CareContracts { get; set; }
        public ICollection<Managers> Managers { get; set; }
        public ICollection<Organisations> Organisations { get; set; }
        public ICollection<Patients> Patients { get; set; }
        public ICollection<PreferedSuburbs> PreferedSuburbs { get; set; }
        public ICollection<Suburbs> Suburbs { get; set; }
    }
}
