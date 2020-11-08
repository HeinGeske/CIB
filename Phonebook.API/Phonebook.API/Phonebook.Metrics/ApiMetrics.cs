using Phonebook.Metrics.Models;

namespace Phonebook.Metrics
{
    public class ApiMetrics
    {
        private const string ServiceName = "Absa";
        private const string ServiceType = "Api";
        public static readonly Counter ApiCallCounter = new Counter($"{ServiceName}_{ServiceType}_TotalCount", "Number of requests processed");
        public static readonly Counter ApiCallExceptionCounter = new Counter($"{ServiceName}_{ServiceType}_RequestExceptions", "Number of requests exceptions");
        public static readonly Gauge ApiCallGauge = new Gauge($"{ServiceName}_{ServiceType}_TotalActiveRequests", "Number of active requests");
    }
}
