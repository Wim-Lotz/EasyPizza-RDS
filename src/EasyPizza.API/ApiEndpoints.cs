﻿namespace EasyPizza.API;

public static class ApiEndpoints
{
    private const string ApiBase = "api";

    public static class Ingredients
    {
        private const string Base = $"{ApiBase}/ingredients";

        public const string Create = Base;
        public const string Get = $"{Base}/{{id:guid}}";
        public const string GetAll = Base;
        public const string Update = $"{Base}/{{id:guid}}";
        public const string Delete = $"{Base}/{{id:guid}}";
    }

    public static class PizzaBases
    {
        private const string Base = $"{ApiBase}/pizza-bases";

        public const string Create = Base;
        public const string Get = $"{Base}/{{id:guid}}";
        public const string GetAll = Base;
        public const string Update = $"{Base}/{{id:guid}}";
        public const string Delete = $"{Base}/{{id:guid}}";
    }
    
    public static class Orders
    {
        private const string Base = $"{ApiBase}/orders";

        public const string Create = Base;
        public const string Get = $"{Base}/{{id:guid}}";
        public const string GetAll = Base;
    }
}