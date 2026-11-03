using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MisTest.Application.Dtos.Disease;
using MisTest.Application.Dtos.DoctorSpecialization;
using MisTest.Application.Features.DoctorSpecializations.GetSpecializations;
using MisTest.Common;
using MisTest.Common.Page;
using MisTest.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MisTest.Application.Features.Diseases.GetDiseases
{
    public class GetDiseaseHandler : IRequestHandler<GetDiseaseQuery, Result<PagedResult<DiseaseResponseDto>>>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private ILogger<GetDiseaseHandler> _logger;
        public GetDiseaseHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GetDiseaseHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Result<PagedResult<DiseaseResponseDto>>> Handle(GetDiseaseQuery request, CancellationToken cancellationToken)
        {
            return Result<PagedResult<DiseaseResponseDto>>.Success(
                _mapper.Map<PagedResult<DiseaseResponseDto>>(
                    await _unitOfWork.DiseaseRepository.GetDiseasesPageAsync(request.PageParams)));
        }
    }
}
