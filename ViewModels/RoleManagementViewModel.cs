using System.Collections.Generic;

namespace AdvAgency.ViewModels
{
    public class RoleManagementViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public List<string> UserRoles { get; set; }
        public List<string> AllRoles { get; set; }
    }
} 