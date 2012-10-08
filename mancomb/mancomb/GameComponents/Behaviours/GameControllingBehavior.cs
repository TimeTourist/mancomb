using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mancomb.Framework.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace mancomb.GameComponents.Behaviours
{
    class GameControllingBehavior : BaseBehaviour
    {

        public override void doBehaviour(IEntity parent)
        {
            // probably not a good place to have Textures... They get big, and are copied here, 
            // better have them stored somewhare for direct access.
            float direction = parent.getAttribute<float>("direction");
            Vector2 position = parent.getAttribute<Vector2>("position");
            Vector2 velocity = parent.getAttribute<Vector2>("velocity");
            GamePadState gamePadState = GamePad.GetState(0);
            KeyboardState keyboardState = Keyboard.GetState(0);

            if (gamePadState.ThumbSticks.Left.X > 0.2f || gamePadState.ThumbSticks.Left.X < -0.2f)
            {
                direction += gamePadState.ThumbSticks.Left.X * 0.1f;
                float circle = MathHelper.Pi * 2;
                direction = direction % circle;
            }
            if (gamePadState.IsButtonDown(Buttons.A) || keyboardState.IsKeyDown(Keys.Up))
            {
                //Velocity += AngleToVector(Direction) * new Vector2(0.3f, 0.3f);
                //Pos += AngleToVector(Direction) * new Vector2(12.3f, 12.3f);
                velocity += AngleToVector(direction) * new Vector2(0.3f, 0.3f);
            }
            if (gamePadState.IsButtonDown(Buttons.Y) || keyboardState.IsKeyDown(Keys.Space))
            {
                position = new Vector2(100, 100);
                velocity = new Vector2();
                direction = 0;
            }

            if (keyboardState.IsKeyDown(Keys.Left) == true)
            {
                direction -= 0.05f;
                float circle = MathHelper.Pi * 2;
                direction = direction % circle;
            }
            else if (keyboardState.IsKeyDown(Keys.Right) == true)
            {
                direction += 0.05f;
                float circle = MathHelper.Pi * 2;
                direction = direction % circle;
            }
            parent.addAttribute("direction", direction);
            parent.addAttribute("position", position);
            parent.addAttribute("velocity", velocity);

        }
        Vector2 AngleToVector(float angle)
        {
            return new Vector2((float)Math.Sin(angle), -(float)Math.Cos(angle));
        }

    }
}
