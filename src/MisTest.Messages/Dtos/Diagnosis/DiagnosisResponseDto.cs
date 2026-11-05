using MisTest.Messages.Dtos.Disease;
using MisTest.Messages.Dtos.Doctor;
using MisTest.Messages.Dtos.Patient;

namespace MisTest.Messages.Dtos.Diagnosis
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
