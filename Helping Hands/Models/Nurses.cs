using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Helping_Hands
{
    public class Nurses
    {


        [Key]
        public int NurseUserID { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Gender { get; set; }

        public string NurseCode { get; set; }

        [Required]
        public string IdNumber { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string NurseContact { get; set; }
        public string LineAddress1 { get; set; }
        public string LineAddress2 { get; set; }
        public int? ProvinceID { get; set; }
        public int? CityID { get; set; }
        public int? SuburbID { get; set; }
        public string Status { get; set; }


        ///Password Field
        ///
        [NotMapped]
        [StringLength(40)]
        public string UserName { get; set; }

        [NotMapped]
        [StringLength(50)]
        public string Password { get; set; }


        [NotMapped]
        public string ConfirmPassword { get; set; }

        public ICollection<CareContracts> CareContracts { get; set; }
        public ICollection<CareVisits> CareVisits { get; set; }
        public ICollection<PreferedSuburbs> PreferedSuburbs { get; set; }
    }
}
