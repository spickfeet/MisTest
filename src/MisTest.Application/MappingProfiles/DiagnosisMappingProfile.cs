using AutoMapper;
using MisTest.Application.Dtos.Diagnosis;
using MisTest.Common.Page;
using MisTest.Domain.Entities;

namespace MisTest.Application.MappingProfiles
{
    public class DiagnosisMappingProfile : Profile
    {
        public DiagnosisMappingProfile()
        {
            CreateMap<DiagnosisEntity, DiagnosisResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment))
                .ForMember(dest => dest.Therapy, opt => opt.MapFrom(src => src.Therapy))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.PatientDto, opt => opt.MapFrom(src => src.PatientEntity))
                .ForMember(dest => dest.DiseaseDto, opt => opt.MapFrom(src => src.DiseaseEntity))
                .ForMember(dest => dest.DoctorDto, opt => opt.MapFrom(src => src.DoctorEntity));

            CreateMap<DiagnosisRequestDto, DiagnosisEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment))
                .ForMember(dest => dest.Therapy, opt => opt.MapFrom(src => src.Therapy))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.PatientId, opt => opt.MapFrom(src => src.PatientId))
                .ForMember(dest => dest.DiseaseId, opt => opt.MapFrom(src => src.DiseaseId))
                .ForMember(dest => dest.DoctorId, opt => opt.MapFrom(src => src.DoctorId));

            CreateMap<PagedResult<DiagnosisEntity>, PagedResult<DiagnosisResponseDto>>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data))
                .ForMember(dest => dest.PageSize, opt => opt.MapFrom(src => src.PageSize))
                .ForMember(dest => dest.PageNumber, opt => opt.MapFrom(src => src.PageNumber))
                .ForMember(dest => dest.TotalCount, opt => opt.MapFrom(src => src.TotalCount));
        }
    }
}
