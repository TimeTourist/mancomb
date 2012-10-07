using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mancomb.Framework.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace mancomb.GameComponents.Behaviours
{
    class DrawTexture2DBehaviour : BaseBehaviour
    {
        public DrawTexture2DBehaviour()
        {
            
        }

        public override void doBehaviour(IEntity parent)
        {
            // probably not a good place to have Textures... They get big, and are copied here, 
            // better have them stored somewhare for direct access.
            Texture2D texture = parent.getAttribute<Texture2D>("texture");
            Vector2 position = parent.getAttribute<Vector2>("position");
            float direction = parent.getAttribute<float>("direction");
            float scale = parent.getAttribute<float>("scale");

            Vector2 origin = new Vector2(texture.Width / 2, texture.Height - texture.Height / 3);

            parent.getManager().game.spriteBatch.Draw(texture, position, null, Color.White, direction, origin, scale, SpriteEffects.None, 0f);

        }

    }
}
