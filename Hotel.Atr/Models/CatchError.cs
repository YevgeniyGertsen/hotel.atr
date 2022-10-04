using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Hotel.Atr.Models
{
    public class CatchError : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new ViewResult()
            {
                ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), 
                new ModelStateDictionary())
                {
                    Model = context.Exception.Message
                }
            };
        }
    }
}
