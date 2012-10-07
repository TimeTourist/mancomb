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
            Texture2D Texture = parent.getAttribute<Texture2D>("Texture");
            Vector2 Pos = parent.getAttribute<Vector2>("Pos");
            float Direction = parent.getAttribute<float>("Direction");
           
            Vector2 origin = new Vector2(Texture.Width / 2, Texture.Height - Texture.Height / 3);

            float size = 1f;

            parent.getManager().game.spriteBatch.Draw(Texture, Pos, null, Color.White, Direction, origin, size, SpriteEffects.None, 0f);

        }

    }
}
