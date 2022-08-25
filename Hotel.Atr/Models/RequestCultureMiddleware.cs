using System.Globalization;

namespace Hotel.Atr.Models
{
    public class RequestCultureMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestCultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var cultureQuery = context.Request.Query["culture"];

            if(!string.IsNullOrWhiteSpace(cultureQuery))
            {
                var culture = new CultureInfo(cultureQuery);

                CultureInfo.CurrentCulture = culture;
                CultureInfo.CurrentUICulture = culture;

               // await _next(context);
            }
            //else
            //{
            //    context.Response.WriteAsJsonAsync("Some Message");
            //}

            await _next(context);
        }
    }

    public static class RequestCultureMiddlewareExctensions
    {
        public static IApplicationBuilder 
            UserReqestCulture(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestCultureMiddleware>();
        }
    }
}
