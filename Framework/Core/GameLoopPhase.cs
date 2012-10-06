using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mancomb.Framework.Core
{
    /// <summary>
    /// En entitys behaviour is allowd one GameLoopPhase.
    /// </summary>
    public enum GameLoopPhase
    {
        Initialize = 10,
        LoadContent = 20,
        UnloadContent = 30,
        Update = 40,
        Draw = 50,
        Exit = 1000
    }
}
