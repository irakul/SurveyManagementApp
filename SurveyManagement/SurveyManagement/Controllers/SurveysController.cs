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
using SurveyManagement.ViewModels;

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
        public IEnumerable<SurveyViewModel> GetAllSurveys()
        {
            var surveys = _surveyService.GetAllSurveys();

            var surveyVMs = new List<SurveyViewModel>();

            foreach(var s in surveys)
            {
                var surveyVM = _mapper.Map<SurveyDto, SurveyViewModel>(s);
                surveyVMs.Add(surveyVM);
            }
            return surveyVMs;
        }

        // GET: api/Surveys/5
        [HttpGet("{id}")]
        public IActionResult GetSurvey(int id)
        {

            var survey = _surveyService.GetSurvey(id);

            return Ok(survey);
        }

        // PUT: api/Surveys/5
        [HttpPut("{id}")]
        public IActionResult UpdateSurvey(int id, SurveyViewModel surveyVM)
        {
            var _survey = _mapper.Map<SurveyViewModel, SurveyDto>(surveyVM);

            _surveyService.UpdateSurvey(surveyVM.Id, _survey);
            
            return NoContent();
        }

        // POST: api/Surveys
        [HttpPost]
        public IActionResult CreateSurvey(SurveyViewModel surveyVM)
        {

            var _survey = _mapper.Map<SurveyViewModel, SurveyDto>(surveyVM);
            _surveyService.CreateSurvey(_survey);

            return CreatedAtAction("GetSurvey", new { id = _survey.Id }, _survey);
        }

        // DELETE: api/Surveys/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSurvey(int id)
        {

            var survey = _surveyService.GetSurvey(id);
            if (survey == null)
            {
                return NotFound();
            }

            _surveyService.DeleteSurvey(survey.Id);

            return Ok(survey);
        }

    }
}