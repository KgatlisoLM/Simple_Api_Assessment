using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Simple_Api_Assessment.Models;
using Simple_Api_Assessment.Models.DTOs;

namespace Simple_Api_Assessment.Data.Repository
{
    public class SkillsRepository : ISkillsRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public SkillsRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<List<SkillDTO>> GetAllSkills()
        {
            var skills = await _context.Skills.ToListAsync();

            var data = _mapper.Map<List<Skill>, List<SkillDTO>>(skills);

            return data;
        }

        public async Task<SkillDTO> GetSkillById(int id)
        {
            var skill = await _context.Skills.FirstOrDefaultAsync(a => a.Id == id);

            var data = _mapper.Map<Skill, SkillDTO>(skill);

            return data;
        }

        public async Task<Skill> AddSkill(CreateSkillDTO createSkillDTO)
        {

            Skill createSkill = new()
            {
                Name = createSkillDTO.Name,
                ApplicantId = createSkillDTO.ApplicantId
            };

            _context.Skills.Add(createSkill);
            await _context.SaveChangesAsync();
            return createSkill;
        }

        public async Task<Skill> UpdateSkill(UpdateSkillDTO updateSkillDTO, int id)
        {
            Skill skillFromDb = await _context.Skills.FindAsync(id);

            if (skillFromDb != null)
            {
                skillFromDb.Name = updateSkillDTO.Name;
                skillFromDb.ApplicantId = updateSkillDTO.ApplicantId;

                _context.Skills.Update(skillFromDb);
                await _context.SaveChangesAsync();
            }

            return null;
        }

        public async Task<bool> DeleteSkill(int id)
        {
            var skill = await _context.Skills.FindAsync(id);

            if (skill != null)
            {
                _context.Skills.Remove(skill);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

    }
}