using MediatR;
using Microsoft.Extensions.Logging;
using MisTest.Application.Features.DoctorSpecializations.DeleteSpecialization;
using MisTest.Common;
using MisTest.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MisTest.Application.Features.Doctor.DeleteDoctor
{
    public class DeleteDoctorHandler : IRequestHandler<DeleteDoctorCommand, Result>
    {
        private IUnitOfWork _unitOfWork;
        private ILogger<DeleteDoctorHandler> _logger;
        public DeleteDoctorHandler(IUnitOfWork unitOfWork, ILogger<DeleteDoctorHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Result> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.DoctorRepository.DeleteDoctorAsync(request.Id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
    }
}
