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
        public enum EnemyTypes
        {
            KoopaTroopa,
            Goomba
        }
        public enum ItemTypes
        {
            Star,
            Coins,
            Mushroom1Up,
            MushroomSuper,
            FireFlower
        }

        private readonly Script _script;
        private SpriteBatch _spriteBatch;

        public Scene(Stage stage)
        {
            Stage = stage;
            _script = new Script(this);
        }

        private List<ISprite> Sprites { get; set; }
        private List<ISprite> Enemies { get; set; }
        private List<ISprite> Items { get; set; }
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

            Enemies = new List<ISprite>();
           // Enemies.Add(new KoopaTroopa(middle, this));
          //  Enemies.Add(new Goomba(middle, this));

            Items = new List<ISprite>();
            Items.Add(new Star(middle, this));
            Items.Add(new Coins(middle, this));
            Items.Add(new Mushroom1Up(middle, this));
            Items.Add(new MushroomSuper(middle, this));
            Items.Add(new FireFlower(middle, this));


        }

        public void LoadContent()
        {
            _spriteBatch = new SpriteBatch(Stage.Game1.GraphicsDevice);

            Stage.LoadContent();
            Enemies[EnemyTypes.Goomba.GetHashCode()].Load();
            Enemies[EnemyTypes.KoopaTroopa.GetHashCode()].Load();
            Items[ItemTypes.Coins.GetHashCode()].Load(Stage.Game1.Content, "ItemSheet2", 9, 4);
            Items[ItemTypes.FireFlower.GetHashCode()].Load(Stage.Game1.Content, "ItemSheet2", 9, 4);
            Items[ItemTypes.Mushroom1Up.GetHashCode()].Load(Stage.Game1.Content, "ItemSheet2", 9, 4);
            Items[ItemTypes.MushroomSuper.GetHashCode()].Load(Stage.Game1.Content, "ItemSheet2", 9, 4);
            Items[ItemTypes.Star.GetHashCode()].Load(Stage.Game1.Content, "ItemSheet2", 9, 4);

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

        public Script getScript()
        {
            return this._script;

        }
        public void ShowItems(int sprite)
        {
            foreach(ISprite current in Enemies)
                Enemies[sprite].Visible = true;
            foreach (ISprite current in Items)
                Items[sprite].Visible = true;
        }
    }
}