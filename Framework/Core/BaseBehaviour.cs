using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mancomb.Framework.Core; 

namespace mancomb.Framework.Core
{
    class BaseBehaviour : IBehaviour
    {

        public BaseBehaviour()
        {       
        }

        public virtual void doBehaviour(IEntity parent)
        {
        }

        public virtual void onGameEvent()
        {
        }
    }
}

