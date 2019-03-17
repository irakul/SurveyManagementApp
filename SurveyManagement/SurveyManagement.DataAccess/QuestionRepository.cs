using SurveyManagement.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyManagement.DataAccess
{
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        public QuestionRepository(ApplicationDbContext context) : base(context)
        {

        }



        public ApplicationDbContext Context
        {
            get { return _context as ApplicationDbContext; }
            
        }

    }
}
