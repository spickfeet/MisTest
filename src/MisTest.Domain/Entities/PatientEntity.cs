namespace MisTest.Domain.Entities
{
    public class PatientEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? MiddleName { get; set; }
        public string CardNumber { get; set; }
        public List<DiagnosisEntity> DiagnosisEntities { get; set; }
    }
}
