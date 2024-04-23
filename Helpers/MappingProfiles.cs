using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Simple_Api_Assessment.Models;
using Simple_Api_Assessment.Models.DTOs;

namespace Simple_Api_Assessment.Helpers
{
    public class MappingProfiles : Profile
    {
       public MappingProfiles() {
            
            //return applicant(s)
            CreateMap<Applicant, ApplicantDTO>();
            
            //return skill(s)
            CreateMap<Skill, SkillDTO>();


       }
    }
}