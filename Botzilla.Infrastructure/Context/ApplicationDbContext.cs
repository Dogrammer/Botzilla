using Botzilla.Domain.Domain;
using Botzilla.Domain.DomainBaseClasses;
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
        public DbSet<DocumentBase> Images { get; set; }
        public DbSet<EmailContact> EmailContacts { get; set; }
        public DbSet<EmailSubject> EmailSubjects{ get; set; }
        
        //public DbSet<NewsImage> NewsImages { get; set; }



    }
}
