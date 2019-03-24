using SurveyManagement.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace SurveyManagement.DataAccess
{
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        public QuestionRepository(ApplicationDbContext context) : base(context)
        {

        }

        private void UpdateAnswersForQuestion(IEnumerable<AnswerVariant> asnwerVariants)
        {

        }


        public override void Update(Question entity)
        {
            base.Update(entity);
            var answerVariantsInDb = Context.AnswerVariants.Where(m => m.QuestionId == entity.Id).ToList();
            
            Context.AnswerVariants.RemoveRange(answerVariantsInDb);
            Context.AnswerVariants.AddRange(entity.AnswerVariants);

        }

        

        public ApplicationDbContext Context
        {
            get { return _context as ApplicationDbContext; }

        }

    }
}
