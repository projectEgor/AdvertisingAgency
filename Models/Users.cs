using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace AdvAgency.Models
{
    public class Users : IdentityUser
    {
        public string FullName { get; set; }
        public virtual ICollection<AdOrder> AdOrders { get; set; }
    }
}