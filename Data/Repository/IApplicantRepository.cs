using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simple_Api_Assessment.Models;
using Simple_Api_Assessment.Models.DTOs;

namespace Simple_Api_Assessment.Data.Repository
{
    public interface IApplicantRepository
    {
    Task<List<ApplicantDTO>> GetAllApplicants();
    Task<ApplicantDTO> GetApplicantById(int id);
    Task<Applicant> AddApplicant(CreateApplicantDTO createApplicantDTO);
    Task<Applicant> UpdateApplicant(UpdateApplicantDTO updateApplicantDTO, int id);
    Task<bool> DeleteApplicant(int id);
    }
}