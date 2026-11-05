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

        public static Fault NameEmpty()
        {
            return new("DoctorSpecialization.NameEmpty",
                [new("Название специализации не указано")]);
        }

        public static Fault IdEmpty()
        {
            return new("DoctorSpecialization.IdEmpty",
                [new("Id специализации не указан")]);
        }

        public static Fault NameTooShort(int minLength)
        {
            return new("DoctorSpecialization.NameTooShort",
                [new($"Название специализации должно содержать минимум {minLength} символа")]);
        }

        public static Fault NameTooLong(int maxLength)
        {
            return new("DoctorSpecialization.NameTooLong",
                [new($"Длина названия специализации не должна превышать {maxLength} символов")]);
        }
    }
}
