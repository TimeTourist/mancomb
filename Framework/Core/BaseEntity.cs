using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace mancomb.Framework.Core
{

    class BaseEntity : IEntity
    {
        /*
         *  Attributes can be updated and changed by all behaviours in the entity. 
         *  Some behaviours are dependent that certain attributes are set.
         */
        Dictionary<String, Object> attributes = new Dictionary<String, Object>();

        /*
         * Behaviours change attributes of an entity. They may also broadcast game 
         * events to entities that have subscribed to them. 
         */
        SortedList<int, IBehaviour> behaviours = new SortedList<int, IBehaviour>();

        public BaseEntity()
        {
        }

        public void addBehaviour(int order, IBehaviour behaviour)
        {
            behaviours.Add(order, behaviour);   
        }

        // overwrits value if same key is used 
        public void addAttribute(String key, Object value)
        {
            attributes[key] = value;
        }

        public Object getAttribute(String key)
        {
            return attributes[key];
        }

        public T getTypedAttribute<T>(string key)
        {
            return (T)attributes[key];
        }

        public void runBehaviours()
        {
            foreach (IBehaviour behaviour in behaviours.Values)
            {
                behaviour.doBehaviour(this);
            }
        }
    }
}