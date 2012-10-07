using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mancomb.Framework.Core;
using Microsoft.Xna.Framework.Input;

namespace mancomb.GameComponents.Behaviours
{
    class GameStateChangingBehaviour : BaseBehaviour
    {
        GamePadState oldGamePadState;
        KeyboardState oldKeyboardState;
        
        Keys changeStatusKey;
        Buttons changeStatusButton;
        GameState nextState;
        public GameStateChangingBehaviour(Keys changeStatusKey, Buttons changeStatusButton, GameState nextState)
        {
            this.changeStatusKey = changeStatusKey;
            this.changeStatusButton = changeStatusButton;
            GamePadState gamePadState = GamePad.GetState(0);
            KeyboardState keyboardState = Keyboard.GetState(0);
            this.nextState = nextState;
        }

        public override void doBehaviour(IEntity parent)
        {
            GamePadState gamePadState = GamePad.GetState(0);
            KeyboardState keyboardState = Keyboard.GetState(0);
            // TODO: Generify!
            if (oldGamePadState.IsButtonDown(changeStatusButton) && gamePadState.IsButtonUp(changeStatusButton)
                || oldKeyboardState.IsKeyDown(changeStatusKey) && keyboardState.IsKeyUp(changeStatusKey))
            {
                parent.getManager().game.currentState = nextState;
            }

            oldKeyboardState = keyboardState;
            oldGamePadState = gamePadState;
        }
    }
}
