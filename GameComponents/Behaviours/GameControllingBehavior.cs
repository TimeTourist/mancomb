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
            float Direction = parent.getAttribute<float>("Direction");
            Vector2 Pos = parent.getAttribute<Vector2>("Pos");
            Vector2 Velocity = parent.getAttribute<Vector2>("Velocity");
            GamePadState gamePadState = GamePad.GetState(0);
            KeyboardState keyboardState = Keyboard.GetState(0);

            if (gamePadState.ThumbSticks.Left.X > 0.2f || gamePadState.ThumbSticks.Left.X < -0.2f)
            {
                Direction += gamePadState.ThumbSticks.Left.X * 0.1f;
                float circle = MathHelper.Pi * 2;
                Direction = Direction % circle;
            }
            if (gamePadState.IsButtonDown(Buttons.A) || keyboardState.IsKeyDown(Keys.Up))
            {
                Velocity += AngleToVector(Direction) * new Vector2(0.3f, 0.3f);
            }
            if (gamePadState.IsButtonDown(Buttons.Y) || keyboardState.IsKeyDown(Keys.Space))
            {
                Pos = new Vector2(100, 100);
                Velocity = new Vector2();
                Direction = 0;
            }

            if (keyboardState.IsKeyDown(Keys.Left) == true)
            {
                Direction -= 0.05f;
                float circle = MathHelper.Pi * 2;
                Direction = Direction % circle;
            }
            else if (keyboardState.IsKeyDown(Keys.Right) == true)
            {
                Direction += 0.05f;
                float circle = MathHelper.Pi * 2;
                Direction = Direction % circle;
            }
            parent.addAttribute("Direction", Direction);
            parent.addAttribute("Pos", Pos);
            parent.addAttribute("Velocity", Velocity);

        }
        Vector2 AngleToVector(float angle)
        {
            return new Vector2((float)Math.Sin(angle), -(float)Math.Cos(angle));
        }

    }
}
