using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_Api_Assessment.Models.DTOs
{
    public class ApplicantDTO
    {
        public int Id { get; set; }
        public string Name { get; set;}
        public IReadOnlyList<SkillDTO> Skills { get; set; }
        
    }

    public class CreateApplicantDTO {
        public string Name { get; set;}
    }

    public class UpdateApplicantDTO {
        public int Id { get; set; }
        public string Name { get; set;}
    }

}