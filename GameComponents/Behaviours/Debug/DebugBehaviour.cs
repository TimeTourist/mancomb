using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mancomb.Framework.Core;
using Microsoft.Xna.Framework.Input;

namespace mancomb.GameComponents.Behaviours
{
    class DebugBehaviour : BaseBehaviour
    {

        public override void doBehaviour(IEntity parent)
        {
            KeyboardState keyboardState = Keyboard.GetState(0);
            StringBuilder ds = new StringBuilder();

            if (keyboardState.GetPressedKeys().Contains(Keys.Q))
            {
                parent.getManager().game.IsFixedTimeStep = !parent.getManager().game.IsFixedTimeStep; 
            }
            if (keyboardState.GetPressedKeys().Contains(Keys.W))
            {
                parent.getManager().game.graphics.SynchronizeWithVerticalRetrace = !parent.getManager().game.graphics.SynchronizeWithVerticalRetrace;
            }
            ds.Append("IsFixedTimeStep (Q to toggle): ");
            ds.Append(parent.getManager().game.IsFixedTimeStep);
            ds.AppendLine();
            ds.Append("ElapsedGameTime:");
            ds.Append(parent.getManager().game.gameTime.ElapsedGameTime);
            ds.AppendLine();
            ds.Append("TargetElapsedTime: ");
            ds.Append(parent.getManager().game.TargetElapsedTime);
            ds.AppendLine();
            ds.Append("SynchronizeWithVerticalRetrace (W to toggle): ");
            ds.Append(parent.getManager().game.graphics.SynchronizeWithVerticalRetrace);
            

            parent.addAttribute("text", ds.ToString());
        }
    }
}
