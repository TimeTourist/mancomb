using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mancomb.Framework.Core;

namespace mancomb.GameComponents.Behaviours
{
    class PulsatingFloatBehaviour : BaseBehaviour
    {
        float multiplier;
        float offset;
        public PulsatingFloatBehaviour(float offset, float multiplier)
        {
            this.multiplier = multiplier;
            this.offset = offset;
        }
        public override void doBehaviour(IEntity parent)
        {
            string attributeToPulsate = parent.getAttribute<string>("attributeToPulsate");
            float attribute = parent.getAttribute<float>(attributeToPulsate);
            double time = parent.getManager().game.gameTime.TotalGameTime.TotalSeconds;

            float pulsate = (float)Math.Sin(time * 4);
            attribute = multiplier + pulsate * offset;
            parent.addAttribute(attributeToPulsate, attribute);
        }
    }
}
