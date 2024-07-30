using System;
using System.ComponentModel.DataAnnotations;

namespace Helping_Hands
{
    public partial class CareVisits
    {

        [Key]
        public int CareVisitsID { get; set; }

        [Required]
        public int ContractNumberID { get; set; }


        public int? NurseUserID { get; set; }

        [Required]
        public DateTime? VisitDate { get; set; }



        [Required]
        public TimeSpan ApproxArriva { get; set; }

        public TimeSpan? ArrivalTime { get; set; }

        public TimeSpan? DepartTime { get; set; }


        public string WoundCondition { get; set; }


        public string Notes { get; set; }

        [Required]
        public string Status { get; set; }

        public CareContracts ContractNumber { get; set; }
        public Nurses NurseUser { get; set; }

    }
}
