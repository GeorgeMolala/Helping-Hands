using Microsoft.AspNetCore.Identity;

namespace Helping_Hands.Data
{
    public class UserApp : IdentityUser
    {

        public int UserID { get; set; }
    }
}
