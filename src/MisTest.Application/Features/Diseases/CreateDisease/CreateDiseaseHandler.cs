using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MisTest.Application.Faults;
using MisTest.Common;
using MisTest.Domain;
using MisTest.Domain.Entities;

namespace MisTest.Application.Features.Diseases.CreateDisease
{
    public class CreateDiseaseHandler : IRequestHandler<CreateDiseaseCommand, Result>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private ILogger<CreateDiseaseHandler> _logger;
        public CreateDiseaseHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateDiseaseHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result> Handle(CreateDiseaseCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.DiseaseRepository.GetDisease(request.DiseaseRequestDto.Name) != null)
            {
                return Result.Failure(DiseaseFaults.AlreadyExists(request.DiseaseRequestDto.Name));
            }
            await _unitOfWork.DiseaseRepository.CreateDiseaseAsync(_mapper.Map<DiseaseEntity>(request.DiseaseRequestDto));
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
    }
}
