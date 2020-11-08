using Microsoft.AspNetCore.Mvc.Filters;
using Phonebook.Metrics;

namespace Phonebook.Attributes
{
    public class RecordMetricsAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ApiMetrics.ApiCallCounter.Increment();
            using (ApiMetrics.ApiCallGauge.TrackInProgress())
            {
                ApiMetrics.ApiCallExceptionCounter.CountExceptions(() =>
                {
                    base.OnActionExecuting(context);
                    return 0;
                });
            }
        }
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            base.OnResultExecuted(context);
            ApiMetrics.ApiCallExceptionCounter.Increment();
        }
    }
}
