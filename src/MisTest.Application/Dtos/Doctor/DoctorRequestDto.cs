using MisTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MisTest.Application.Dtos.Doctor
{
    public class DoctorRequestDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? MiddleName { get; set; }
        public Guid SpecializationId { get; set; }
    }
}
