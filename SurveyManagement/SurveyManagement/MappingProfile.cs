using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SurveyManagement.DataAccess.Entities;
using SurveyManagement.ViewModels;

namespace SurveyManagement
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Question, QuestionDto>();
            CreateMap<Question, QuestionDto>().ReverseMap();

            CreateMap<Survey, SurveyDto>();
            CreateMap<Survey, SurveyDto>().ReverseMap();

            CreateMap<SurveyDto, SurveyViewModel>();
            CreateMap<SurveyDto, SurveyViewModel>().ReverseMap();

            CreateMap<QuestionDto, QuestionViewModel>();
            CreateMap<QuestionDto, QuestionViewModel>().ReverseMap();


            CreateMap<Survey, SurveyDto>().BeforeMap((x,y) =>
            {
                y.Id = x.Id;
                y.Name = x.Name;
                y.CreatedOn = x.CreatedOn;
                y.Creator = x.Creator;
            });
            


        }
    }
}
