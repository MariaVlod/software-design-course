using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedoneComposer
{
    internal class EventListener
    {
        public string EventType { get; }
        public Action<LightElementNode> Callback { get; }

        public EventListener(string eventType, Action<LightElementNode> callback)
        {
            EventType = eventType;
            Callback = callback;
        }
    }
}
