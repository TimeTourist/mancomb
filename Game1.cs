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
        EntitiesManager level1EntitiesManager;
        //EntitiesManager Menu
        public SpriteBatch spriteBatch;
        // Reflection hack for accessing gameTime. Will it work?
        public GameTime gameTime 
        {
            get; 
            private set;
        }
        SpriteFont font;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferMultiSampling = false;
            graphics.IsFullScreen = false;
           
            // create the entity manager
            level1EntitiesManager = new EntitiesManager(this);
            Content.RootDirectory = "Content";
            
            //Reflection hack for accessing gameTime. Will it work?
            gameTime = (GameTime)typeof(Game).GetField("gameTime", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(this);

            //gameTime = new GameTime();
            //base.Update(gameTime);
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
            // add some entities (Feature: load from script instead of factory)
            level1EntitiesManager.addEntity(EntityFactory.createBackground(level1EntitiesManager));
            level1EntitiesManager.addEntity(EntityFactory.createShip(level1EntitiesManager));
            level1EntitiesManager.addEntity(EntityFactory.createDebugScreen(level1EntitiesManager));
            // run the behaviours that want to run in this phase.
            level1EntitiesManager.run(GameLoopPhase.Initialize);
            
            base.Initialize();
            
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // run the behaviours that want to run in this phase.
            level1EntitiesManager.run(GameLoopPhase.LoadContent);
            
            // TODO: use this.Content to load your game content here

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // run the behaviours that want to run in this phase.
            level1EntitiesManager.run(GameLoopPhase.UnloadContent);
        }

        /// <summary>
        /// Allows the game to doBehavior logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime localGameTime)
        {
      
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed 
                || Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Escape))
                this.Exit();
            // run the behaviours that want to run in this phase.
            level1EntitiesManager.run(GameLoopPhase.Update);

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
            level1EntitiesManager.run(GameLoopPhase.Draw);
            spriteBatch.End();
            base.Draw(localGameTime);
        }
    }
}
