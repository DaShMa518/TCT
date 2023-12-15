using Microsoft.AspNetCore.Identity;

namespace TCT.Models
{
    public class TCTUser : IdentityUser
    {
        //public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
