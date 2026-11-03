using MisTest.Application.Dtos.Disease;
using MisTest.Application.Dtos.Doctor;
using MisTest.Application.Dtos.Patient;
using System;
using System.Collections.Generic;
using System.Text;

namespace MisTest.Application.Dtos.Diagnosis
{
    public class DiagnosisRequestDto
    {
        public string Comment { get; set; }
        public string Therapy { get; set; }
        public DateTime Date { get; set; }
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public Guid DiseaseId { get; set; }
    }
}
