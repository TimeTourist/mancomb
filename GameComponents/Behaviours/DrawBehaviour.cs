using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mancomb.Framework.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace mancomb.Framework.Behaviours
{
    class DrawBehaviour : BaseBehaviour 
    {
        public DrawBehaviour()
        {
        }

        public override void doBehaviour(IEntity parent)
        {
            parent.getManager().game.GraphicsDevice.Clear(parent.getAttribute<Color>("color"));
        }
    }
}
