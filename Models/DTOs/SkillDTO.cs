using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_Api_Assessment.Models.DTOs
{
    public class SkillDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CreateSkillDTO {
        public string Name { get; set; }
        public int ApplicantId { get; set;}
    }


    public class UpdateSkillDTO {
        public int Id { get; set; }
        public string Name { get; set; }
        public int  ApplicantId {get; set;}
    }
}