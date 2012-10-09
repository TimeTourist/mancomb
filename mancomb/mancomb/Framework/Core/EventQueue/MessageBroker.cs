using System;
using System.Collections.Generic;
using System.Linq;

namespace mancomb.Framework.Core
{
    /// <summary>
    /// Senders of messages are called publishers. Published messages are categorized into topics. Receivers can subscribe 
    /// to topics and are called subscribers. Subscribers will only receive messages that are of interest.
    /// 
    /// Publishers post messages to this intermediary message broker and subscribers register subscriptions with that 
    /// broker, letting the broker perform the filtering. The broker normally performs a store and forward function 
    /// to route messages from publishers to subscribers.
    /// </summary>
	public class MessageBroker
	{
        private Dictionary<string, List<IMessage>> messages = new Dictionary<string, List<IMessage>>();
		private Dictionary<string, List<ISubscriber>> subscribers = new Dictionary<string, List<ISubscriber>>();

        /// <summary>
        /// Subscribers can subscribe here by submitting the topic they are interested in. 
        /// The broker will then invoke the handleMessage method on all the intrested subscribers.
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="subscriber"></param>
        void subscribe(string topic, ref ISubscriber subscriber)
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

        /// <summary>
        /// Publishers publish their messages here.
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="message"></param>
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


        /// <summary>
        /// Send the messages to the subscribers.
        /// </summary>
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

            // messages have been dispatched! 
            messages.Clear();
		}

	}
}

