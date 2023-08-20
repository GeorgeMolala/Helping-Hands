using Helping_Hands.Data;
using Helping_Hands.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Helping_Hands
{
    public partial class ChronicAccoms
    {

        [Key]
        public int ChronicAccomID { get; set; }
        public int? ChronicID { get; set; }
        public int? PatientUserID { get; set; }
        public string Status { get; set; }

        public ChronicInfections Chronic { get; set; }
        public Patients PatientUser { get; set; }
    }
}
