using System;
using System.Collections.Generic;

namespace Lab
{
	public class TopicQueueManager
	{
		private Dictionary<string, List<object>> messageQue = new Dictionary<string, List<object>>();
		private Dictionary<string, List<ISubscriber>> subscribers = new Dictionary<string, List<ISubscriber>>(); 

		void subscribe(ISubscriber subscriber, string topic)
		{
			subscribers.Add(subscriber, topic);
		}

		void addMessage (string topic, object message)
		{ 
			//not working
			messageQue.Add(topic, message);
		}

		void processMessageQue ()
		{
			List<string> topics = messageQue.Keys;
			foreach (string topic in topics)
			{

				List<object> messages = messageQue[topic];
				List<ISubscriber> subscribers = subscribers[topic];
				foreach (object message in messages)
				{
					foreach (ISubscriber subscriber in subscribers)
					{
						subscriber.onMessage(message);
					}
				}
			}
		}

	}
}

