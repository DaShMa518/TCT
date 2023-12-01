using Microsoft.AspNetCore.Identity;

namespace TCT.Models
{
    public class TCTUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
