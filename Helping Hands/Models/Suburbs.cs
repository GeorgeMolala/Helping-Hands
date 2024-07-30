﻿using Helping_Hands.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Helping_Hands
{
    public class Suburbs
    {


        [Key]
        public int SuburbID { get; set; }
        public string Name { get; set; }
        public int PostalCode { get; set; }
        public int CityID { get; set; }
        public string Status { get; set; }

        public Cities City { get; set; }
        public ICollection<CareContracts> CareContracts { get; set; }
        public ICollection<Managers> Managers { get; set; }
        public ICollection<Organisations> Organisations { get; set; }
        public ICollection<Patients> Patients { get; set; }
        public ICollection<PreferedSuburbs> PreferedSuburbs { get; set; }
    }
}
