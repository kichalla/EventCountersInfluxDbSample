using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;

namespace WebApp.Internal
{
    public class SampleEventListener : EventListener
    {
        protected override void OnEventSourceCreated(EventSource eventSource)
        {
            Console.WriteLine("EventSource created: " + eventSource.Name);
        }

        protected override void OnEventWritten(EventWrittenEventArgs eventData)
        {
            if (eventData.EventName != "EventCounters")
            {
                return;
            }

            if (eventData.Payload.Count > 0)
            {
                var payload = eventData.Payload[0] as IDictionary<string, object>;
                if (payload != null)
                {
                    var eventCounterPayload = new EventCounterPayload(payload);

                    // Push to InfluxDb
                }
            }
        }
    }
}
