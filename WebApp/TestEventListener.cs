using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;

namespace WebApp
{
    public class TestEventListener : EventListener
    {
        protected override void OnEventSourceCreated(EventSource eventSource)
        {
            Console.WriteLine("EventSource created: " + eventSource.Name);
        }

        protected override void OnEventWritten(EventWrittenEventArgs eventData)
        {
            Console.WriteLine("Event written: " + eventData.EventName);
        }
    }
}
