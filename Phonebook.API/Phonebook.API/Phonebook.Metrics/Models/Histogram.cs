using Phonebook.Metrics.Models.Configuration;
using Pro = Prometheus;

namespace Phonebook.Metrics.Models
{
    public class Histogram
    {
        private readonly Pro.Histogram _histogram;
        public Histogram(string name, string help, HistogramConfiguration histogramConfiguration = null)
        {
            _histogram = Pro.Metrics.CreateHistogram(name, help, histogramConfiguration?.Configuration);
        }
        public void Observe(double value)
        {
            _histogram.Observe(value);
        }
        public void Publish()
        {
            _histogram.Publish();
        }
        public MetricTimer NewTimer()
        {
            return new MetricTimer(Pro.TimerExtensions.NewTimer(_histogram));
        }
    }
}
