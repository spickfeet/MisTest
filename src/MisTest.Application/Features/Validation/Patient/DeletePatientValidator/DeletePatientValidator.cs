using MisTest.Application.Faults;
using MisTest.Common;
using MisTest.Common.Filters;
using MisTest.Domain;
using MisTest.Messages.Features.Patient;
using System;
using System.Collections.Generic;
using System.Text;

namespace MisTest.Application.Features.Validation.Patient.DeletePatientValidator
{
    public class DeletePatientValidator : IDeletePatientValidator
    {
        private IUnitOfWork _unitOfWork;
        private const string BaseFaultMessage = "DeletePatient.Error";
        public DeletePatientValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Validate(DeletePatientCommand request)
        {
            Fault fault = new(BaseFaultMessage);

            if (request.Id == Guid.Empty)
            {
                fault.Details.Add(PatientFaults.IdEmpty());
            }

            return fault.Details.Count > 0 ? Result.Failure(fault) : Result.Success();
        }
    }
}
