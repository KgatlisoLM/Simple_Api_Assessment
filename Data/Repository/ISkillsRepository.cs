using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simple_Api_Assessment.Models;
using Simple_Api_Assessment.Models.DTOs;

namespace Simple_Api_Assessment.Data.Repository
{
    public interface ISkillsRepository
    {
        Task<List<SkillDTO>> GetAllSkills();
        Task<SkillDTO> GetSkillById(int id);
        Task<Skill> AddSkill(CreateSkillDTO skillDto);
        Task<Skill> UpdateSkill(UpdateSkillDTO updateSkillDTO, int id);
        Task<bool> DeleteSkill(int id);

    }
}