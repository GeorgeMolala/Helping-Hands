using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Helping_Hands
{
    public partial class Managers
    {

        [Key]
        public int ManagerUserID { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; }
        public int? IdNumber { get; set; }
        public string EmailAddress { get; set; }
        public string ManagerContact { get; set; }
        public int? NpoID { get; set; }
        public string LineAddress1 { get; set; }
        public string LineAddress2 { get; set; }
        public int? ProvinceID { get; set; }
        public int? CityID { get; set; }
        public int? SuburbID { get; set; }
        public string Status { get; set; }



        [NotMapped]
        [StringLength(40)]
        public string UserName { get; set; }

        [NotMapped]
        [StringLength(50)]
        public string Password { get; set; }


        [NotMapped]
        public string ConfirmPassword { get; set; }



        public Cities City { get; set; }
        public Organisations Npo { get; set; }
        public Provinces Province { get; set; }
        public Suburbs Suburb { get; set; }
    }
}
