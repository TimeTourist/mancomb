using System;

namespace mancomb.Framework.Core
{
	public interface ISubscriber
	{
		void handleMessage(IMessage message);
	}
}

