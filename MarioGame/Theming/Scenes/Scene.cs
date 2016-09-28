using System;
using System.Collections.Generic;
using MarioGame.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MarioGame.Entities.BlockEntities;
using MarioGame.Entities.ItemEntities;
using MarioGame.Entities.PlayerEntities;
using MarioGame.Sprites.BlockSprite;
using MarioGame.Sprites.PlayerSprites;

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

            //TODO DRAW all Sprites
            //TODO init all objects and give them some positions
            _script.AddItem(new CoinEntity(new Vector2(150, 100), new Coins(Stage.Game1.Content)));
            _script.AddItem(new FireFlowerEntity(new Vector2(200, 100), new FireFlower(Stage.Game1.Content)));
            _script.AddItem(new Mushroom1UpEntity(new Vector2(250, 100), new Mushroom1Up(Stage.Game1.Content)));
            _script.AddItem(new MushroomSuperEntity(new Vector2(300, 100), new MushroomSuper(Stage.Game1.Content)));
            _script.AddItem(new StarEntity(new Vector2(350, 100), new Star(Stage.Game1.Content)));
            _script.AddMario(new MarioEntity(new Vector2(100, 150), new MarioSprite(Stage.Game1.Content)));
        }

        public void LoadContent()
        {
            _spriteBatch = new SpriteBatch(Stage.Game1.GraphicsDevice);

            Stage.LoadContent();

            Sprites.Add(_script.mario.mSprite);
            foreach (var block in _script._blocks)
                Sprites.Add(block._sprite);
            foreach (var item in _script._items)
                Sprites.Add(item._sprite);
            foreach (var enemy in _script._enemies)
                Sprites.Add(enemy._sprite);


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

    }
}