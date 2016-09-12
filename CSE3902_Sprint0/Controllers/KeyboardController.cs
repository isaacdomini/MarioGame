using System.Collections.Generic;
using CSE3902_Sprint0.Commands;
using CSE3902_Sprint0.Theming;
using Microsoft.Xna.Framework.Input;

namespace CSE3902_Sprint0.Controllers
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