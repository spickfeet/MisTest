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

        public static class Disease
        {
            public const string Base = Api + "/disease";
            public const string ById = Base + "/{id}";
        }

        public static class Doctor
        {
            public const string Base = Api + "/doctor";
            public const string ById = Base + "/{id}";
        }
    }
}
