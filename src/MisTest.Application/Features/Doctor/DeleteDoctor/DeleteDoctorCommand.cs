using MediatR;
using MisTest.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MisTest.Application.Features.Doctor.DeleteDoctor
{
    public record DeleteDoctorCommand(Guid Id) : IRequest<Result>;
}
