using System;
using System.Threading.Tasks;
using Pro = Prometheus;

namespace Phonebook.Metrics.Models
{
    public class Counter
    {
        private readonly Pro.Counter _counter;
        public Counter(string name, string help)
        {
            _counter = Pro.Metrics.CreateCounter(name, help);
        }
        public double Value => _counter.Value;
        public void Increment()
        {
            _counter.Inc();
        }
        public void Publish()
        {
            _counter.Publish();
        }
        public async Task<T> CountExceptionsAsync<T>(Func<Task<T>> action)
        {
            return await Pro.CounterExtensions.CountExceptionsAsync(_counter, action);
        }

        public  T CountExceptions<T>(Func<T> action)
        {
            return  Pro.CounterExtensions.CountExceptions(_counter, action);
        }
    }
}
