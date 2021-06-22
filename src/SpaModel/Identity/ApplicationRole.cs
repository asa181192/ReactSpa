using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaModel.Identity
{
    public class ApplicationRole:IdentityRole
    {

        public List<ApplicationUserRole> UserRoles { get; set; }
    }
}
