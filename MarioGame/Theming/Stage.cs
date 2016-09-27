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
            // Adding movement commands (Needs updated with actual commands)
            _controllers[0].AddCommand((int)Keys.Left, new MoveLeftCommand(Game1.Scene.getScript()));
            _controllers[0].AddCommand((int)Keys.Right, new MoveRightCommand(Game1.Scene.getScript()));
            _controllers[0].AddCommand((int)Keys.Down, new CrouchCommand(Game1.Scene.getScript()));
            _controllers[0].AddCommand((int)Keys.Space, new DashOrThrowFireballCommand(Game1.Scene.getScript()));
            _controllers[1].AddCommand((int)Buttons.DPadLeft, new MoveLeftCommand(Game1.Scene.getScript()));
            _controllers[1].AddCommand((int)Buttons.DPadDown, new CrouchCommand(Game1.Scene.getScript()));
            _controllers[1].AddCommand((int)Buttons.DPadRight, new MoveRightCommand(Game1.Scene.getScript()));
            _controllers[1].AddCommand((int)Buttons.B, new DashOrThrowFireballCommand(Game1.Scene.getScript()));
            _controllers[1].AddCommand((int)Buttons.A, new JumpCommand(Game1.Scene.getScript()));


            // Allows for Koopa Troopa to show up on screen at start time
            ICommand KoopaTroopaCommand =new DisplayKoopaTroopa(Game1.Scene);
            KoopaTroopaCommand.Execute();
            // Allows for Enemies to show up on screen at start time
            ICommand GoombaCommand = new DisplayGoomba(Game1.Scene);
            GoombaCommand.Execute();
            // Allows for Items to show up on screen at start time
            ICommand StarCommand = new DisplayStar(Game1.Scene);
            StarCommand.Execute();
            ICommand CoinsCommand = new DisplayStar(Game1.Scene);
            CoinsCommand.Execute();
            ICommand Mushroom1UpCommand = new DisplayStar(Game1.Scene);
            Mushroom1UpCommand.Execute();
            ICommand MushroomSuperCommand = new DisplayStar(Game1.Scene);
            MushroomSuperCommand.Execute();
            ICommand FireFlowerCommand = new DisplayStar(Game1.Scene);
            FireFlowerCommand.Execute();
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