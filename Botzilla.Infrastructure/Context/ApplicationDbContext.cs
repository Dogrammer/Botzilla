using Botzilla.Domain.Domain;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Botzilla.Infrastructure.Context
{
    //public class ApplicationDbContext : IdentityDbContext<User, Role, int>
    public class ApplicationDbContext : Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<User, Role, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<User> AuthUser { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<News> Articles { get; set; }
        public DbSet<Lection> Lections { get; set; }
        public DbSet<Section> Sections { get; set; }
    }
}
