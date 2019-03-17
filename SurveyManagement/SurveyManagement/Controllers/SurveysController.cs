using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurveyManagement;
using AutoMapper;
using SurveyManagement.DataAccess;
using SurveyManagement.DataAccess.Entities;

using SurveyManagement.BusinessLogic.Services;

namespace SurveyManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveysController : Controller
    {
        private readonly ISurveyService _surveyService;
        private readonly IMapper _mapper;

        public SurveysController(ISurveyService surveyService, IMapper mapper)
        {
            _surveyService = surveyService;
            _mapper = mapper;
        }

        // GET: api/Surveys
        [HttpGet]
        public IEnumerable<SurveyDto> GetAllSurveys()
        {

            var surveys = _surveyService.Surveys.ToList();
            var surveyDtos = surveys.Select(_mapper.Map<Survey, SurveyDto>);

            return surveyDtos;
        }

        // GET: api/Surveys/5
        [HttpGet("{id}")]
        public IActionResult GetSurvey(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var survey = _surveyService.Surveys.Find(id);

            if (survey == null)
            {
                return NotFound();
            }

            return Ok(survey);
        }

        // PUT: api/Surveys/5
        [HttpPut("{id}")]
        public IActionResult UpdateSurvey(int id, SurveyDto survey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != survey.Id)
            {
                return BadRequest();
            }

            var _survey = _mapper.Map<SurveyDto, Survey>(survey);
            _surveyService.Entry(_survey).State = EntityState.Modified;

            try
            {
                _surveyService.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SurveyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Surveys
        [HttpPost]
        public IActionResult CreateSurvey(SurveyDto survey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var _survey = _mapper.Map<SurveyDto, Survey>(survey);

            _surveyService.Surveys.Add(_survey);
            _surveyService.SaveChanges();

            return CreatedAtAction("GetSurvey", new { id = _survey.Id }, _survey);
        }

        // DELETE: api/Surveys/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSurvey(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var survey = _surveyService.Surveys.Find(id);
            if (survey == null)
            {
                return NotFound();
            }

            _surveyService.Surveys.Remove(survey);
            _surveyService.SaveChanges();

            return Ok(survey);
        }

        private bool SurveyExists(int id)
        {
            return _surveyService.Surveys.Any(e => e.Id == id);
        }
    }
}