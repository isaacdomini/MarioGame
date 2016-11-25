using System;
using System.Collections.Generic;
using MarioGame.Theming;
using MarioGame.Theming.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using MarioGame.Entities;

namespace MarioGame.Core
{
    /*
     * @authors John Simerlink, Adam Roller
     * */
    public class Game1 : Game
    {
        private int _scene;
        private readonly List<Scene> _scenes;
        private readonly Scoreboard _scoreboard = new Scoreboard();
        public static SpriteFont Font { get; private set; }

        public Scene Scene => _scenes[_scene - 1];
        public GraphicsDeviceManager Graphics { get; private set; }


        public Game1()
        {
            var stage = new Stage(this);
            var hiddenStage = new Stage(this);
            var gameOver = new Stage(this);

            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            _scenes = new List<Scene> {new Scene(stage), new HiddenScene(hiddenStage), new GameOver(gameOver), new MainMenu(stage)};
            //_scene = 1;
            EnterMainMenu();
        }


        /// <summary>
        ///     Allows the game to perform any initialization it needs to before starting to run.
        ///     This is where it can query for any required services and load any non-graphic
        ///     related content.  Calling base.Initialize will enumerate through any components
        ///     and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            _scenes.ForEach(s => s.Initialize());

            base.Initialize();
        }

        /// <summary>
        ///     LoadContent will be called once per game and is the place to load
        ///     all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            _scenes.ForEach(s => s.LoadContent());
            Font = Content.Load<SpriteFont>("ScoreboardFont");
        }

        /// <summary>
        ///     UnloadContent will be called once per game and is the place to unload
        ///     game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            Content.Unload();
        }

        /// <summary>
        ///     Allows the game to run logic such as updating the world,
        ///     checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            _scenes[_scene - 1].Update(gameTime);
            base.Update(gameTime);
        }


        /// <summary>
        ///     This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            _scenes[_scene - 1].Draw();
            base.Draw(gameTime);
        }

        public void ExitCommand()
        {
            Exit();
        }
        public void ResetCommand()
        {
            _scenes.Clear();
            _scenes.Add(new Scene(new Stage(this)));
            _scenes.Add(new HiddenScene(new Stage(this)));
            _scenes.Add(new GameOver(new Stage(this)));
            _scenes.Add(new MainMenu(new Stage(this)));
            _scene = 1;
            Initialize();
            LoadContent();
            _scoreboard.InitializeScoreboardList();
        }
        public static bool playAsMario;
        public void PlayAsMarioCommand()
        {
            playAsMario = true;
            ResetCommand();
        }
        //Right now this does the same as PlayAsMarioCommand()
        public void PlayAsEnemyCommand()
        {
            playAsMario = false;
            _scenes.Clear();
            _scenes.Add(new Scene(new Stage(this)));
            _scenes.Add(new HiddenScene(new Stage(this)));
            _scenes.Add(new GameOver(new Stage(this)));
            _scenes.Add(new MainMenu(new Stage(this)));
            _scene = 1;
            Initialize();
            LoadContent();
            _scoreboard.InitializeScoreboardList();
        }
        public void PauseCommand()
        {
            Scene.Pause();
        }
        public void EnterHiddenScene(Mario mario, Vector2 newPosition)
        {
            Scene.Script.RemoveEntity(mario);
            _scene = 2;
            // Set mario to below entrance pipe
            mario.SetPosition(newPosition);
            Scene.Script.AddEntity(mario);
        }
        public void ExitHiddenScene(Mario mario, Vector2 newPosition)
        {
            Scene.Script.RemoveEntity(mario);
            _scene = 1;
            mario.SetPosition(newPosition);
            mario.Jump();
            Scene.Script.AddEntity(mario);
        }
        public void EnterGameOver()
        {
            _scene = 3;
            Scene.Script.Announce(GameOver.Won ? EventTypes.Levelclear : EventTypes.Gameover);
            Scene.SetToGameOver();
        }
        public void EnterMainMenu()
        {
            _scene = 4;
            Scene.SetToMainMenu();
        }
    }
}
