using System.Collections.Generic;
using CSE3902_Sprint0.Commands;
using CSE3902_Sprint0.Controllers;
using CSE3902_Sprint0.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CSE3902_Sprint0.Theming
{
    public class Stage
    {
        private readonly List<IController> _controllers;

        public Stage(Game1 game1)
        {
            Game1 = game1;
            _controllers = new List<IController>();
        }

        public Game1 Game1 { get; set; }

        public GraphicsDeviceManager GraphicsDevice
        {
            get { return Game1.Graphics; }
        }

        public void Initialize()
        {
            var keyboarddictionary = new Dictionary<Keys, ICommand>
            {
                {Keys.Q, new QuitCommand(Game1)},
                {Keys.W, new SwitchToStaticStillCommand(Game1.Scene)},
                {Keys.R, new SwitchToStaticMovingCommand(Game1.Scene)},
                {Keys.E, new SwitchToAnimatedStillCommand(Game1.Scene)},
                {Keys.T, new SwitchToAnimatedMovingCommand(Game1.Scene)}
            };
            _controllers.Add(new KeyboardController(keyboarddictionary));
            var gamepaddictionary = new Dictionary<Buttons, ICommand>
            {
                {Buttons.Start, new QuitCommand(Game1)},
                {Buttons.A, new SwitchToStaticStillCommand(Game1.Scene)},
                {Buttons.X, new SwitchToStaticMovingCommand(Game1.Scene)},
                {Buttons.B, new SwitchToAnimatedStillCommand(Game1.Scene)},
                {Buttons.Y, new SwitchToAnimatedMovingCommand(Game1.Scene)}
            };
            _controllers.Add(new GamepadController(gamepaddictionary));
        }

        public void LoadContent()
        {
        }

        public void Update(GameTime gameTime)
        {
            foreach (var controller in _controllers)
                controller.UpdateInput();
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            GraphicsDevice.GraphicsDevice.Clear(Color.CornflowerBlue);
        }
    }
}