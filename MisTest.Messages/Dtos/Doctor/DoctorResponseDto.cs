using MisTest.Messages.Dtos.DoctorSpecialization;

namespace MisTest.Messages.Dtos.Doctor
{
    public record DoctorResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? MiddleName { get; set; }
        public DoctorSpecializationResponseDto SpecializationDto { get; set; }
    }
}
