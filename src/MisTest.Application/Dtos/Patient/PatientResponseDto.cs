namespace MisTest.Application.Dtos.Patient
{
    public class PatientResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? MiddleName { get; set; }
        public string CardNumber { get; set; }
    }
}
