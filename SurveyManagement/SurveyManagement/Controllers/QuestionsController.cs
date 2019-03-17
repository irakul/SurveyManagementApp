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
        public IEnumerable<Question> GetQuestions()
        {
            return _questionService.Questions.Include(q => q.AnswerVariants).ToList();
        }

        // GET: api/Questions/5
        [HttpGet("{id}")]
        public IActionResult GetQuestion(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var question = _questionService.Questions.Include(q => q.AnswerVariants).SingleOrDefault(q => q.Id == id);

            if (question == null)
            {
                return NotFound();
            }

            return Ok(question);
        }

        // PUT: api/Questions/5
        [HttpPut("{id}")]
        public IActionResult UpdateQuestion(int id, QuestionDto question)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != question.Id)
            {
                return BadRequest();
            }

            var _question = _questionService.Questions
                .FirstOrDefault(q => q.Id == question.Id);

            _question.Text = question.Text;
            _question.Comment = question.Comment;
            _question.SurveyId = question.SurveyId;

            _question.AnswerVariants = null;

            

            _questionService.Entry(question).State = EntityState.Modified;


            try
            {
                _questionService.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionExists(id))
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

        // POST: api/Questions
        [HttpPost]
        public IActionResult PostQuestion(QuestionDto question)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var _question = _mapper.Map<QuestionDto, Question>(question);

            var _question = new Question
            {
                Id = 0,
                Text = question.Text,
                Comment = question.Comment,
                SurveyId = question.SurveyId,
                AnswerVariants = null
            };
            _questionService.Questions.Add(_question);

            foreach (var q in question.AnswerVariants)
            {
                _questionService.AnswerVariants
                    .Add(new AnswerVariant {
                        Id = 0,
                        Text = q,
                        QuestionId = _question.Id
                    });
            }
                        
            _questionService.SaveChanges();

            return CreatedAtAction("GetQuestion", new { id = _question.Id }, _question);
        }

        // DELETE: api/Questions/5
        [HttpDelete("{id}")]
        public IActionResult DeleteQuestion(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var question =  _questionService.Questions.Find(id);
            if (question == null)
            {
                return NotFound();
            }
            
            _questionService.Questions.Remove(question);
            _questionService.SaveChanges();

            return Ok(question);
        }

        private bool QuestionExists(int id)
        {
            return _questionService.Questions.Any(q => q.Id == id);
        }
    }
}