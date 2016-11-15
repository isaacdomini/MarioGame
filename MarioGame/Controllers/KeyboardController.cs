using System;
using System.Collections.Generic;
using MarioGame.Commands;
using Microsoft.Xna.Framework.Input;

namespace MarioGame.Controllers
{
    public class KeyboardController : IController
    {

        public KeyboardController()
        {
            _previousState = Keyboard.GetState();
            Dictionary = new Dictionary<Keys, ICommand>();
            PauseKeys = new Dictionary<Keys, ICommand>();
            GameOverKeys = new Dictionary<Keys, ICommand>();
            HeldDictionary = new Dictionary<Keys, ICommand>();
        }

        public void AddCommand(int key, ICommand command)
        {
            var keyList = (Keys[])Enum.GetValues(typeof(Keys));
            foreach (var keys in keyList)
            {
                if ((int) keys == key) Dictionary.Add(keys, command);
            }

        }

        public void AddHeldCommand(int key, ICommand command)
        {
            var keyList = (Keys[]) Enum.GetValues(typeof(Keys));
            foreach (var keys in keyList)
            {
                if ((int) keys == key) HeldDictionary.Add(keys, command);
            }
        }

        private Dictionary<Keys, ICommand> Dictionary { get; set; }
        public Dictionary<Keys, ICommand> HeldDictionary { get; }
        private Dictionary<Keys, ICommand> PauseKeys { get; set; }
        private Dictionary<Keys, ICommand> GameOverKeys { get; set; }

        public void UpdateInput()
        {
            var newState = Keyboard.GetState();
            ICommand command;
            foreach (var key in newState.GetPressedKeys())
                if (!_previousState.IsKeyDown(key) && Dictionary.TryGetValue(key, out command))
                {
                    command.Execute();
                } else if (_previousState.IsKeyDown(key) && HeldDictionary.TryGetValue(key, out command))
                {
                    command.Execute();
                }

            _previousState = newState;
        }

        public void UpdatePauseInput()
        {
            var newState = Keyboard.GetState();
            ICommand command;
            foreach (var key in newState.GetPressedKeys())
                if (!_previousState.IsKeyDown(key) && PauseKeys.TryGetValue(key, out command))
                {
                    command.Execute();
                }

            _previousState = newState;
        }
        public void UpdateGameOverInput()
        {
            var newState = Keyboard.GetState();
            ICommand command;
            foreach (var key in newState.GetPressedKeys())
                if (!_previousState.IsKeyDown(key) && GameOverKeys.TryGetValue(key, out command))
                {
                    command.Execute();
                }

            _previousState = newState;
        }

        public void AddPauseScreenCommand(int key, ICommand command)
        {
            var keyList = (Keys[])Enum.GetValues(typeof(Keys));
            foreach (var keys in keyList)
            {
                if ((int)keys == key) PauseKeys.Add(keys, command);
            }
        }

        public void AddGameOverScreenCommand(int key, ICommand command)
        {
            var keyList = (Keys[])Enum.GetValues(typeof(Keys));
            foreach (var keys in keyList)
            {
                if ((int)keys == key) GameOverKeys.Add(keys, command);
            }
        }
    }
}
