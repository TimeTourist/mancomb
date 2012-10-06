using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mancomb.Framework.Core;
using Microsoft.Xna.Framework;
using mancomb.Framework.Behaviours;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using mancomb.GameComponents.Behaviours;

namespace mancomb.GameComponents.Factories
{
    class EntityFactory
    {
        public static IEntity createBackground(ref GraphicsDeviceManager graphics)
        {
            IEntity background = new BaseEntity();
            background.addAttribute("color", Color.Yellow);
            background.addAttribute("gameTime", new GameTime());
            background.addBehaviour(GameLoopPhase.Update, new RandomColorBehaviour());
            background.addBehaviour(GameLoopPhase.Update, new FadeColorBehaviour());
            background.addBehaviour(GameLoopPhase.Draw, new DrawBehaviour(ref graphics));
            return background;
        }

        public static IEntity createShip(ref GraphicsDeviceManager graphics, 
            //ref GamePadState gamePadState, 
            //ref KeyboardState keyboardState,
            ContentManager content)
        {
            IEntity ship = new BaseEntity();
            Vector2 Pos = new Vector2();
            Pos.X = graphics.GraphicsDevice.Adapter.CurrentDisplayMode.Height / 8;
            Pos.Y = graphics.GraphicsDevice.Adapter.CurrentDisplayMode.Width / 8;
            Vector2 Velocity = new Vector2();
            float Weight = 40f;
            float Direction = 0;

            // for controlling behaviour
            ship.addAttribute("Pos", Pos);
            ship.addAttribute("Velocity", Velocity);
            ship.addAttribute("Weight", Weight);
            ship.addAttribute("Direction", Direction);

            //for drawing
            Texture2D Texture = content.Load<Texture2D>("ship");
            ship.addAttribute("Texture", Texture);
            
            //behaviours
            ship.addBehaviour(GameLoopPhase.Draw, new DrawTexture2DBehaviour(ref graphics));

            return ship;
        }
    }
}
