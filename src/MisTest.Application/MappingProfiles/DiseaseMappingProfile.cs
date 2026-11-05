using AutoMapper;
using MisTest.Messages.Dtos.Disease;
using MisTest.Common.Page;
using MisTest.Domain.Entities;

namespace MisTest.Application.MappingProfiles
{
    public class DiseaseMappingProfile : Profile
    {
        public DiseaseMappingProfile()
        {
            CreateMap<DiseaseEntity, DiseaseResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<DiseaseRequestDto, DiseaseEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<PagedResult<DiseaseEntity>, PagedResult<DiseaseResponseDto>>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data))
                .ForMember(dest => dest.PageSize, opt => opt.MapFrom(src => src.PageSize))
                .ForMember(dest => dest.PageNumber, opt => opt.MapFrom(src => src.PageNumber))
                .ForMember(dest => dest.TotalCount, opt => opt.MapFrom(src => src.TotalCount));
        }
    }
}
