using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_Api_Assessment.Models
{
    public class Applicant
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set;}
        public IReadOnlyList<Skill> Skills { get; set; }
        
    }
}