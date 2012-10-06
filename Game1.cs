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

namespace mancomb
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        EntitiesManager entitiesManager;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to doBehavior.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // create the entity manager
            entitiesManager = new EntitiesManager();
            // add some entities (Feature: load from script instead of factory)
            entitiesManager.addEntity(EntityFactory.createBackground(ref graphics));
            entitiesManager.addEntity(EntityFactory.createShip(ref graphics, this.Content));
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
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // run the behaviours that want to run in this phase.
            entitiesManager.run(GameLoopPhase.Update);
        
            // TODO: need to solve that gametime is needed in the behaviours.
            // some links to that effect
            // http://blog.diabolicalgame.co.uk/2011/12/gametime-in-another-thread.html
            // http://xboxforums.create.msdn.com/forums/p/10587/457840.aspx

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            // run the behaviours that want to run in this phase.
            entitiesManager.run(GameLoopPhase.Draw);
            
            base.Draw(gameTime);
        }
    }
}
