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
    }
}
