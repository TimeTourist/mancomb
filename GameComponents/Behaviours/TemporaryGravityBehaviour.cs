using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mancomb.Framework.Core;
using Microsoft.Xna.Framework;

namespace mancomb.GameComponents.Behaviours
{
    /// <summary>
    /// Should be replaced by Physics engine! 
    /// </summary>
    class TemporaryGravityBehaviour : BaseBehaviour
    {
        public override void doBehaviour(IEntity parent)
        {
            Vector2 Velocity = parent.getAttribute<Vector2>("Velocity");
            Vector2 Pos = parent.getAttribute<Vector2>("Pos");
            float Weight = parent.getAttribute<float>("Weight");
            // float timeSeconds = parent.getManager().game.gameTime.ElapsedGameTime.Milliseconds * 0.0001f;
            Velocity = new Vector2(Velocity.X, Velocity.Y + (0.0076f));
            Pos += Velocity;
            parent.addAttribute("Velocity", Velocity);
            parent.addAttribute("Pos", Pos);
            parent.addAttribute("Weight", Weight);
        }
    }
}
