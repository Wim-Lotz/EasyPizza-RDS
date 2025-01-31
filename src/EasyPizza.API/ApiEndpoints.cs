namespace EasyPizza.API;

public static class ApiEndpoints
{
    private const string ApiBase = "api";

    public static class V1
    {
        private const string VersionBase = $"{ApiBase}/v1";
        
        public static class Ingredients
        {
            private const string Base = $"{VersionBase}/ingredients";

            public const string Create = Base;
            public const string Get = $"{Base}/{{id:guid}}";
            public const string GetAll = Base;
            public const string Update = $"{Base}/{{id:guid}}";
            public const string Delete = $"{Base}/{{id:guid}}";
        }

        public static class PizzaBases
        {
            private const string Base = $"{VersionBase}/pizza-bases";

            public const string Create = Base;
            public const string Get = $"{Base}/{{id:guid}}";
            public const string GetAll = Base;
            public const string Update = $"{Base}/{{id:guid}}";
            public const string Delete = $"{Base}/{{id:guid}}";
        }
    
        public static class Orders
        {
            private const string Base = $"{VersionBase}/orders";

            public const string Create = Base;
            public const string Get = $"{Base}/{{id:guid}}";
            public const string GetAll = Base;
        }
    }
    
    public static class V2
    {
        private const string VersionBase = $"{ApiBase}/v2";

        public static class PizzaBases
        {
            private const string Base = $"{VersionBase}/pizza-bases";
            
            public const string GetAll = Base;
        }
    
    }
   
}