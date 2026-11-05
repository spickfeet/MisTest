using MisTest.Common;

namespace MisTest.Application.Faults
{
    public class DoctorFaults
    {
        public static Fault InUseByDiagnoses()
        {
            return new Fault(
                "Doctor.InUse",
                [new("Невозможно удалить доктора, так как он выставил диагноз одному или нескольким пациентам!")]);
        }
    }
}
