using MisTest.Common;

namespace MisTest.Application.Faults
{
    public static class DoctorFaults
    {
        public static Fault InUseByDiagnoses()
        {
            return new Fault(
                "Doctor.InUse",
                [new("Невозможно удалить доктора, так как он выставил диагноз одному или нескольким пациентам!")]);
        }

        public static Fault NotExists(Guid id)
        {
            return new("Doctor.NotExists",
                [new($"Доктор ({id}) не существует!")]);
        }

        public static Fault IdEmpty()
        {
            return new("Doctor.IdEmpty",
                [new("Id доктора не указан")]);
        }

        public static Fault NameEmpty()
        {
            return new("Doctor.NameEmpty",
                [new("Имя доктора не указано")]);
        }

        public static Fault SurnameEmpty()
        {
            return new("Doctor.SurnameEmpty",
                [new("Фамилия доктора не указано")]);
        }

        public static Fault MiddleNameTooLong(int maxLength)
        {
            return new("Doctor.MiddleNameTooLong",
                [new($"Длина отчества не должна превышать {maxLength} символов")]);
        }

        public static Fault NameTooLong(int maxLength)
        {
            return new("Doctor.NameTooLong",
                [new($"Длина имени доктора не должна превышать {maxLength} символов")]);
        }

        public static Fault SurnameTooLong(int maxLength)
        {
            return new("Doctor.SurnameTooLong",
                [new($"Длина фамилии доктора не должна превышать {maxLength} символов")]);
        }
    }
}
