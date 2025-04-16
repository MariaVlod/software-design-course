using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedoneComposer
{
    internal class EventManager 
    {
        private readonly Dictionary<string, List<Action<LightElementNode>>> _eventListeners = new();

        public void Subscribe(string eventType, Action<LightElementNode> listener)
        {
            if (!_eventListeners.ContainsKey(eventType))
            {
                _eventListeners[eventType] = new List<Action<LightElementNode>>();
            }
            _eventListeners[eventType].Add(listener);
        }

        public void Unsubscribe(string eventType, Action<LightElementNode> listener)
        {
            if (_eventListeners.ContainsKey(eventType))
            {
                _eventListeners[eventType].Remove(listener);
            }
        }

        public void Notify(string eventType, LightElementNode element)
        {
            if (_eventListeners.ContainsKey(eventType))
            {
                foreach (var listener in _eventListeners[eventType])
                {
                    listener(element);
                }
            }
        }
    }
}
