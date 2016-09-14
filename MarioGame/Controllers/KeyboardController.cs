using System.Collections.Generic;
using MarioGame.Commands;
using MarioGame.Theming;
using Microsoft.Xna.Framework.Input;

namespace MarioGame.Controllers
{
    public class KeyboardController : IController
    {
        private KeyboardState _previousState;

        public KeyboardController()
        {
            _previousState = Keyboard.GetState();
        }

        public KeyboardController(Dictionary<Keys, ICommand> dictionary) : this()
        {
            Dictionary = dictionary;
        }

        public Dictionary<Keys, ICommand> Dictionary { get; set; }

        public void UpdateInput()
        {
            var newState = Keyboard.GetState();
            ICommand command;
            foreach (var key in newState.GetPressedKeys())
                if (!_previousState.IsKeyDown(key) && Dictionary.TryGetValue(key, out command))
                    command.Execute();

            _previousState = newState;
        }
    }
}