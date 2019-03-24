using SurveyManagement.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using SurveyManagement.DataAccess.Entities;
using System.Linq;

namespace SurveyManagement.BusinessLogic.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public QuestionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void CreateQuestion(QuestionDto question)
        {
            var _question = _mapper.Map<QuestionDto, Question>(question);

            _unitOfWork.Questions.Add(_question);
            _unitOfWork.Save();
        }
        public void DeleteQuestion(int id)
        {
            var _question = _unitOfWork.Questions.Get(id);
            if (_question != null)
            {
                _unitOfWork.Questions.Remove(_question);
                _unitOfWork.Save();
            }

        }

        public IEnumerable<QuestionDto> GetAllQuestions()
        {
            
            var questions = _unitOfWork.Questions.GetAll().ToList();
            var answers = _unitOfWork.AnswerVariants.GetAll().ToList();

            var fullQuestions = questions.GroupJoin(answers, q => q.Id, a => a.QuestionId, (q,a) => new Question
            {
                Id = q.Id,
                AnswerVariants = a.ToList(),
                Comment = q.Comment,
                Text = q.Text,
                SurveyId = q.SurveyId
            });

            
            var questionDtos = _mapper.Map<IEnumerable<Question>, IEnumerable<QuestionDto>>(fullQuestions);

            //foreach (var q in questions)
            //{
            //    var questionDto = _mapper.Map<Question, QuestionDto>(q);
            //    questionDtos.Add(questionDto);
            //}

            return questionDtos;
        }
         
        public QuestionDto GetQuestion(int id)
        {
            var question = _unitOfWork.Questions.Get(id);
            //var answers = _unitOfWork.AnswerVariants.Find(m => m.QuestionId == id).ToList();

            //question.AnswerVariants = answers;

            var questionDto = new QuestionDto() { AnswerVariants = new List<string>() };

            questionDto = _mapper.Map<Question, QuestionDto>(question);

            return questionDto;
        }

        public void UpdateQuestion(int id, QuestionDto questionDto)
        {
            var questionUpdated = new Question();
            questionUpdated = _mapper.Map<QuestionDto, Question>(questionDto);

            _unitOfWork.Questions.Update(questionUpdated);
            
            

            _unitOfWork.Save();

        }
    }
}
