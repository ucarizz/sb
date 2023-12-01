using System;
namespace EventBus.Base
{
	public class EventBusConfig
	{
		public EventBusConfig()
		{
		}

		public int ConnectionRetyCount { get; set; } = 5;

		public string DefaultTopicName { get; set; } = "SellingBuddyEventBus";

		public string EventBusConnectionString { get; set; } = String.Empty;

		public string SubscriberClientAppName { get; set; } = String.Empty;

        public string EventNamePrefix { get; set; } = String.Empty;

        public string EventNameSuffix { get; set; } = "IntegrationEvent";

		public EventBusType EventBusType { get; set; } = EventBusType.RabbitMQ;

		public object Connection { get; set; }

		public bool DeletedEventPrefix => !String.IsNullOrEmpty(EventNamePrefix);

        public bool DeletedEventSuffix => !String.IsNullOrEmpty(EventNameSuffix);


    }

    public enum EventBusType
	{
        RabbitMQ = 0,
		AzureServiceBus = 1
    }
}

