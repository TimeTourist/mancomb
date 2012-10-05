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
        GraphicsDeviceManager gdm;
        SpriteBatch spriteBatch;

        public DrawTexture2DBehaviour(ref GraphicsDeviceManager gdm)
        {
            this.gdm = gdm;
            this.spriteBatch = new SpriteBatch(gdm.GraphicsDevice);

        }

        public override void doBehaviour(IEntity parent)
        {
            Texture2D Texture = parent.getTypedAttribute<Texture2D>("Texture");
            Vector2 Pos = parent.getTypedAttribute<Vector2>("Pos");
            float Direction = parent.getTypedAttribute<float>("Direction");
           
            Vector2 origin = new Vector2(Texture.Width / 2, Texture.Height - Texture.Height / 3);

            spriteBatch.Begin();
            //spriteBatch.Draw(Texture, Pos, Color.White);

            spriteBatch.Draw(Texture, Pos, null, Color.White, Direction, origin, 0.5f, SpriteEffects.None, 0f);
            spriteBatch.End();
        }

    }
}
