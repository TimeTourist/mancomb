using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mancomb.Framework.Core
{
    public interface IMessage
    {
        T getData<T>();
    }
}
