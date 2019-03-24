using SurveyManagement.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyManagement.DataAccess
{
    public class AnswerVariantRepository : Repository<AnswerVariant>, IAnswerRepository
    {
        public AnswerVariantRepository(ApplicationDbContext context) : base(context)
        {

        }
               
        public void UpdateAnswersForQuestion(IEnumerable<AnswerVariant> answersVariants)
        {

        }

        public ApplicationDbContext Context
        {
            get { return _context as ApplicationDbContext; }

        }
    }
}
