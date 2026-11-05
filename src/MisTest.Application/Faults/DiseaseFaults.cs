using MisTest.Common;

namespace MisTest.Application.Faults
{
    public static class DiseaseFaults
    {
        public static Fault AlreadyExists(string name)
        {
            return new("Disease.AlreadyExists",
                [new($"Болезнь ({name}) уже существует!")]);
        }

        public static Fault InUseByDiagnoses()
        {
            return new Fault(
                "Disease.InUse",
                [new("Невозможно удалить болезнь, так как она присутствует в одном или нескольких диагнозах!")]);
        }
    }
}
