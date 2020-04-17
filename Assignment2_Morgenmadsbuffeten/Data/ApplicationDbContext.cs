using System;
using System.Collections.Generic;
using System.Text;
using Assignment2_Morgenmadsbuffeten.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Assignment2_Morgenmadsbuffeten.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
        public DbSet<CheckedInGuest> CheckedInGuests { get; set; }
        public DbSet<ExpectedGuest> ExpectedGuests { get; set; }

    }
}
