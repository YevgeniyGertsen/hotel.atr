using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Hotel.Atr.Models
{
    public class TimeElapsed : Attribute, IActionFilter
    {
        private Stopwatch timer;
        public void OnActionExecuted(ActionExecutedContext context)
        {
            timer.Stop();
            string result = "Elapsed time:" +
                " " + $"{timer.Elapsed.TotalMilliseconds} ms";

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            timer = Stopwatch.StartNew();
        }
    }
}
