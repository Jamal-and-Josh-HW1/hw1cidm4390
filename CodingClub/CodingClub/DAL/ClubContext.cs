using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

using CodingClub.Models;


namespace CodingClub.DAL
{
    public class ClubContext : DbContext
    {
        public ClubContext() : base("ClubContext")
        {

        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().ToTable("Project");
            modelBuilder.Entity<Member>().ToTable("Member");
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<Team>().ToTable("Team");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}
