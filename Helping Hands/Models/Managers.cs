using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        public  Cities City { get; set; }
        public  Organisations Npo { get; set; }
        public  Provinces Province { get; set; }
        public  Suburbs Suburb { get; set; }
    }
}
