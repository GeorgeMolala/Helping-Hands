using Helping_Hands.Data;
using Helping_Hands.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Helping_Hands
{
    public class CareContracts
    {
        

        [Key]
        public int ContractNumberID { get; set; }
        public DateTime ContractDate { get; set; }
        public int PatientUserID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string WoundDescription { get; set; }
        public byte[] ImageData { get; set; }
        public int NurseUserID { get; set; }
        public int ProvinceID { get; set; }
        public int CityID { get; set; }
        public int SuburbID { get; set; }
        public string Status { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        public Cities City { get; set; }
        public Nurses NurseUser { get; set; }
        public Patients PatientUser { get; set; }
        public Provinces Province { get; set; }
        public Suburbs Suburb { get; set; }
        public ICollection<CareVisits> CareVisits { get; set; }
    }
}
