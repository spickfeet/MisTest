using MediatR;
using MisTest.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MisTest.Application.Features.Diseases.DeleteDisease
{
    public record DeleteDiseaseCommand(Guid Id) : IRequest<Result>;
}
