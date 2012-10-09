using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mancomb.Framework.Core
{
    class Message : IMessage
    {
        object data;
        public Message(object data)
        {
           this.data = data;
        }

        public virtual T getData<T>()
        {
            return (T)data;
        }
    }
}
