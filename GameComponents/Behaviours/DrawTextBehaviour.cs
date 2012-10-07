using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mancomb.Framework.Core;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace mancomb.GameComponents.Behaviours
{
    class DrawTextBehaviour : BaseBehaviour
    {
        public override void doBehaviour(IEntity parent)
        {
            SpriteFont font = parent.getAttribute<SpriteFont>("font");
            String text = parent.getAttribute<String>("text");
            parent.getManager().game.spriteBatch.DrawString(font, text, new Vector2(20, 45), Color.White);
        }
    }
}
