namespace MisTest.Messages.Dtos.Diagnosis
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
