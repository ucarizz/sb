﻿using System;
using EventBus.Base.Events;

namespace EventBus.Base.Abstraction
{
	public interface IEventBus: IDisposable
	{
		void Publish(IntegrationEvent @event);

		void Subscribe<T, TH>() where T : IntegrationEvent where TH : IIntegrationEventHandler<T>;

        void Unubscribe<T, TH>() where T : IntegrationEvent where TH : IIntegrationEventHandler<T>;


    }
}

