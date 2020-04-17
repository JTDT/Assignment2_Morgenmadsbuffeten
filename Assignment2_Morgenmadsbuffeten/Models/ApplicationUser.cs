using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Assignment2_Morgenmadsbuffeten.Models
{
    public class ApplicationUser : IdentityUser
    {        
        [PersonalData]
        public string Name { get; set; }
    }
}
