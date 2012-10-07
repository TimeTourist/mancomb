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
        public static IEntity createBackground(EntitiesManager manager)
        {
            IEntity background = new BaseEntity(manager);
            background.addAttribute("color", Color.DarkGray);
            background.addAttribute("gameTime", new GameTime());
            background.addBehaviour(GameLoopPhase.Update, new RandomColorBehaviour());
            // menu.addBehaviour(GameLoopPhase.Update, new FadeColorBehaviour());
            background.addBehaviour(GameLoopPhase.Draw, new DrawBehaviour());
            background.addBehaviour(GameLoopPhase.Update, new GameStateChangingBehaviour(Keys.Escape, Buttons.Back, GameState.MainMenu));
            return background;
        }

        public static IEntity createShip(EntitiesManager manager)
        {
            IEntity ship = new BaseEntity(manager);
            Vector2 Pos = new Vector2();
            Pos.X = manager.game.GraphicsDevice.Adapter.CurrentDisplayMode.Height / 8;
            Pos.Y = manager.game.GraphicsDevice.Adapter.CurrentDisplayMode.Width / 8;
            float Weight = 40f;
            float Direction = 0.0f;
            Vector2 Velocity = new Vector2();

            // for controlling behaviour
            ship.addAttribute("Pos", Pos);
            ship.addAttribute("Velocity", Velocity);
            ship.addAttribute("Weight", Weight);
            ship.addAttribute("Direction", Direction);

            //for drawing
            Texture2D Texture = manager.game.Content.Load<Texture2D>("molly");
            ship.addAttribute("Texture", Texture);
            
            //behaviours
            ship.addBehaviour(GameLoopPhase.Update, new GameControllingBehavior());
            ship.addBehaviour(GameLoopPhase.Update, new TemporaryGravityBehaviour());
            ship.addBehaviour(GameLoopPhase.Draw, new DrawTexture2DBehaviour());

            return ship;
        }

        public static IEntity createDebugScreen(EntitiesManager manager)
        {
            IEntity debug = new BaseEntity(manager);
            SpriteFont font = manager.game.Content.Load<SpriteFont>("DebugFont");
            String prefix = "debug";
            debug.addAttribute(prefix + "Text", "Something");
            debug.addAttribute(prefix + "Color", Color.White);
            debug.addAttribute(prefix + "Position", new Vector2(40, 40));
            debug.addBehaviour(GameLoopPhase.Draw, new DrawTextBehaviour(font, prefix));
            debug.addBehaviour(GameLoopPhase.Update, new DebugBehaviour());

            return debug;
        }


        internal static IEntity createMenu(EntitiesManager menuEntitiesManager)
        {
            IEntity menu = new BaseEntity(menuEntitiesManager);
            SpriteFont MenuTitle = menuEntitiesManager.game.Content.Load<SpriteFont>("MenuTitle");
            SpriteFont MenuItem = menuEntitiesManager.game.Content.Load<SpriteFont>("MenuItem");

            String prefix = "menuTitle";
            menu.addAttribute(prefix + "Text", "Menu");
            menu.addAttribute(prefix + "Color", Color.White);
            menu.addAttribute(prefix + "Position", new Vector2(40, 50));
            menu.addBehaviour(GameLoopPhase.Draw, new DrawTextBehaviour(MenuTitle, prefix));

            prefix = "menuItem1";
            menu.addAttribute(prefix + "Text", "Play (A)");
            menu.addAttribute(prefix + "Color", Color.Indigo);
            menu.addAttribute(prefix + "Position", new Vector2(40, 90));
            menu.addBehaviour(GameLoopPhase.Draw, new DrawTextBehaviour(MenuItem, prefix));

            prefix = "menuItem2";
            menu.addAttribute(prefix + "Text", "Quit <BACK");
            menu.addAttribute(prefix + "Color", Color.Indigo);
            menu.addAttribute(prefix + "Position", new Vector2(40, 120));
            menu.addBehaviour(GameLoopPhase.Draw, new DrawTextBehaviour(MenuItem, prefix));

            menu.addAttribute("color", Color.DarkOrchid);
            menu.addBehaviour(GameLoopPhase.Draw, new DrawBehaviour());

            menu.addBehaviour(GameLoopPhase.Update, new GameStateChangingBehaviour(Keys.Enter, Buttons.A, GameState.Level1));
            menu.addBehaviour(GameLoopPhase.Update, new GameStateChangingBehaviour(Keys.Escape, Buttons.Back, GameState.Exit));

            return menu;
        }

        public static IEntity createGameExit(EntitiesManager manager)
        {
            IEntity exit = new BaseEntity(manager);
            exit.addBehaviour(GameLoopPhase.Update, new ExitBehaviour());

            return exit;
        }

    }
}
