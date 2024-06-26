using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_Api_Assessment.Models
{
    public class Skill
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int  ApplicantId {get; set;}
        [NotMapped]
        public Applicant Applicant { get; set; }
    }
}