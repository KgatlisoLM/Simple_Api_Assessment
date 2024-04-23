using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Simple_Api_Assessment.Models;

namespace Simple_Api_Assessment.Data
{
    public class DbInitializer
    {
        public static void InitDb(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            SeedData(scope.ServiceProvider.GetService<DataContext>());
        }

        private static void SeedData(DataContext context)
        {
            context.Database.Migrate();

            if (context.Applicants.Any())
            {
                Console.WriteLine("Applicant already has data - no need to seed");
                return;
            }

            //Seed Applicant
            var applicant = new List<Applicant>(){

               new Applicant
               {
                
                  Name = "Kgatliso Leroy Matema",
               },
            };

            context.AddRange(applicant);
            context.SaveChanges();


            if (context.Skills.Any())
            {
                Console.WriteLine("Skill already has data - no need to seed");
                return;
            }

            //Seed Skills
            var skill = new List<Skill>(){

                new Skill {
                 
                   Name = ".Net",
                   ApplicantId = 1
                },

                new Skill {
                  
                   Name = "C#",
                   ApplicantId = 1
                },

                new Skill {
                 
                   Name = "API",
                   ApplicantId = 1
                }

            };

            context.AddRange(skill);
            context.SaveChanges();

        }

    }
}