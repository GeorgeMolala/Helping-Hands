using System.ComponentModel.DataAnnotations;

namespace Helping_Hands
{
    public class Admins
    {

        [Key]
        public int AdminUserID { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; }
        public int IdNumber { get; set; }
        public string EmailAddress { get; set; }
        public int AdminContact { get; set; }
        public string LineAddress1 { get; set; }
        public string LineAddress2 { get; set; }
        public int ProvinceID { get; set; }
        public int CityID { get; set; }
        public int SuburbID { get; set; }
        public string Status { get; set; }
    }
}
