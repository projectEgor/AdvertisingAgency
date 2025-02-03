using Microsoft.AspNetCore.Identity;

namespace AdAgency.Models

{
    public class User: IdentityUser
    {
        public string Role { get; set; }
        
    }
}
