using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyManagement.BusinessLogic.Services
{
    public interface IQuestionService
    {
        QuestionDto GetQuestion(int id);
        IEnumerable<QuestionDto> GetAllQuestions();
        void CreateQuestion(QuestionDto question);
        void DeleteQuestion(int id);
        void UpdateQuestion(int id, QuestionDto question);
    }
}
