using AutoMapper;
using MyProject.Core.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Application.UserService.Dto
{
    public class UserServiceProfile : Profile
    {

        public UserServiceProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<UserDto, User>();
            CreateMap<GetScoreOutDto, User>();
            CreateMap<GetScoreOutDto, ReportCard>();
            CreateMap<GetScoreOutDto, (User, ReportCard)>();
            CreateMap<(User user, ReportCard reportCard), GetScoreOutDto>()
                .ForMember(dto => dto.Age, entity => entity.MapFrom(s => s.user.Age))
                .ForMember(dto => dto.Course, entity => entity.MapFrom(f => f.reportCard.Course))
                .ForMember(dto => dto.Id, entity => entity.MapFrom(f => f.reportCard.Id))
                .ForMember(dto => dto.Name, entity => entity.MapFrom(f => f.user.Name))
                .ForMember(dto => dto.Score, entity => entity.MapFrom(f => f.reportCard.Score))
                .ForMember(dto => dto.UserId, entity => entity.MapFrom(f => f.user.Id));
        }
    }
}
