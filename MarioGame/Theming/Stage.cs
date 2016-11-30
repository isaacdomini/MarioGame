using System.Collections.Generic;
using MarioGame.Commands;
using MarioGame.Controllers;
using MarioGame.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MarioGame.Commands.BlockCommands;
using MarioGame.Theming.Scenes;
using System;

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

        public GraphicsDeviceManager GraphicsDevice => Game1.Graphics;

        public void Initialize(Scene scene)
        {
            _controllers.Add(new KeyboardController());
            _controllers.Add(new GamepadController());
            _controllers[0].AddCommand((int)Keys.Q, new QuitCommand(Game1));
            //Reset Command
            _controllers[0].AddCommand((int)Keys.R, new ResetCommand(Game1));
            _controllers[1].AddCommand((int) Buttons.Start, new QuitCommand(Game1));

            // Adding jump command to controllers
            _controllers[0].AddCommand((int)Keys.W, new JumpCommand(scene.Script));
            _controllers[0].AddHeldCommand((int)Keys.W, new JumpCommand(scene.Script));
            _controllers[0].AddCommand((int)Keys.Up, new JumpCommand(scene.Script));
            _controllers[0].AddHeldCommand((int)Keys.Up, new JumpCommand(scene.Script));
            _controllers[0].AddGameOverScreenCommand((int)Keys.R, new ResetCommand(Game1));
            _controllers[1].AddGameOverScreenCommand((int)Buttons.Start, new QuitCommand(Game1));
            _controllers[0].AddGameOverScreenCommand((int)Keys.Q, new QuitCommand(Game1));

            _controllers[1].AddMainMenuScreenCommand((int)Buttons.Start, new QuitCommand(Game1));
            _controllers[0].AddMainMenuScreenCommand((int)Keys.Q, new QuitCommand(Game1));
            _controllers[0].AddMainMenuScreenCommand((int)Keys.K, new PlayAsMarioCommand(Game1));
            _controllers[0].AddMainMenuScreenCommand((int)Keys.E, new PlayAsEnemyCommand(Game1));
            _controllers[0].AddMainMenuScreenCommand((int)Keys.M, new MuteCommand(scene.Script));

            // Adding movement commands (Needs updated with actual commands)
            _controllers[0].AddCommand((int)Keys.Left, new MoveLeftCommand(scene.Script));
            _controllers[0].AddHeldCommand((int)Keys.Left, new MoveLeftCommand(scene.Script));
            _controllers[0].AddCommand((int)Keys.A, new MoveLeftCommand(scene.Script));
            _controllers[0].AddHeldCommand((int)Keys.A, new MoveLeftCommand(scene.Script));
            _controllers[0].AddCommand((int)Keys.Right, new MoveRightCommand(scene.Script));
            _controllers[0].AddHeldCommand((int)Keys.Right, new MoveRightCommand(scene.Script));
            _controllers[0].AddCommand((int)Keys.D, new MoveRightCommand(scene.Script));
            _controllers[0].AddHeldCommand((int)Keys.D, new MoveRightCommand(scene.Script));
            _controllers[0].AddCommand((int)Keys.Down, new CrouchCommand(scene.Script));
            _controllers[0].AddCommand((int)Keys.S, new CrouchCommand(scene.Script));
            _controllers[0].AddCommand((int)Keys.Space, new DashOrThrowFireballCommand(scene.Script));

            // Add power up state commands
            _controllers[0].AddCommand((int)Keys.Y, new StandardStateCommand(scene.Script));
            _controllers[0].AddCommand((int)Keys.U, new SuperStateCommand(scene.Script));
            _controllers[0].AddCommand((int)Keys.I, new FireStateCommand(scene.Script));
            _controllers[0].AddCommand((int)Keys.O, new DeadStateCommand(scene.Script));

            // Add block state commands
            _controllers[0].AddCommand((int)Keys.B, new BumpOrBreakBrick(scene.Script));
            _controllers[0].AddCommand((int)Keys.H, new ShowHiddenBlock(scene.Script));
            _controllers[0].AddCommand((int)Keys.X, new ChangeQuestionToUsedState(scene.Script));

            // Adds commands to game controller
            _controllers[1].AddCommand((int)Buttons.DPadLeft, new MoveLeftCommand(scene.Script));
            _controllers[1].AddCommand((int)Buttons.DPadDown, new CrouchCommand(scene.Script));
            _controllers[1].AddCommand((int)Buttons.DPadRight, new MoveRightCommand(scene.Script));
            _controllers[1].AddCommand((int)Buttons.B, new DashOrThrowFireballCommand(scene.Script));
            _controllers[1].AddCommand((int)Buttons.A, new JumpCommand(scene.Script));

            //Adds command to show bounding boxes
            _controllers[0].AddCommand((int)Keys.C, new DrawBoundingBoxes(scene.Script));

            //Add mute command
            _controllers[0].AddCommand((int)Keys.M, new MuteCommand(scene.Script));
            // Add pause commands
            _controllers[0].AddCommand((int)Keys.P, new PauseCommand(Game1));
            _controllers[0].AddPauseScreenCommand((int)Keys.P, new PauseCommand(Game1));

            _controllers[1].AddCommand((int)Buttons.Back, new PauseCommand(Game1));
            _controllers[1].AddPauseScreenCommand((int)Buttons.Back, new PauseCommand(Game1));
        }

        public void Update()
        {
            _controllers.ForEach(c => c.UpdateInput());
        }

        internal void UpdatePause()
        {
            _controllers.ForEach(c => c.UpdatePauseInput());
        }
        internal void UpdateGameOver()
        {
            _controllers.ForEach(c => c.UpdateGameOverInput());
        }
        internal void UpdateMainMenu()
        {
            _controllers.ForEach(c => c.UpdateMainMenuInput());
        }
    }
}
