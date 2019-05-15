using System;
using AutoMapper;
using FitnessDiary.BusinessLogic.Dtos;
using FitnessDiary.DataAccess.Entities;

namespace FitnessDiary.BusinessLogic.Infrastructure
{
    public static class AutoMapperBllConfig
    {
        public static readonly Action<IMapperConfigurationExpression> ConfigAction = cfg =>
        {
            cfg.CreateMap<UserDto, User>().ReverseMap();
        };
    }
}
