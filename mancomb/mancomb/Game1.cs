using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using mancomb.Framework.Core;
using mancomb.Framework.Behaviours;
using mancomb.GameComponents.Factories;
using System.Reflection;

namespace mancomb
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public GraphicsDeviceManager graphics;

        EntitiesManager entitiesManager;

        public GameState currentState;

        public SpriteBatch spriteBatch;
        // Reflection hack for accessing gameTime.
        public GameTime gameTime 
        {
            get; 
            private set;
        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 768;
            //graphics.PreferMultiSampling = false;
            graphics.IsFullScreen = false;

            currentState = GameState.MainMenu;
            // create the entity manager
            entitiesManager = new EntitiesManager(this);

            Content.RootDirectory = "Content";
            
            //Reflection hack for accessing gameTime. Will it work?
            gameTime = (GameTime)typeof(Game).GetField("gameTime", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(this);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to doBehavior.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // Set properties
            this.IsFixedTimeStep = true;
            graphics.SynchronizeWithVerticalRetrace = false;   
            
     
            spriteBatch = new SpriteBatch(this.GraphicsDevice);
            //
            // menu entity manager init
            //
            entitiesManager.addEntity(GameState.MainMenu, EntityFactory.createMenu(entitiesManager));
            //menuEntitiesManager.addEntity();

            //
            // Level entity manager init
            //
            // add some entities (Feature: load from script instead of factory)
            entitiesManager.addEntity(GameState.Level1, EntityFactory.createBackground(entitiesManager));
            entitiesManager.addEntity(GameState.Level1, EntityFactory.createShip(entitiesManager));
            entitiesManager.addEntity(GameState.Level1, EntityFactory.createDebugScreen(entitiesManager));
            
            
            //
            // Game exit
            //
            entitiesManager.addEntity(GameState.Exit, EntityFactory.createGameExit(entitiesManager));



            // run the behaviours that want to run in this phase.
            entitiesManager.run(GameLoopPhase.Initialize);
            base.Initialize();
            
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // run the behaviours that want to run in this phase.
            entitiesManager.run(GameLoopPhase.LoadContent);
            // TODO: use this.Content to load your game content here

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // run the behaviours that want to run in this phase.
            entitiesManager.run(GameLoopPhase.UnloadContent);
            
        }

        /// <summary>
        /// Allows the game to doBehavior logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime localGameTime)
        {
      
            // Allows the game to exit
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed 
            //    || Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Escape))
            //    this.Exit();
            // run the behaviours that want to run in this phase.
            entitiesManager.run(GameLoopPhase.Update);

            base.Update(localGameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime localGameTime)
        {
            // leaving this here for now...
            spriteBatch.Begin();
            // run the behaviours that want to run in this phase.
            entitiesManager.run(GameLoopPhase.Draw);
            
            spriteBatch.End();
            base.Draw(localGameTime);
        }
    }
}
