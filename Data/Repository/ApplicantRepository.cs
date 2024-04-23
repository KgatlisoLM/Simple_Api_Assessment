using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Simple_Api_Assessment.Models;
using Simple_Api_Assessment.Models.DTOs;

namespace Simple_Api_Assessment.Data.Repository
{
    public class ApplicantRepository : IApplicantRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ApplicantRepository(DataContext context, IMapper mapper)
        { 
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<List<ApplicantDTO>> GetAllApplicants()
        {
            var applicants = await _context.Applicants
                                     .Include(x =>x.Skills)
                                     .ToListAsync();

            var data = _mapper.Map<List<Applicant>, List<ApplicantDTO>>(applicants);

            return data;
        }

        public async Task<ApplicantDTO> GetApplicantById(int id)
        {     
            var applicant = await _context.Applicants
                                          .Include(x => x.Skills)
                                          .FirstOrDefaultAsync(a => a.Id == id);

            var data = _mapper.Map<Applicant, ApplicantDTO>(applicant);

            return data;
        }

        public async Task<Applicant> AddApplicant(CreateApplicantDTO createApplicantDTO)
        {
    
             Applicant createApplicant = new(){
                Name = createApplicantDTO.Name
             };

            _context.Applicants.Add(createApplicant);
            await  _context.SaveChangesAsync();

            return createApplicant;
        }

        public async Task<Applicant> UpdateApplicant(UpdateApplicantDTO updateApplicantDTO, int id)
        {
             Applicant applicantFromDb = await _context.Applicants.FindAsync(id);

             if(applicantFromDb != null ) {

                applicantFromDb.Name = updateApplicantDTO.Name;

                _context.Applicants.Update(applicantFromDb);
                await _context.SaveChangesAsync();
             }

            return null;
        }

        public async Task<bool> DeleteApplicant(int id)
        {
            var applicant = await _context.Applicants.FindAsync(id);

            if(applicant != null) {
                _context.Applicants.Remove(applicant);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}