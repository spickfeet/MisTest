using AutoMapper;
using MisTest.Messages.Dtos.DoctorSpecialization;
using MisTest.Common.Page;
using MisTest.Domain.Entities;

namespace MisTest.Application.MappingProfiles
{
    public class DoctorSpecializationMappingProfile : Profile
    {
        public DoctorSpecializationMappingProfile()
        {
            CreateMap<DoctorSpecializationEntity, DoctorSpecializationResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<DoctorSpecializationRequestDto, DoctorSpecializationEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<PagedResult<DoctorSpecializationEntity>, PagedResult<DoctorSpecializationResponseDto>>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data))
                .ForMember(dest => dest.PageSize, opt => opt.MapFrom(src => src.PageSize))
                .ForMember(dest => dest.PageNumber, opt => opt.MapFrom(src => src.PageNumber))
                .ForMember(dest => dest.TotalCount, opt => opt.MapFrom(src => src.TotalCount));
        }
    }
}
