using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace mancomb.Framework.Core
{
    interface IEntity
    {
        // could be done if the getAttribute is slow.
        // public Dictionary<String, Object> attributes { get; set; }


        /// <summary>
        /// Attributes can be shared with all behaviors in the entity. 
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">object</param>
        void addAttribute(String key, Object value);

        T getAttribute<T>(String key);
            
        /// <summary>
        /// Behaviors change Attributes in the entity
        /// </summary>
        /// <param name="phase">The GameLoopPhase we want this behavior to be run in.</param>
        /// <param name="behaviour">The behavior we want this IEntity to have.</param>
        void addBehaviour(GameLoopPhase phase, IBehaviour behaviour);
        
        /// <summary>
        /// Run this entitys behaviours.
        /// </summary>
        /// <param name="entitiesManager">The managing object</param>
        /// <param name="phase">The phase we are in right now.</param>
        void runBehaviours(GameLoopPhase phase);

        EntitiesManager getManager();
    }
}
