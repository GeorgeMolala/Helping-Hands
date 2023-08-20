using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Helping_Hands.Models
{

    [NotMapped]
    public class UserCred
    {

        [StringLength(40)]
        public string UserName { get; set; }


        [StringLength(50)]
        public string Password { get; set; }



        public string ConfirmPassword { get; set; }
    }
}
