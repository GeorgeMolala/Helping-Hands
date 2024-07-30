using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Helping_Hands.Models
{
    [NotMapped]
    public class ChangePass
    {

        [Required]
        public string OldPassword { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string NewPasword { get; set; }
    }
}
