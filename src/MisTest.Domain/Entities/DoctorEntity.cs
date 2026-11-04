namespace MisTest.Domain.Entities
{
    public class DoctorEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? MiddleName { get; set; }
        public Guid SpecializationId { get; set; }
        public DoctorSpecializationEntity SpecializationEntity { get; set; }
        public List<DiagnosisEntity> DiagnosisEntities { get; set; }
    }
}
