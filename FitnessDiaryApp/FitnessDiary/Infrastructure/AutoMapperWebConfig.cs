using System;
using AutoMapper;
using FitnessDiary.Models;
using FitnessDiary.BusinessLogic.Dtos;

namespace FitnessDiary.Infrastructure
{
    public class AutoMapperWebConfig : Profile
    {
        public static readonly Action<IMapperConfigurationExpression> ConfigAction = cfg =>
        {
            cfg.CreateMap<UserDto, UserViewModel>().ReverseMap();
        };
    }
}
