using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Helping_Hands.Models
{
    public class Patients
    {
        [Key]
        public int PatientUserID { get; set; }

        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; }
        public double? IdNumber { get; set; }
        public DateTime? Dob { get; set; }
        public string NextOfKinName { get; set; }
        public string NextOfKinContact { get; set; }
        public string EmailAddress { get; set; }
        public string PatientContact { get; set; }
        public string AdditionalInfor { get; set; }
        public string LineAddress1 { get; set; }
        public string LineAddress2 { get; set; }
        public int ProvinceID { get; set; }
        public int CityID { get; set; }
        public int SuburbID { get; set; }
        public string Status { get; set; }




        [NotMapped]
        public string OldPassword { get; set; }


        [NotMapped]
        [DataType(DataType.Password)]
        public string NewPasword { get; set; }

        public Cities City { get; set; }
        public Provinces Province { get; set; }
        public Suburbs Suburb { get; set; }
        public ICollection<CareContracts> CareContracts { get; set; }

        public ICollection<ChronicAccoms> ChronicAccoms { get; set; }
    }
}
