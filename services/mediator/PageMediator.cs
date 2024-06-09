using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    public enum MessageType
    {
        Data,
        Navigation,
    }

    public class PageMediator
    {
        private readonly Dictionary<MessageType, List<Action<object?>>> _subscribers = [];
        private readonly ConcurrentDictionary<MessageType, List<Func<object?, Task>>> _asyncSubscribers = [];

        public void Subscribe(MessageType type, Action<object?> handlers)
        {
            if (!_subscribers.ContainsKey(type))
            {
                _subscribers[type] = new List<Action<object?>>();
            }
            _subscribers[type].Add(handlers);
        }

        public void Publish(MessageType type, object? message)
        {
            if (_subscribers.TryGetValue(type, out var handlers))
            {
                foreach (var handler in handlers)
                {
                    handler.Invoke(message);
                }
            }
        }

        public void SubscribeAsync(MessageType type, Func<object?, Task> handlers)
        {
            if (!_asyncSubscribers.ContainsKey(type))
            {
                _asyncSubscribers[type] = new List<Func<object?, Task>>();
            }
            _asyncSubscribers[type].Add(handlers);
        }

        public async Task PublishAsync(MessageType type, object? message)
        {
            if ( _asyncSubscribers.TryGetValue(type,out var handlers))
            {
                foreach (var handler in handlers)
                {
                    await handler.Invoke(message);
                }
            }
        }
    }
}
