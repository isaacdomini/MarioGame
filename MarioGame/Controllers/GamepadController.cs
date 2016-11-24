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
        private Dictionary<Buttons, ICommand> Dictionary { get; set; }
        public Dictionary<Buttons, ICommand> HeldDictionary { get; }
        private Dictionary<Buttons, ICommand> PauseScreenKeys { get; set; }
        private Dictionary<Buttons, ICommand> GameOverScreenKeys { get; set; }
        private Dictionary<Buttons, ICommand> MainMenuScreenKeys { get; set; }


        public GamepadController()
        {
            _previousState = GamePad.GetState(PlayerIndex.One);
            Dictionary = new Dictionary<Buttons, ICommand>();
            HeldDictionary = new Dictionary<Buttons, ICommand>();
            PauseScreenKeys = new Dictionary<Buttons, ICommand>();
            GameOverScreenKeys = new Dictionary<Buttons, ICommand>();
            MainMenuScreenKeys = new Dictionary<Buttons, ICommand>();
        }

        public void AddCommand(int key, ICommand command)
        {
            var keyList = new List<Buttons>((Buttons[]) Enum.GetValues(typeof(Buttons)));
            
            foreach (var keys in keyList)
            {
                if ((int)keys == key & !Dictionary.ContainsKey(keys)) Dictionary.Add(keys, command);
            }
        }
        public void AddHeldCommand(int key, ICommand command)
        {
            var keyList = (Buttons[])Enum.GetValues(typeof(Buttons));
            foreach (var keys in keyList)
            {
                if ((int)keys == key & !HeldDictionary.ContainsKey(keys)) HeldDictionary.Add(keys, command);
            }
        }
        
        public void UpdateInput()
        {
            var indeces = new List<PlayerIndex> {PlayerIndex.One, PlayerIndex.Two, PlayerIndex.Three, PlayerIndex.Four};
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

        public void UpdatePauseInput()
        {
            var indeces = new List<PlayerIndex> {PlayerIndex.One, PlayerIndex.Two, PlayerIndex.Three, PlayerIndex.Four};
            foreach (var index in indeces)
            {
                var newState = GamePad.GetState(index);
                if (!newState.IsConnected) continue;
                ICommand command;
                foreach (var button in Dictionary.Keys)
                    if (!_previousState.IsButtonDown(button) && newState.IsButtonDown(button) &&
                        PauseScreenKeys.TryGetValue(button, out command))
                        command.Execute();

                _previousState = newState;
            }
        }
        public void UpdateGameOverInput()
        {
            var indeces = new List<PlayerIndex> { PlayerIndex.One, PlayerIndex.Two, PlayerIndex.Three, PlayerIndex.Four };
            foreach (var index in indeces)
            {
                var newState = GamePad.GetState(index);
                if (!newState.IsConnected) continue;
                ICommand command;
                foreach (var button in Dictionary.Keys)
                    if (!_previousState.IsButtonDown(button) && newState.IsButtonDown(button) &&
                        GameOverScreenKeys.TryGetValue(button, out command))
                        command.Execute();

                _previousState = newState;
            }
        }

        public void UpdateMainMenuInput()
        {
            var indeces = new List<PlayerIndex> { PlayerIndex.One, PlayerIndex.Two, PlayerIndex.Three, PlayerIndex.Four };
            foreach (var index in indeces)
            {
                var newState = GamePad.GetState(index);
                if (!newState.IsConnected) continue;
                ICommand command;
                foreach (var button in Dictionary.Keys)
                    if (!_previousState.IsButtonDown(button) && newState.IsButtonDown(button) &&
                        MainMenuScreenKeys.TryGetValue(button, out command))
                        command.Execute();

                _previousState = newState;
            }
        }

        public void AddPauseScreenCommand(int key, ICommand command)
        {
            var keyList = new List<Buttons>((Buttons[]) Enum.GetValues(typeof(Buttons)));
            keyList.FindAll(k => (int) k == key).ForEach(k =>
            {
                if (!PauseScreenKeys.ContainsKey(k))
                        PauseScreenKeys.Add(k, command);
            });
        }
        public void AddGameOverScreenCommand(int key, ICommand command)
        {
            var keyList = new List<Buttons>((Buttons[])Enum.GetValues(typeof(Buttons)));
            keyList.FindAll(k => (int)k == key).ForEach(k =>
                {
                    if (!GameOverScreenKeys.ContainsKey(k))
                        GameOverScreenKeys.Add(k, command);
                });
        }
        public void AddMainMenuScreenCommand(int key, ICommand command)
        {
            var keyList = new List<Buttons>((Buttons[])Enum.GetValues(typeof(Buttons)));
            keyList.FindAll(k => (int)k == key).ForEach(k =>
                {
                    if (!MainMenuScreenKeys.ContainsKey(k))
                        MainMenuScreenKeys.Add(k, command);
                });
        }
    }
}