namespace MisTest.Host.Api.Const
{
    public static class ServiceRoutes
    {
        private const string Api = "/api";
        public static class  DoctorSpecializations
        {
            public const string Base = Api + "/doctor-specializations";
            public const string ById = Base + "/{id}";
        }

        public static class Diseases
        {
            public const string Base = Api + "/diseases";
            public const string ById = Base + "/{id}";
        }

        public static class Doctors
        {
            public const string Base = Api + "/doctors";
            public const string ById = Base + "/{id}";
        }

        public static class Patients
        {
            public const string Base = Api + "/patients";
            public const string ById = Base + "/{id}";
            public const string ByCardNumber = Base + "/{cardNumber}";
        }
    }
}
