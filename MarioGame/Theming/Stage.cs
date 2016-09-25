using System.Collections.Generic;
using MarioGame.Commands;
using MarioGame.Controllers;
using MarioGame.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MarioGame.Theming
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
            _controllers.Add(new KeyboardController());
            _controllers.Add(new GamepadController());
            _controllers[0].AddCommand((int)Keys.Q, new QuitCommand(Game1));
            _controllers[1].AddCommand((int) Buttons.Start, new QuitCommand(Game1));
            // Adding jump command to controllers
            _controllers[0].AddCommand((int)Keys.W, new JumpCommand(Game1.Scene.getScript()));
            _controllers[0].AddCommand((int)Keys.Up, new JumpCommand(Game1.Scene.getScript()));


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