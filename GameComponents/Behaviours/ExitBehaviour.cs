using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mancomb.Framework.Core;

namespace mancomb.GameComponents.Factories
{
    class ExitBehaviour : BaseBehaviour
    {
        public override void doBehaviour(IEntity parent)
        {
            parent.getManager().game.Exit();
        }
    }
}
