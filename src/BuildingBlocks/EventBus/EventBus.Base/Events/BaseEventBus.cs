using System;
using System.Linq;
using System.Threading.Tasks;
using EventBus.Base.Abstraction;
using EventBus.Base.SubManagers;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace EventBus.Base.Events
{
	public abstract class BaseEventBus : IEventBus
	{
        public readonly IServiceProvider ServiceProvider;
        public readonly IEventBusSubscriptionManager SubsManager;

        public EventBusConfig EventBusConfig { get; set; }

		public BaseEventBus(EventBusConfig config, IServiceProvider serviceProvider )
		{
            EventBusConfig = config;
            ServiceProvider = serviceProvider;
            SubsManager = new InMemoryEventBusSubscriptionManager(ProcessEventName);
		}

        public virtual string ProcessEventName(string eventName)
        {
            if (EventBusConfig.DeletedEventPrefix)
                eventName = eventName.TrimStart(EventBusConfig.EventNamePrefix.ToArray());

            if(EventBusConfig.DeletedEventSuffix)
                eventName = eventName.TrimEnd(EventBusConfig.EventNameSuffix.ToArray());

            return eventName;
        }

        public virtual string GetSubName(string eventName)
        {
            return $"{EventBusConfig.SubscriberClientAppName}.{ProcessEventName(eventName)}";
        }

        public async Task<bool> ProcessEvent(string eventName, string mesaage)
        {
            eventName = ProcessEventName(eventName);

            var processed = false;

            if (SubsManager.HasSubscriptionForEvent(eventName))
            {
                var subscriptions = SubsManager.GetHandlersForEvent(eventName);

                using(var scope = ServiceProvider.CreateScope())
                {
                    foreach(var subscription in subscriptions)
                    {
                        var handler = ServiceProvider.GetService(subscription.HandlerType);

                        if (handler == null) continue;

                        var eventType = SubsManager.GetEventTypeByName($"{EventBusConfig.EventNamePrefix}{eventName}{EventBusConfig.EventNameSuffix}");
                        var integrationEvent = JsonConvert.DeserializeObject(mesaage, eventType);

                       //if(integrationEvent is IntegrationEvent)
                       // {
                       //     EventBusConfig.CorrelationIdSetter?.Invoke((integrationEvent as IntegrationEvent).CorrelationId);
                       // }

                        //reflaction yöntemi inceleeeee
                        var concreteType = typeof(IIntegrationEventHandler<>).MakeGenericType(eventType);
                        await (Task)concreteType.GetMethod("Handle").Invoke(handler, new object[] { integrationEvent });
                    }

                }

                processed = true;
            }

            return processed;
        }

        public abstract void Publish(IntegrationEvent @event);
        

        public abstract void Subscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>;

        public abstract void Unubscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>;

        public virtual void Dispose()
        {
            EventBusConfig = null;
            SubsManager.Clear();
        }
    }
}

