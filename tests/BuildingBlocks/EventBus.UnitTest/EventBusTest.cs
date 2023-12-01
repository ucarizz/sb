using EventBus.Base;
using EventBus.Base.Abstraction;
using EventBus.Factory;
using EventBus.UnitTest.Events.Events;
using EventBus.UnitTest.Events.EventsHandlers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using RabbitMQ.Client;

namespace EventBus.UnitTest
{
    public class EventBusTest
    {
        private ServiceCollection services;

        public EventBusTest()
        {
            services = new ServiceCollection();
            services.AddLogging(configure=>configure.AddConsole());
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Subscribe_event_on_rabbitmq_test()
        {
            services.AddSingleton<IEventBus>(sp =>
            {
                 
                return EventBusFactory.Create(GetRabbitMQConfig(), sp);
            });

            var serviceProvider = services.BuildServiceProvider();


            var eventBus = serviceProvider.GetRequiredService<IEventBus>();

            eventBus.Subscribe<OrderCreatedIntegrationEvent, OrderCreatedIntegrationEventHandler>();

            eventBus.Unubscribe<OrderCreatedIntegrationEvent, OrderCreatedIntegrationEventHandler>();


        }


        private EventBusConfig GetAzureconfig()
        {
            return new EventBusConfig
            {
                ConnectionRetyCount = 5,
                SubscriberClientAppName = "EventBus.UnitTest",
                DefaultTopicName = "SellingBuddyTopicName",
                EventBusType = EventBusType.AzureServiceBus,
                EventNameSuffix = "IntegrationEvent",
                EventBusConnectionString =""
               
            };
        }

        private EventBusConfig GetRabbitMQConfig()
        {
            return new EventBusConfig
            {
                ConnectionRetyCount = 5,
                SubscriberClientAppName = "EventBus.UnitTest",
                DefaultTopicName = "SellingBuddyTopicName",
                EventBusType = EventBusType.RabbitMQ,
                EventNameSuffix = "IntegrationEvent",
                //Connection = new ConnectionFactory()
                //{
                //    HostName = "localhost",
                //
                //}

            };
        }
    }
}
