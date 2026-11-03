using System;
using System.Collections.Generic;
using System.Text;

namespace MisTest.Domain.Entities
{
    public class DiagnosisEntity
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public string Therapy { get; set; }
        public DateTime Date { get; set; }
        public Guid DoctorId { get; set; }
        public DoctorEntity DoctorEntity { get; set; }
        public Guid PatientId { get; set; }
        public PatientEntity PatientEntity { get; set; }
        public Guid DiseaseId { get; set; }
        public DiseaseEntity DiseaseEntity { get; set; }
    }
}
