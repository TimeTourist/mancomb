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
        Dictionary<GameState, List<IEntity>> scenes;

        public Game1 game
        {
            get;
            private set;
        }

        public EntitiesManager(Game1 game)
        {
            this.game = game;
            scenes = new Dictionary<GameState, List<IEntity>>();
        }

        public void addEntity(GameState state, IEntity entity)
        {
            List<IEntity> entitiesTemp;
            if (scenes.TryGetValue(state, out entitiesTemp))
            {
                entitiesTemp.Add(entity);
            }
            else
            {
                entitiesTemp = new List<IEntity>();
                entitiesTemp.Add(entity);
                scenes.Add(state, entitiesTemp);
            } 
        }

        public void run(GameLoopPhase phase)
        {
            List<IEntity> entitiesTemp;
            if (scenes.TryGetValue(game.currentState, out entitiesTemp))
            {
                foreach (IEntity entity in entitiesTemp)
                {
                    entity.runBehaviours(phase);
                }
            }
        }


    }
}
