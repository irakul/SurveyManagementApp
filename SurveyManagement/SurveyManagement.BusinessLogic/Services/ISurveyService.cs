using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyManagement.BusinessLogic.Services
{
    public interface ISurveyService
    {
        SurveyDto GetSurvey(int id);
        IEnumerable<SurveyDto> GetAllSurveys();
        void CreateSurvey(SurveyDto survey);
        void DeleteSurvey(int id);
        void UpdateSurvey(int id, SurveyDto survey);
    }
}
