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

        public static Fault IdEmpty()
        {
            return new("Disease.IdEmpty",
                [new("Id болезни не указан")]);
        }

        public static Fault NotExists(Guid id)
        {
            return new("Disease.NotExists",
                [new($"Болезнь ({id}) не существует!")]);
        }

        public static Fault NameEmpty()
        {
            return new("Disease.NameEmpty",
                [new("Название болезни не указано")]);
        }

        public static Fault NameTooShort(int minLength)
        {
            return new("Disease.NameTooShort",
                [new($"Название болезни должно содержать минимум {minLength} символа")]);
        }

        public static Fault NameTooLong(int maxLength)
        {
            return new("Disease.NameTooLong",
                [new($"Название болезни не должно превышать {maxLength} символов")]);
        }
    }
}
