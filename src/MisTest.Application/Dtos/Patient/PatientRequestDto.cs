using System;
using System.Collections.Generic;
using System.Text;

namespace MisTest.Application.Dtos.Patient
{
    public class PatientRequestDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? MiddleName { get; set; }
        public string CardNumber { get; set; }
    }
}
