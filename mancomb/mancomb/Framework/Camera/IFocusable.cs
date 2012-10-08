using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace mancomb.Framework.Camera
{
    /// <summary>
    /// Taken from http://stackoverflow.com/questions/712296/xna-2d-camera-engine-that-follows-sprite
    /// </summary>
    public interface IFocusable
    {
        Vector2 Position { get; }
    }

}
