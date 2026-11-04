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
    }
}
