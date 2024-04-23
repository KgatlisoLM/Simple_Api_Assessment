using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Simple_Api_Assessment.Models;

namespace Simple_Api_Assessment.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Skill> Skills { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
               modelBuilder.Entity<Applicant>()
                    .Property(a => a.Id)
                    .UseIdentityByDefaultColumn();

                modelBuilder.Entity<Skill>()
                    .Property(s => s.Id)
                    .UseIdentityByDefaultColumn();


              modelBuilder.Entity<Applicant>().HasData( 
                 new {
                     Id = 1,
                     Name = "Kgatliso Leroy Matema"
                 });

              modelBuilder.Entity<Skill>().HasData( 
                new {
                    Id = 1,
                    Name = ".Net",
                    ApplicantId = 1
                },
                new {
                    Id = 2,
                    Name = "C#",
                    ApplicantId = 1
                },
                new  {
                    Id = 3,
                    Name = "API",
                    ApplicantId = 1
                }
              );
        }



    }
}