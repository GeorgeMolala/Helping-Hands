using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Helping_Hands
{
    public partial class CareVisits
    {

        [Key]
        public int CareVisitsID { get; set; }
        public int ContractNumberID { get; set; }
        public int NurseUserID { get; set; }
        public DateTime VisitDate { get; set; }
        public TimeSpan ApproxArriva { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public TimeSpan DepartTime { get; set; }
        public string WoundCondition { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }

        public  CareContracts ContractNumber { get; set; }
        public Nurses NurseUser { get; set; }
    }
}
