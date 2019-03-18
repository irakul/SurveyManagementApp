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
            var _survey = _unitOfWork.Surveys.Get(id);
            if (_survey != null)
            {
                _unitOfWork.Surveys.Remove(_survey);
            }
            
        }

        public IEnumerable<SurveyDto> GetAllSurveys()
        {
            var surveys = _unitOfWork.Surveys.GetAll();
            var surveyDtos = new List<SurveyDto>();

            foreach (var s in surveys)
            {
                var surveyDto = _mapper.Map<Survey, SurveyDto>(s);
                surveyDtos.Add(surveyDto);
            }

            return surveyDtos;
        }

        public SurveyDto GetSurvey(int id)
        {
            var survey = _unitOfWork.Surveys.Get(id);
            var surveyDto = _mapper.Map<Survey, SurveyDto>(survey);

            return surveyDto;
        }

        public void UpdateSurvey(int id, SurveyDto surveyDto)
        {
            var surveyUpdated = _mapper.Map<SurveyDto, Survey>(surveyDto);
            var surveyInUnitOfWork = _unitOfWork.Surveys.Get(id);

            if (id == surveyDto.Id)
            {
                surveyInUnitOfWork.Name = surveyUpdated.Name;
                surveyInUnitOfWork.Creator = surveyUpdated.Creator;
                surveyInUnitOfWork.CreatedOn = surveyUpdated.CreatedOn;
                _unitOfWork.Save();
            }

            

        }
    }
}
