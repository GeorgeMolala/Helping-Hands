using System.ComponentModel.DataAnnotations;

namespace Helping_Hands
{
    public class PreferedSuburbs
    {

        [Key]
        public int PreferedSubID { get; set; }
        public int? NurseUserID { get; set; }
        public int? CityID { get; set; }
        public int? SuburbID { get; set; }

        public Cities? City { get; set; }
        public Nurses? NurseUser { get; set; }
        public Suburbs? Suburb { get; set; }
    }
}
