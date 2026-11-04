using MisTest.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MisTest.Application.Faults
{
    public static class PatientFaults
    {
        public static Fault AlreadyExists(string cardNumber)
        {
            return new Fault(
                "Patient.AlreadyExists",
                [new($"Пациент с номером карты ({cardNumber}) уже существует!")]);
        }

        public static Fault NotExists(string cardNumber)
        {
            return new Fault(
                "Patient.NotExists",
                [new($"Пациент с номером карты ({cardNumber}) не существует!")]);
        }
    }
}
