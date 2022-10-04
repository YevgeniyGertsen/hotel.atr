using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.RegularExpressions;

namespace Hotel.Atr.Models
{
    public class IEFilterAttribute : Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            //throw new NotImplementedException();
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            //получаем информацию о бразуере пользователя
            string userAgent = context.HttpContext.Request
                .Headers["User-Agent"].ToString();

            if(Regex.IsMatch(userAgent, "MSIE|Trident"))
            {
                context.Result = new ContentResult() 
                { 
                    Content = "Ваш браузер устарел"
                };
            }
        }
    }
}
