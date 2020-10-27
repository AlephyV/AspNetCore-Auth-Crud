using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityTeste.Models
{
    public class IdentityModel
    {
    }

    public class ApplicationUserRole : IdentityRole { }

    public class ApplicationUser : IdentityUser { }
}
