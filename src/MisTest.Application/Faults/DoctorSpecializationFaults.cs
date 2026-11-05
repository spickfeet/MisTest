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

        public static Fault InUseByDoctors()
        {
            return new Fault(
                "DoctorSpecialization.InUse",
                [new("Невозможно удалить специализацию, так как она назначена одному или нескольким докторам!")]);
        }
        public static Fault NotExists(Guid id)
        {
            return new("DoctorSpecialization.NotExists",
                [new($"Специализация ({id}) не существует!")]);
        }
    }
}
