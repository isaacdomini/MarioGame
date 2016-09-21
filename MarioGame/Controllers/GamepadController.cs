using System;
using System.Collections.Generic;
using MarioGame.Commands;
using MarioGame.Theming;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MarioGame.Controllers
{
    public class GamepadController : IController
    {
        private GamePadState _previousState;
        public Dictionary<Buttons, ICommand> Dictionary { get; set; }

        public GamepadController()
        {
            _previousState = GamePad.GetState(PlayerIndex.One);
            Dictionary = new Dictionary<Buttons, ICommand>();
        }

        public void AddCommand(int key, ICommand command)
        {
            var keyList = (Buttons[])Enum.GetValues(typeof(Buttons));
            foreach (var keys in keyList)
            {
                if ((int)keys == key) Dictionary.Add(keys, command);
            }
        }



        public void UpdateInput()
        {
            var newState = GamePad.GetState(PlayerIndex.One);
            if (newState.IsConnected)
            {
                ICommand command;
                foreach (var button in Dictionary.Keys)
                    if (!_previousState.IsButtonDown(button) && newState.IsButtonDown(button) &&
                        Dictionary.TryGetValue(button, out command))
                        command.Execute();

                _previousState = newState;
            }
        }
    }
}