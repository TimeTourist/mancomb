using System;
using System.Collections.Generic;

namespace mancomb.Framework.Core
{
	public class MessageQueueDispatcher
	{
        private Dictionary<string, List<IMessage>> messages = new Dictionary<string, List<IMessage>>();
		private Dictionary<string, List<ISubscriber>> subscribers = new Dictionary<string, List<ISubscriber>>(); 

		void subscribe(string topic, ISubscriber subscriber)
		{
            List<ISubscriber> tempSubscribers;
            if (subscribers.TryGetValue(topic, out tempSubscribers))
            {
                tempSubscribers.Add(subscriber);
            }
            else
            {
                tempSubscribers = new List<ISubscriber>();
                tempSubscribers.Add(subscriber);
                subscribers.Add(topic, tempSubscribers);
            } 
		}

        void addMessage(string topic, IMessage message)
		{
            List<IMessage> tempMessages;
            if (messages.TryGetValue(topic, out tempMessages))
            {
                tempMessages.Add(message);
            }
            else
            {
                tempMessages = new List<IMessage>();
                tempMessages.Add(message);
                messages.Add(topic, tempMessages);
            } 
		}

		void dispatchMessages ()
		{
            foreach (string topic in messages.Keys)
			{
				List<IMessage> mess = messages[topic];
				List<ISubscriber> subs = subscribers[topic];
                foreach (IMessage message in mess)
				{
                    foreach (ISubscriber subscriber in subs)
					{
						subscriber.handleMessage(message);
					}
				}
			}
		}

	}
}

