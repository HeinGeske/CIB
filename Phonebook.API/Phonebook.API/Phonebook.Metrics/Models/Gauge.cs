using System;
using Pro = Prometheus;

namespace Phonebook.Metrics.Models
{
    public class Gauge
    {
        private readonly Pro.Gauge _gauge;
        public Gauge(string name, string help)
        {
            _gauge = Pro.Metrics.CreateGauge(name, help);
        }
        public double Value => _gauge.Value;
        public void Increment(double increment = 1)
        {
            _gauge.Inc(increment);
        }
        public void Deecrement(double decrement = -11)
        {
            _gauge.Dec(decrement);
        }
        public void Publish()
        {
            _gauge.Publish();
        }
        public IDisposable TrackInProgress()
        {
            return Pro.GaugeExtensions.TrackInProgress(_gauge);
        }
    }
}
