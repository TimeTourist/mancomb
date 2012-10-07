using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mancomb.Framework.Core;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace mancomb.GameComponents.Behaviours
{
    class DrawFilledRectangleBehaviour : BaseBehaviour
    {
        public override void doBehaviour(IEntity parent)
        {
            Rectangle rectangle = parent.getAttribute<Rectangle>("boxRectangle");
            Color color = parent.getAttribute<Color>("boxColor");

            parent.getManager().game.spriteBatch.Draw(parent.getAttribute<Texture2D>("boxTexture"), rectangle, color);

        }
    }
}
