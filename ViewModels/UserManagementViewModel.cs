using AdvAgency.Models;
using System.Collections.Generic;

namespace AdvAgency.ViewModels
{
    public class UserManagementViewModel
    {
        public List<Users> Users { get; set; }
        public List<string> Roles { get; set; }
    }
} 