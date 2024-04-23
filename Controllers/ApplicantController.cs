using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Simple_Api_Assessment.Data.Repository;
using Simple_Api_Assessment.Models;
using Simple_Api_Assessment.Models.DTOs;

namespace Simple_Api_Assessment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly ApiResponse _response;

        public ApplicantController(IApplicantRepository applicantRepository)
        {
            _applicantRepository = applicantRepository;
            _response = new ApiResponse();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllApplicants()
        {
            var applicants = await _applicantRepository.GetAllApplicants();
            _response.Result = applicants;
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }


        [HttpGet("{id}", Name = "GetApplicantById")]
        public async Task<IActionResult> GetApplicantById(int id)
        {
            var applicant = await _applicantRepository.GetApplicantById(id);
            _response.Result = applicant;
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> AddApplicant(CreateApplicantDTO createApplicantDTO)
        {
            try
            {

                if (ModelState.IsValid)
                {
                     var createApplicant = await _applicantRepository.AddApplicant(createApplicantDTO);
                     _response.Result = createApplicant;   
                    _response.StatusCode = HttpStatusCode.Created;
                    return CreatedAtRoute("GetApplicantById", new { id = createApplicant.Id }, _response);
                }
                else
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Failed to add new applicant!");
                    return BadRequest(_response);

                }

            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>()

                {
                   ex.ToString()
                };
            }

            return _response;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse>> ApplicantUpdate(int id, [FromBody] UpdateApplicantDTO updateApplicantDTO)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    if (updateApplicantDTO == null || id != updateApplicantDTO.Id)
                    {
                        _response.StatusCode = HttpStatusCode.BadRequest;
                        _response.IsSuccess = false;
                        _response.ErrorMessages.Add("Failed to update applicant!");
                        return BadRequest(_response);
                    }
                    else
                    {
                        var updateApplicant = await _applicantRepository.UpdateApplicant(updateApplicantDTO, id);
                        _response.StatusCode = HttpStatusCode.NoContent;
                        return Ok(_response);
                    }
                }

            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>()
                {
                   ex.ToString()
                };
            }

            return _response;
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse>> ApplicantDelete(int id)
        {
            try
            {
                await _applicantRepository.DeleteApplicant(id);
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>()
                {
                    ex.ToString()
                };
            }

            return _response;
        }
    }
}