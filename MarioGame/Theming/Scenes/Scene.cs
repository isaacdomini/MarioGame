using System;
using System.Collections.Generic;
using MarioGame.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame.Theming.Scenes
{
    public class Scene : IDisposable
    {
        public enum SpriteTypes
        {
            StaticStill,
            StaticMoving,
            AnimatedStill,
            AnimatedMoving
        }

        private readonly Script _script;
        private SpriteBatch _spriteBatch;

        public Scene(Stage stage)
        {
            Stage = stage;
            _script = new Script(this);
        }

        private List<ISprite> Sprites { get; set; }

        public Stage Stage { get; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Initialize()
        {
            Stage.Initialize();
            _script.Initialize();
            Sprites = new List<ISprite>();
            var middle = new Vector2(Stage.Game1.GraphicsDevice.Viewport.Width/2f,
                Stage.Game1.GraphicsDevice.Viewport.Height/2f);
            Sprites.Add(new StaticStillSprite(middle));
            Sprites.Add(new StaticMovingSprite(middle));
            Sprites.Add(new AnimatedStillSprite(middle));
            Sprites.Add(new AnimatedMovingSprite(middle, this));
        }

        public void LoadContent()
        {
            _spriteBatch = new SpriteBatch(Stage.Game1.GraphicsDevice);

            Stage.LoadContent();
            Sprites[SpriteTypes.StaticStill.GetHashCode()].Load(Stage.Game1.Content, "mariostanding");
            Sprites[SpriteTypes.StaticMoving.GetHashCode()].Load(Stage.Game1.Content, "mariodead");
            Sprites[SpriteTypes.AnimatedStill.GetHashCode()].Load(Stage.Game1.Content, "mariorunningright", 3, 4);
            Sprites[SpriteTypes.AnimatedMoving.GetHashCode()].Load(Stage.Game1.Content, "mariorunningright", 3, 4);
        }

        public void Update(GameTime gameTime)
        {
            Stage.Update(gameTime);
            foreach (var current in Sprites)
                current.Update((float) gameTime.ElapsedGameTime.TotalSeconds);
        }

        public void Draw(GameTime gameTime)
        {
            Stage.Draw(gameTime, _spriteBatch);

            _spriteBatch.Begin();

            foreach (var current in Sprites)
                current.Draw(_spriteBatch);

            _spriteBatch.End();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                _spriteBatch.Dispose();
        }

        public void ChangeSprite(int sprite)
        {
            foreach (ISprite current in Sprites)
                current.Visible = false;
            Sprites[sprite].Visible = true;
        }
    }
}