using MediatR;
using MisTest.Application.Dtos.Patient;
using MisTest.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MisTest.Application.Features.Patient.GetPatientById
{
    public record GetPatientByCardNumberQuery(string CardNumber) : IRequest<Result<PatientResponseDto>>;
}
