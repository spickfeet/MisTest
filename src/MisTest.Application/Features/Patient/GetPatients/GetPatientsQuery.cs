using MediatR;
using MisTest.Application.Dtos.Doctor;
using MisTest.Application.Dtos.Patient;
using MisTest.Common;
using MisTest.Common.Filters;
using MisTest.Common.Page;
using System;
using System.Collections.Generic;
using System.Text;

namespace MisTest.Application.Features.Patient.GetPatients
{
    public record  GetPatientsQuery(PageParams PageParams) : IRequest<Result<PagedResult<PatientResponseDto>>>;
}
