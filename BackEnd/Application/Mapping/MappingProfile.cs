﻿using AutoMapper;
using Domain.Entities;
using Application.DTOs;
namespace Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, PersonDTO>().ReverseMap();
            // Add more mappings here
        }
    }
}
