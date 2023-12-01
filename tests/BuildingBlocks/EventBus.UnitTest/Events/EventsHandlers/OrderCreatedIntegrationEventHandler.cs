using System;
using System.Threading.Tasks;
using EventBus.Base.Abstraction;
using EventBus.UnitTest.Events.Events;

namespace EventBus.UnitTest.Events.EventsHandlers
{
	public class OrderCreatedIntegrationEventHandler : IIntegrationEventHandler<OrderCreatedIntegrationEvent>
	{
		public OrderCreatedIntegrationEventHandler()
		{
		}

        public Task Handle(OrderCreatedIntegrationEvent @event)
        {
            return Task.CompletedTask;
        }
    }
}

