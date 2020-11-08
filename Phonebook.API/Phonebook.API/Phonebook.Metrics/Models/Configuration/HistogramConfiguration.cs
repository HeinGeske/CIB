using Pro = Prometheus;

namespace Phonebook.Metrics.Models.Configuration
{
    public class HistogramConfiguration
    {
        internal Pro.HistogramConfiguration Configuration { get; set; }
        public double[] Buckets
        {
            get => Configuration.Buckets;
            set => Configuration.Buckets = value;
        }
        private string[] LabelNames
        {
            get => Configuration.LabelNames;
            set => Configuration.LabelNames = value;
        }
        private bool SuppressInitialValue
        {
            get => Configuration.SuppressInitialValue;
            set => Configuration.SuppressInitialValue = value;
        }
        public static double[] LinearBuckets(double start, double widht, int count)
        {
            return Pro.Histogram.LinearBuckets(start, widht, count);
        }
        public static double[] ExponentialBuckets(double start, double factor, int count)
        {
            return Pro.Histogram.ExponentialBuckets(start, factor, count);
        }

    }
}
