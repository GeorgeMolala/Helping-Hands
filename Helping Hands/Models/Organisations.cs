using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Helping_Hands
{
    public partial class Organisations
    {
        public Organisations()
        {
            ImageArchive = new HashSet<ImageArchive>();
            Managers = new HashSet<Managers>();
        }

        [Key]
        public int NpoID { get; set; }
        public string OrganisationName { get; set; }
        public string NpoNumber { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public string WeekDay1 { get; set; }
        public string WeekDay2 { get; set; }
        public TimeSpan? OpeningTime { get; set; }
        public TimeSpan? ClosingTime { get; set; }
        public string LineAddress1 { get; set; }
        public string LineAddress2 { get; set; }
        public int ProvinceID { get; set; }
        public int CityID { get; set; }
        public int SuburbID { get; set; }
        public string Status { get; set; }

        public virtual Cities City { get; set; }
        public virtual Provinces Province { get; set; }
        public virtual Suburbs Suburb { get; set; }
        public virtual ICollection<ImageArchive> ImageArchive { get; set; }
        public virtual ICollection<Managers> Managers { get; set; }
    }
}
