using System;

namespace Lab
{
	public interface ISubscriber
	{
		void onMessage(string message);
	}
}

