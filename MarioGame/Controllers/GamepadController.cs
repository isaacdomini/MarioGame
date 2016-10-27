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
        public Dictionary<Buttons, ICommand> HeldDictionary { get; set; }

        public GamepadController()
        {
            _previousState = GamePad.GetState(PlayerIndex.One);
            Dictionary = new Dictionary<Buttons, ICommand>();
            HeldDictionary = new Dictionary<Buttons, ICommand>();
        }

        public void AddCommand(int key, ICommand command)
        {
            var keyList = (Buttons[])Enum.GetValues(typeof(Buttons));
            foreach (var keys in keyList)
            {
                if ((int)keys == key) Dictionary.Add(keys, command);
            }
        }
        public void AddHeldCommand(int key, ICommand command)
        {
            var keyList = (Buttons[])Enum.GetValues(typeof(Buttons));
            foreach (var keys in keyList)
            {
                if ((int)keys == key) HeldDictionary.Add(keys, command);
            }
        }



        public void UpdateInput()
        {
            var indeces = new List<PlayerIndex>();
            indeces.Add(PlayerIndex.One);
            indeces.Add(PlayerIndex.Two);
            indeces.Add(PlayerIndex.Three);
            indeces.Add(PlayerIndex.Four);
            foreach (var index in indeces)
            {
                var newState = GamePad.GetState(index);
                if (!newState.IsConnected) continue;
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