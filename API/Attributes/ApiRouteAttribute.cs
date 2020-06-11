namespace API.Attributes
{
    using Microsoft.AspNetCore.Mvc;

    public class ApiRouteAttribute : RouteAttribute
    {
        public ApiRouteAttribute(string template)
            : base(CombinePath("api", template))
        {
        }

        private static string CombinePath(string path1, string path2)
        {
            return path1.TrimEnd('/') + '/' + path2.TrimStart('/');
        }
    }
}
