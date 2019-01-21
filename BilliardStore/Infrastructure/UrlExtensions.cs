//The infrastructure folder holds cs files that are not related to the application's domain
//called by ProductSummary.cshtml, Default.cshtml

namespace BilliardStore.Infrastructure
{
    //static class so no constructor...at the class level, no instance created
    //PathAndQuery method called by the ProductSummary.cshtml view file
    //if the QueryString is blank, a "/" is added to the end of the url
    public static class UrlExtensions
    {
        public static string PathAndQuery(this Microsoft.AspNetCore.Http.HttpRequest request)
        {
            return request.QueryString.HasValue ? $"{request.Path}{request.QueryString}" : request.Path.ToString();
        }
    }

}