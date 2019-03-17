using SurveyManagement.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using SurveyManagement.DataAccess.Entities;

namespace SurveyManagement.BusinessLogic.Services
{
    public class SurveyService : ISurveyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SurveyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void CreateSurvey(SurveyDto survey)
        {
            var _survey = _mapper.Map<SurveyDto, Survey>(survey);

            _unitOfWork.Surveys.Add(_survey);
        }

        public void DeleteSurvey(int id)
        {
            //
        }

        public IEnumerable<SurveyDto> GetAllSurveys()
        {
            throw new NotImplementedException();
        }

        public SurveyDto GetSurvey(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateSurvey(int id, SurveyDto survey)
        {
            throw new NotImplementedException();
        }
    }
}
