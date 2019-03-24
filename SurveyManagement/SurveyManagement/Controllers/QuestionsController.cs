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
    public class QuestionsController : Controller
    {
        private readonly IQuestionService _questionService;
        private readonly IMapper _mapper;

        public QuestionsController(IQuestionService questionService, IMapper mapper)
        {
            _questionService = questionService;
            _mapper = mapper;
        }

        // GET: api/Questions
        [HttpGet]
        public IEnumerable<QuestionViewModel> GetAllQuestions()
        {
            IEnumerable<QuestionViewModel> questionVMs;
            var questions = _questionService.GetAllQuestions();

            questionVMs = _mapper.Map<IEnumerable<QuestionDto>, IEnumerable<QuestionViewModel>>(questions);
            return questionVMs;
        }

        // GET: api/Questions/5
        [HttpGet("{id}")]
        public IActionResult GetQuestion(int id)
        {

            var question = _questionService.GetQuestion(id);

            return Ok(question);
        }

        // PUT: api/Questions/5
        [HttpPut("{id}")]
        public IActionResult UpdateQuestion(int id, QuestionViewModel questionVM)
        {
            var _question = _mapper.Map<QuestionViewModel, QuestionDto>(questionVM);

            _questionService.UpdateQuestion(questionVM.Id, _question);

            return NoContent();
        }

        // POST: api/Questions
        [HttpPost]
        public IActionResult CreateQuestion(QuestionViewModel questionVM)
        {

            var _question = _mapper.Map<QuestionViewModel, QuestionDto>(questionVM);
            _questionService.CreateQuestion(_question);

            return CreatedAtAction("GetQuestion", new { id = _question.Id }, _question);
        }

        // DELETE: api/Questions/5
        [HttpDelete("{id}")]
        public IActionResult DeleteQuestion(int id)
        {

            var question = _questionService.GetQuestion(id);
            if (question == null)
            {
                return NotFound();
            }

            _questionService.DeleteQuestion(question.Id);

            return Ok(question);
        }
    }
}