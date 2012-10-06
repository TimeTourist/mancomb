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
        GraphicsDeviceManager gdm;

        public DrawBehaviour(ref GraphicsDeviceManager gdm)
        {
            this.gdm = gdm;  
        }

        public override void doBehaviour(IEntity parent)
        {
            gdm.GraphicsDevice.Clear(parent.getAttribute<Color>("color"));
        }
    }
}
