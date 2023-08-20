using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Helping_Hands
{
    public partial class Nurses
    {
     

        [Key]
        public int NurseUserID { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; }
        public string NurseCode { get; set; }
        public double? IdNumber { get; set; }
        public string EmailAddress { get; set; }
        public string NurseContact { get; set; }
        public string LineAddress1 { get; set; }
        public string LineAddress2 { get; set; }
        public int? ProvinceID { get; set; }
        public int? CityID { get; set; }
        public int? SuburbID { get; set; }
        public string Status { get; set; }

        public ICollection<CareContracts> CareContracts { get; set; }
        public  ICollection<CareVisits> CareVisits { get; set; }
        public  ICollection<PreferedSuburbs> PreferedSuburbs { get; set; }
    }
}
