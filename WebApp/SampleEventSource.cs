using System.Diagnostics.Tracing;

namespace WebApp
{
    public class SampleEventSource : EventSource
    {
        public static readonly SampleEventSource Log = new SampleEventSource();
        private readonly EventCounter _getValuesCounter;

        public SampleEventSource()
        {
            _getValuesCounter = new EventCounter("GetValues", this);
        }

        [Event(1, Level = EventLevel.Informational)]
        public void CallToGetValues()
        {
            _getValuesCounter.WriteMetric(1);

            WriteEvent(1);
        }
    }
}