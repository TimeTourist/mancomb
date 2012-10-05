using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mancomb.Framework.Core;
using Microsoft.Xna.Framework;

namespace mancomb.Framework.Behaviours
{
    class FadeColorBehaviour : BaseBehaviour
    {
        Color goalColor = Color.Firebrick;

        float alphaValue = 0f;

        float fadeIncrement = 0.0005f;

        double fadeDelay = .035;


        public FadeColorBehaviour()
        {
        }

        public override void doBehaviour(IEntity parent)
        {
            GameTime gameTime = (GameTime)parent.getAttribute("gameTime"); 

            fadeDelay -= gameTime.ElapsedGameTime.TotalSeconds;

            if (fadeDelay <= 0)
            {              
                //Reset the Fade delay
                fadeDelay = .035;
                //Increment/Decrement the fade value for the image
                alphaValue += fadeIncrement;
                //If the AlphaValue is equal or above the max Alpha value or
                //has dropped below or equal to the min Alpha value, then 
                //reverse the fade
                if (alphaValue > 1f)
                {
                    alphaValue = 0f;

                }

                Color color = Color.Lerp((Color)parent.getAttribute("color"), goalColor, alphaValue);
                parent.addAttribute("color", color);
                
            }
        }
    }
}