using Microsoft.AspNetCore.Identity;

namespace AdvAgency.Models
{
    public class Users: IdentityUser
    {
        public string FullName {  get; set; }
    }
}
