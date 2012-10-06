using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using NUnit.Mocks;

namespace mancomb.Framework.Core
{

    class BaseEntity : IEntity
    {
        /// <summary>
        ///  Attributes can be updated and changed by all behaviours in the entity. 
        ///  Some behaviours are dependent that certain attributes are set.
        /// </summary>
        Dictionary<String, Object> attributes = new Dictionary<String, Object>();

        /// <summary>
        /// Behaviours change attributes of an entity. They may also broadcast game 
        /// events to entities that have subscribed to them. 
        /// </summary>
        Dictionary<GameLoopPhase, List<IBehaviour>> behaviours = new Dictionary<GameLoopPhase, List<IBehaviour>>();

        EntitiesManager entityManager;

        /// <summary>
        /// 
        /// </summary>
        public BaseEntity(EntitiesManager entityManager)
        {
            this.entityManager = entityManager;
        }

        public EntitiesManager getManager()
        {
            return entityManager;
        }

        public void addBehaviour(GameLoopPhase phase, IBehaviour behaviourToAdd)
        {

            Debug.Assert(verifyAttributes(behaviourToAdd), getMissingAttributes(behaviourToAdd));

            List<IBehaviour> entityBehaviours;
            if (behaviours.TryGetValue(phase, out entityBehaviours))
            {
                entityBehaviours.Add(behaviourToAdd);
            }
            else
            {
                entityBehaviours = new List<IBehaviour>();
                entityBehaviours.Add(behaviourToAdd);
                behaviours.Add(phase, entityBehaviours);
            } 
        }

        /// <summary>
        /// It might be a good idea to verify that an Entity has all the Attributes the Behaviour needs.
        /// Using this debug we will notice this early, instead of getting a key not found later... 
        /// This is due to the extremly loose coupling of Attributes and Behaviours. Only way I can think of 
        /// is to check at runtime.
        /// Not sure how to implement this yet... 
        /// 
        /// For debugging only.
        /// Verify that all attributes in the entity that are needed by the behaviour 
        /// are initilized. 
        /// </summary>
        /// <param name="behaviourToAdd">Behaviour to </param>
        /// <returns>true if all the attributes have been initilized</returns>
        private Boolean verifyAttributes(IBehaviour behaviourToAdd)
        {
            return true;
        }

        /// <summary>
        /// For debugging only.
        /// Get the error message.
        /// Maybe the missing attributes?
        /// </summary>
        /// <param name="behaviourToAdd"></param>
        /// <returns></returns>
        private string getMissingAttributes(IBehaviour behaviourToAdd)
        {
            return "Missing some attributes for behaviour of type: " + behaviourToAdd.GetType().FullName;
        }

        /// <summary>
        /// overwrits value if same key is used
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">value</param>
        public void addAttribute(String key, Object value)
        {
            attributes[key] = value;
        }

        /// <summary>
        /// Get a key of Type T
        /// </summary>
        /// <typeparam name="T">Class type</typeparam>
        /// <param name="key">Attribute key</param>
        /// <returns>Attribute Value</returns>
        public T getAttribute<T>(string key)
        {
             return (T)attributes[key];
        }

        public void runBehaviours(GameLoopPhase phase)
        {
            List<IBehaviour> entityBehaviours;
            if (behaviours.TryGetValue(phase, out entityBehaviours))
            {
                foreach (IBehaviour behaviour in entityBehaviours)
                {
                    behaviour.doBehaviour(this);
                }   
            }
        }


    }
}