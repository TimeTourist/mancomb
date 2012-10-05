using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mancomb.Framework.Core
{
    interface IBehaviour
    {
        void doBehaviour(IEntity parent);
        void onGameEvent();
    }
}
