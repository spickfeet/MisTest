using MediatR;
using Microsoft.Extensions.Logging;
using MisTest.Application.Features.DoctorSpecialization.DeleteSpecialization;
using MisTest.Common;
using MisTest.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MisTest.Application.Features.Diseases.DeleteDisease
{
    public class DeleteDiseaseHandler : IRequestHandler<DeleteDiseaseCommand, Result>
    {
        private IUnitOfWork _unitOfWork;
        private ILogger<DeleteDiseaseHandler> _logger;
        public DeleteDiseaseHandler(IUnitOfWork unitOfWork, ILogger<DeleteDiseaseHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Result> Handle(DeleteDiseaseCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.DiseaseRepository.DeleteDiseaseAsync(request.Id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
    }
}
