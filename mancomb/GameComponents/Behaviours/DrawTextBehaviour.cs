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
        private SpriteFont font;
        private string textAttributeName;

        public DrawTextBehaviour(SpriteFont font, string textAttributeName)
        {
            this.font = font;
            this.textAttributeName = textAttributeName;
        }

        public override void doBehaviour(IEntity parent)
        {
            String text = parent.getAttribute<String>(textAttributeName+"Text");
            Color color = parent.getAttribute<Color>(textAttributeName+"Color");
            Vector2 position = parent.getAttribute<Vector2>(textAttributeName+"Position");
            float scale = parent.getAttribute<float>(textAttributeName + "Scale");
            float rotation = parent.getAttribute<float>(textAttributeName + "Rotation");
 
            //parent.getManager().game.spriteBatch.DrawString(font, text, position, color);
            Vector2 origin = font.MeasureString(text) / 2;
            position += origin;
            parent.getManager().game.spriteBatch.DrawString(font, text, position, color, rotation, origin, scale, SpriteEffects.None, 0);
        }
    }
}
