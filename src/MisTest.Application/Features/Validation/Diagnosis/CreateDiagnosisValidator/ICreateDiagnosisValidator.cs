using MisTest.Common;
using MisTest.Messages.Features.Diagnosis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MisTest.Application.Features.Validation.Diagnosis.CreateDiagnosisValidator
{
    public interface ICreateDiagnosisValidator
    {
        public Task<Result> Validate(CreateDiagnosisCommand request);
    }
}
