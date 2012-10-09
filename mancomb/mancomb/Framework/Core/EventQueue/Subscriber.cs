using System;

namespace mancomb.Framework.Core
{
	public class Subscriber : ISubscriber
	{
        public void handleMessage(IMessage message)
		{
            int lasse = message.getData<int>();
		}
	}
}

