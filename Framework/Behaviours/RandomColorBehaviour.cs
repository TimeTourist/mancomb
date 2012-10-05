using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mancomb.Framework.Core;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace mancomb.Framework.Behaviours
{
    class RandomColorBehaviour : BaseBehaviour
    {
        Random r = new Random();
        public RandomColorBehaviour()
        {
        }

        public override void doBehaviour(IEntity parent)
        {
            if (r.Next(0, 100) < 1)
            {
                Color c = new Color(
                    (byte)r.Next(0, 255),
                    (byte)r.Next(0, 255),
                    (byte)r.Next(0, 255));
                parent.addAttribute("color", c);
            }
        }
    }
}
