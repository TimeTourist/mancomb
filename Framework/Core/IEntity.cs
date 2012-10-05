using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace mancomb.Framework.Core
{
    interface IEntity
    {
            //Attributes
            void addAttribute(String key, Object value);
            
            Object getAttribute(String key);
            
            //Behaviours
            void addBehaviour(int order, IBehaviour behaviour);
              
            void runBehaviours();
    }
}
