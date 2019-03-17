using SurveyManagement.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyManagement.DataAccess
{
    public class SurveyRepository : Repository<Survey>, ISurveyRepository
    {
        public SurveyRepository(ApplicationDbContext context) : base(context)
        {

        }



        public ApplicationDbContext Context
        {
            get { return _context as ApplicationDbContext; }

        }
    }
}
