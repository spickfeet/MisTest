using MisTest.Common;

namespace MisTest.Application.Faults
{
    public static class PatientFaults
    {
        public static Fault AlreadyExists(string cardNumber)
        {
            return new("Patient.AlreadyExists",
                [new($"Пациент с номером карты ({cardNumber}) уже существует!")]);
        }

        public static Fault NotExists(string cardNumber)
        {
            return new("Patient.NotExists",
                [new($"Пациент с номером карты ({cardNumber}) не существует!")]);
        }

        public static Fault NotExists(Guid id)
        {
            return new("Patient.NotExists",
                [new($"Пациент ({id}) не существует!")]);
        }

        public static Fault CardNumberEmpty()
        {
            return new("Patient.CardNumberEmpty",
                [new("Номер карты не указан")]);
        }

        public static Fault CardNumberInvalidFormat()
        {
            return new("Patient.CardNumberInvalidFormat",
                [new("Номер карты должен содержать только цифры")]);
        }

        public static Fault CardNumberTooShort(int minLength)
        {
            return new("Patient.CardNumberTooShort",
                [new($"Номер карты должен содержать минимум {minLength} цифр")]);
        }

        public static Fault CardNumberTooLong(int maxLength)
        {
            return new("Patient.CardNumberTooLong",
                [new($"Номер карты не должен превышать {maxLength} цифр")]);
        }

        public static Fault NameEmpty()
        {
            return new("Patient.NameEmpty",
                [new("Имя пациента не указано")]);
        }

        public static Fault SurnameEmpty()
        {
            return new("Patient.SurnameEmpty",
                [new("Фамилия пациента не указана")]);
        }

        public static Fault NameTooLong(int maxLength)
        {
            return new("Patient.NameTooLong",
                [new($"Длина имени пациента не должна превышать {maxLength} символов")]);
        }

        public static Fault SurnameTooLong(int maxLength)
        {
            return new("Patient.SurnameTooLong",
                [new($"Длина фамилии пациента не должна превышать {maxLength} символов")]);
        }

        public static Fault MiddleNameTooLong(int maxLength)
        {
            return new("Patient.MiddleNameTooLong",
                [new($"Длина отчества не должна превышать {maxLength} символов")]);
        }

        public static Fault IdEmpty()
        {
            return new("Patient.IdEmpty",
                [new("Id пациента не указан")]);
        }
    }
}
