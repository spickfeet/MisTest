using AutoMapper;
using MisTest.Application.Dtos.Diagnosis;
using MisTest.Application.Dtos.Disease;
using MisTest.Application.Dtos.Doctor;
using MisTest.Common.Page;
using MisTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MisTest.Application.MappingProfiles
{
    public class DoctorMappingProfile : Profile
    {
        public DoctorMappingProfile()
        {
            CreateMap<DoctorEntity, DoctorResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
                .ForMember(dest => dest.MiddleName, opt => opt.MapFrom(src => src.MiddleName))
                .ForMember(dest => dest.SpecializationDto, opt => opt.MapFrom(src => src.SpecializationEntity));

            CreateMap<DoctorRequestDto, DoctorEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
                .ForMember(dest => dest.MiddleName, opt => opt.MapFrom(src => src.MiddleName))
                .ForMember(dest => dest.SpecializationId, opt => opt.MapFrom(src => src.SpecializationId));

            CreateMap<PagedResult<DoctorEntity>, PagedResult<DoctorResponseDto>>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data))
                .ForMember(dest => dest.PageSize, opt => opt.MapFrom(src => src.PageSize))
                .ForMember(dest => dest.PageNumber, opt => opt.MapFrom(src => src.PageNumber))
                .ForMember(dest => dest.TotalCount, opt => opt.MapFrom(src => src.TotalCount));
        }
    }
}
