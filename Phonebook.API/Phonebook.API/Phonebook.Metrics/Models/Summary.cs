using Pro = Prometheus;

namespace Phonebook.Metrics.Models
{
    public class Summary
    {
        private readonly Pro.Summary _summary;
        public Summary(string name, string help)
        {
            _summary = Pro.Metrics.CreateSummary(name, help);
        }
        public void Observer(double val)
        {
            _summary.Observe(val);
        }
        public void Publish()
        {
            _summary.Publish();
        }
    }
}
