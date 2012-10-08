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
using mancomb.GameComponents.Behaviours.StateTransition;

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

            // for controlling behaviour
            ship.addAttribute("position", Pos);
            ship.addAttribute("velocity", new Vector2());
            ship.addAttribute("weight", 0.0076f);
            ship.addAttribute("direction", 0.0f);
            ship.addAttribute("scale", 1f);

            //for drawing
            Texture2D texture = manager.game.Content.Load<Texture2D>("ship");
            ship.addAttribute("texture", texture);
            
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
            debug.addAttribute(prefix + "Scale", 1f);
            debug.addAttribute(prefix + "Rotation", 0f);
            debug.addAttribute(prefix + "Position", new Vector2(40, 40));
            debug.addBehaviour(GameLoopPhase.Draw, new DrawTextBehaviour(font, prefix));
            debug.addBehaviour(GameLoopPhase.Update, new DebugBehaviour());

            return debug;
        }


        internal static IEntity createMenu(EntitiesManager menuEntitiesManager)
        {
            IEntity menu = new BaseEntity(menuEntitiesManager);

            Texture2D boxTexture = new Texture2D(menuEntitiesManager.game.GraphicsDevice, 1, 1);
            boxTexture.SetData(new Color[] { Color.White });

            menu.addAttribute("boxTexture", boxTexture);
            menu.addAttribute("boxColor", Color.DarkGoldenrod);
            menu.addAttribute("boxRectangle", new Rectangle(20, 30, 345, 200));
            menu.addBehaviour(GameLoopPhase.Draw, new DrawFilledRectangleBehaviour());            
            
            SpriteFont MenuTitle = menuEntitiesManager.game.Content.Load<SpriteFont>("MenuTitle");
            SpriteFont MenuItem = menuEntitiesManager.game.Content.Load<SpriteFont>("MenuItem");

            String prefix = "menuTitle";
            menu.addAttribute(prefix + "Text", "Menu");
            menu.addAttribute(prefix + "Color", Color.White);
            menu.addAttribute(prefix + "Scale", 1f);
            menu.addAttribute(prefix + "Rotation", 0f);
            menu.addAttribute(prefix + "Position", new Vector2(40, 50));
            menu.addBehaviour(GameLoopPhase.Draw, new DrawTextBehaviour(MenuTitle, prefix));

            prefix = "menuItem1";
            menu.addAttribute(prefix + "Text", "Play (A) or (Enter)");
            menu.addAttribute(prefix + "Color", Color.Wheat);
            menu.addAttribute(prefix + "Scale", 1f);
            menu.addAttribute(prefix + "Rotation", 0.05f);
            menu.addAttribute(prefix + "Position", new Vector2(40, 90));
            menu.addBehaviour(GameLoopPhase.Draw, new DrawTextBehaviour(MenuItem, prefix));

            prefix = "menuItem2";
            menu.addAttribute(prefix + "Text", "Quit <BACK or (Esc)");
            menu.addAttribute(prefix + "Color", Color.Wheat);
            menu.addAttribute(prefix + "Scale", 1f);
            menu.addAttribute(prefix + "Rotation", 0f);
            menu.addAttribute(prefix + "Position", new Vector2(40, 120));
            menu.addBehaviour(GameLoopPhase.Draw, new DrawTextBehaviour(MenuItem, prefix));

            List<String> attributesToPulsate = new List<string>();
            //menu.addAttribute("attributeToPulsate", "menuItem1Scale");
            //menu.addBehaviour(GameLoopPhase.Update, new PulsatingFloatBehaviour(1f));
            menu.addAttribute("attributeToPulsate", "menuItem1Rotation");
            menu.addBehaviour(GameLoopPhase.Update, new PulsatingFloatBehaviour(0.03f, 0f));

            menu.addAttribute("color", Color.LightSteelBlue);
            menu.addBehaviour(GameLoopPhase.Draw, new DrawBehaviour());

            menu.addBehaviour(GameLoopPhase.Update, new GameStateChangingBehaviour(Keys.Enter, Buttons.A, GameState.Level1));
            menu.addBehaviour(GameLoopPhase.Update, new GameStateChangingBehaviour(Keys.Escape, Buttons.Back, GameState.Exit));

            return menu;
        }

        public static IEntity createGameExit(EntitiesManager manager)
        {
            IEntity exit = new BaseEntity(manager);
            exit.addBehaviour(GameLoopPhase.Update, new ExitGameBehaviour());

            return exit;
        }

    }
}
