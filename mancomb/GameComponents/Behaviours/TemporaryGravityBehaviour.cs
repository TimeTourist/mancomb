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
            Vector2 velocity = parent.getAttribute<Vector2>("velocity");
            Vector2 position = parent.getAttribute<Vector2>("position");
            float weight = parent.getAttribute<float>("weight");
            // float timeSeconds = parent.getManager().game.gameTime.ElapsedGameTime.Milliseconds * 0.0001f;
            velocity = new Vector2(velocity.X, velocity.Y + (weight));
            position += velocity;
            parent.addAttribute("velocity", velocity);
            parent.addAttribute("position", position);
            parent.addAttribute("weight", weight);
        }
    }
}
