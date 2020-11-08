using Prometheus;
using System;

namespace Phonebook.Metrics.Models
{
    public class MetricTimer : IDisposable
    {
        private readonly ITimer _timer;
        public MetricTimer(ITimer timer)
        {
            _timer = timer;
        }
        public void Dispose()
        {
            _timer.Dispose();
        }
    }
}
