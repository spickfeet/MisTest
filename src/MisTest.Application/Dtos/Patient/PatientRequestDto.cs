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
