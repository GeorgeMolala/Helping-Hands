using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Helping_Hands
{
    public partial class ChronicInfections
    {


        [Key]
        public int ChronicID { get; set; }
        public string ConditionName { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        public ICollection<ChronicAccoms> ChronicAccoms { get; set; }
    }
}
