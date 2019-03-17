using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyManagement.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        IQuestionRepository Questions { get; }
        ISurveyRepository Surveys { get; }
        int Save();

    }
}
