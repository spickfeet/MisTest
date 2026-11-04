using MisTest.Common;

namespace MisTest.Application.Faults
{
    public static class DoctorSpecializationFaults
    {
        public static Fault AlreadyExists(string name)
        {
            return new("DoctorSpecialization.AlreadyExists", 
                [new($"Специализация ({name}) уже существует!")]);
        }
    }
}
