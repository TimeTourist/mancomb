using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mancomb.Framework.Core;


namespace mancomb
{
    /// <summary>
    /// Responsibilities include:
    /// - Create a set of entities that make up a scene (i.e. Level 1, menu, game over, splashscreen etc).
    /// - run all the entites behaviours in the right order
    /// </summary>
    class EntitiesManager
    {
        /// <summary>
        /// Entity list
        /// </summary>
        List<IEntity> entities;

        public Game1 game
        {
            get;
            private set;
        }

        public EntitiesManager(Game1 game)
        {
            this.game = game;
            entities = new List<IEntity>();
        }

        public void addEntity(IEntity entity)
        {
            entities.Add(entity);
        }

        public void run(GameLoopPhase phase)
        {
            foreach (IEntity entity in entities)
            {
                entity.runBehaviours(phase);
            }
        }


    }
}
