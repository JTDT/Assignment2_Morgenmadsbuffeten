using Assignment2_Morgenmadsbuffeten.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Assignment2_Morgenmadsbuffeten.Data
{
    public class DbHelper
    {
        public static void SeedData(ApplicationDbContext db, UserManager<IdentityUser> userManager, ILogger log)
        {

            SeedUsers(userManager, log);
        }

        private static void SeedUsers(UserManager<IdentityUser> userManager, ILogger log)
        {
            const string receptionEmail = "reception@localhost";
            const string receptionPassword = "Secret7/";

            if (userManager.FindByNameAsync(receptionEmail).Result == null)
            {
                log.LogWarning("Seeding the admin user");
                var user = new IdentityUser()
                {
                    UserName = receptionEmail,
                    Email = receptionEmail,
                    //Name = "Reception"
                };
                IdentityResult result = userManager.CreateAsync
                    (user, receptionPassword).Result;
                if (result.Succeeded)
                {
                    var receptionClaim = new Claim("Reception", "Yes");
                    userManager.AddClaimAsync(user, receptionClaim);
                }
            }
        }
    }
}
