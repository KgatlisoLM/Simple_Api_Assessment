using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Simple_Api_Assessment.Data.Repository;
using Simple_Api_Assessment.Models;
using Simple_Api_Assessment.Models.DTOs;

namespace Simple_Api_Assessment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkillController : ControllerBase
    {
        private readonly ISkillsRepository _skillsRepository;
        private readonly ApiResponse _response;

        public SkillController(ISkillsRepository skillsRepository)
        {
            _skillsRepository = skillsRepository;
            _response = new ApiResponse();

        }

        [HttpGet]
        public async Task<IActionResult> GetAllSkills()
        {
            var skills = await _skillsRepository.GetAllSkills();
            _response.Result = skills;
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        [HttpGet("{id}", Name = "GetSkillById")]
        public async Task<IActionResult> GetSkillById(int id)
        {

            var skill = await _skillsRepository.GetSkillById(id);
            _response.Result = skill;
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> SkillAdd([FromBody] CreateSkillDTO createSkillDTO)
        {

            try
            {

                if (ModelState.IsValid)
                {
                    var createSkill = await _skillsRepository.AddSkill(createSkillDTO);
                     _response.Result = createSkill;   
                    _response.StatusCode = HttpStatusCode.Created;
                    return CreatedAtRoute("GetSkillById", new { id = createSkill.Id }, _response);
                }
                else
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Failed to add new skill!");
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
        public async Task<ActionResult<ApiResponse>> SkillUpdate(int id, [FromBody] UpdateSkillDTO updateSkillDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (updateSkillDTO == null || id != updateSkillDTO.Id)
                    {
                        _response.StatusCode = HttpStatusCode.BadRequest;
                        _response.IsSuccess = false;
                        _response.ErrorMessages.Add("Failed to update applicant!");
                        return BadRequest(_response);
                    }
                    else
                    {
                        var updateSkill = await _skillsRepository.UpdateSkill(updateSkillDTO, id);
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
        public async Task<ActionResult<ApiResponse>> SkillDelete(int id)
        {
            try
            {
                await _skillsRepository.DeleteSkill(id);
                _response.StatusCode = HttpStatusCode.NoContent;
                return NoContent();

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