using System.ComponentModel.DataAnnotations;

namespace Helping_Hands.Models
{
    public class Log
    {


        [Required(ErrorMessage = "Please enter a username.")]
        [StringLength(255)]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Please enter a password.")]
        [StringLength(255)]
        public string Password { get; set; }


        public string ReturnUrl { get; set; }


        public bool RememberMe { get; set; }
    }
}
