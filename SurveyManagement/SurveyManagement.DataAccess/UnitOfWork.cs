﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyManagement.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        
        public UnitOfWork(ApplicationDbContext context, ISurveyRepository surveyRepository, IQuestionRepository questionRepository)
        {
            _context = context;
            Questions = questionRepository;
            Surveys = surveyRepository;
        }

        public IQuestionRepository Questions { get; private set; }
        public ISurveyRepository Surveys { get; private set; }
        
        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
