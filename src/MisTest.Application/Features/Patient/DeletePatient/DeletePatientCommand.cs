using MediatR;
using MisTest.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MisTest.Application.Features.Patient.DeletePatient
{
    public record DeletePatientCommand(Guid Id) : IRequest<Result>;
}
