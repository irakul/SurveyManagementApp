using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SurveyManagement.DataAccess.Entities;

namespace SurveyManagement
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Survey, SurveyDto>();
            CreateMap<Question, QuestionDto>();

            CreateMap<Survey, SurveyDto>().ReverseMap();
            CreateMap<Question, QuestionDto>().ReverseMap();

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
