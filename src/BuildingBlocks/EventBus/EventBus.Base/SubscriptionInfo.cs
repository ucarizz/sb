﻿using System;
namespace EventBus.Base
{
	public class SubscriptionInfo
	{
        public SubscriptionInfo(Type handlerType)
        {
            HandlerType = handlerType ?? throw new ArgumentNullException(nameof(handlerType));
        }

        public Type HandlerType { get;}


        public static SubscriptionInfo Typed(Type handlerType)
        {
            return new SubscriptionInfo(handlerType);
        }
	}
}

