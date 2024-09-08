namespace Promos.API;

public static class ApiEndpoints
{
    private const string apiBase = "/api";

    public static class Promotions
    {
        private const string promotionsBase = $"{apiBase}/promotions";

        public const string Create = promotionsBase;
        public const string Get = $"{promotionsBase}/{{id:guid}}";
        public const string GetAll = promotionsBase;
        public const string Update = $"{promotionsBase}/{{id:guid}}";
        public const string Delete = $"{promotionsBase}/{{id:guid}}";
    }
}