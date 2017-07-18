using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;

namespace WebApp
{
    public class TestEventSource : EventSource
    {
        public static readonly TestEventSource Log = new TestEventSource();
        private readonly EventCounter _testCounter;

        public TestEventSource()
        {
            _testCounter = new EventCounter("Blah", this);
        }

        [Event(1, Level = EventLevel.Informational)]
        public void Foo()
        {
            WriteEvent(1);
            _testCounter.WriteMetric(1);
        }
    }
}