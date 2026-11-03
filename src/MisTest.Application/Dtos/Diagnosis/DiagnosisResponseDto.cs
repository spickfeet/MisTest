using MisTest.Application.Dtos.Disease;
using MisTest.Application.Dtos.Doctor;
using MisTest.Application.Dtos.Patient;
using MisTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MisTest.Application.Dtos.Diagnosis
{
    public class DiagnosisResponseDto
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public string Therapy { get; set; }
        public DateTime Date { get; set; }
        public DoctorResponseDto DoctorDto { get; set; }
        public PatientResponseDto PatientDto { get; set; }
        public DiseaseResponseDto DiseaseDto { get; set; }
    }
}
