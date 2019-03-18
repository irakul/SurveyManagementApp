using SurveyManagement.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using SurveyManagement.DataAccess.Entities;

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
            }
            
        }

        public IEnumerable<QuestionDto> GetAllQuestions()
        {
            var questions = _unitOfWork.Questions.GetAll();
            var questionDtos = new List<QuestionDto>();

            foreach (var q in questions)
            {
                var questionDto = _mapper.Map<Question, QuestionDto>(q);
                questionDtos.Add(questionDto);
            }

            return questionDtos;
        }

        public QuestionDto GetQuestion(int id)
        {
            var Question = _unitOfWork.Questions.Get(id);
            var QuestionDto = _mapper.Map<Question, QuestionDto>(Question);

            return QuestionDto;
        }

        public void UpdateQuestion(int id, QuestionDto questionDto)
        {
            var questionUpdated = _mapper.Map<QuestionDto, Question>(questionDto);
            var questionInUnitOfWork = _unitOfWork.Questions.Get(id);

            if (id == questionDto.Id)
            {
                questionInUnitOfWork.Text = questionUpdated.Text;
                questionInUnitOfWork.Comment = questionUpdated.Comment;
                questionInUnitOfWork.SurveyId = questionUpdated.SurveyId;
                questionInUnitOfWork.AnswerVariants = questionUpdated.AnswerVariants;
                _unitOfWork.Save();
            }

            

        }
    }
}
