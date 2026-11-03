using MisTest.Application.Dtos.DoctorSpecialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace MisTest.Application.Dtos.Doctor
{
    public record DoctorResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? MiddleName { get; set; }
        public DoctorSpecializationResponseDto SpecializationDto { get; set; }
    }
}
