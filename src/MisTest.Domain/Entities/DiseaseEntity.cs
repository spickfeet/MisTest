namespace MisTest.Domain.Entities
{
    public class DiseaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<DiagnosisEntity> DiagnosisEntities { get; set; }
    }
}
