using System;
using System.Collections.Generic;
using MarioGame.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MarioGame.Entities.ItemEntities;
using MarioGame.Entities.PlayerEntities;
using MarioGame.Sprites.BlockSprites;
using MarioGame.Sprites.PlayerSprites;
using MarioGame.Entities.EnemyEntities;
using MarioGame.Entities.BlockEntities;

namespace MarioGame.Theming.Scenes
{
    public class Scene : IDisposable
    {

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
            _script.AddItem(new CoinEntity(new Vector2(150, 100), new CoinsSprite(Stage.Game1.Content)));
            _script.AddItem(new FireFlowerEntity(new Vector2(200, 100), new FireFlowerSprite(Stage.Game1.Content)));
            _script.AddItem(new Mushroom1UpEntity(new Vector2(250, 100), new Mushroom1UpSprite(Stage.Game1.Content)));
            _script.AddItem(new MushroomSuperEntity(new Vector2(300, 100), new MushroomSuperSprite(Stage.Game1.Content)));
            _script.AddItem(new StarEntity(new Vector2(350, 100), new StarSprite(Stage.Game1.Content)));
            _script.AddMario(new MarioEntity(new Vector2(100, 150), new MarioSprite(Stage.Game1.Content)));
            _script.AddEnemy(new KoopaTroopaEntity(new Vector2(450, 100), new KoopaTroopaSprite(Stage.Game1.Content)));
            _script.AddEnemy(new GoombaEntity(new Vector2(500, 100), new GoombaSprite(Stage.Game1.Content)));
            _script.AddBlock(new BrickBlockEntity(new Vector2(500, 300), new BrickBlockSprite(Stage.Game1.Content)));
            _script.AddBlock(new GroundBlockEntity(new Vector2(550, 300), new GroundBlockSprite(Stage.Game1.Content)));
            _script.AddBlock(new StepBlockEntity(new Vector2(600, 300), new StepBlockSprite(Stage.Game1.Content)));
            _script.AddBlock(new UsedBlockEntity(new Vector2(650, 300), new UsedBlockSprite(Stage.Game1.Content)));
            _script.AddBlock(new QuestionBlockEntity(new Vector2(700, 300), new QuestionBlockSprite(Stage.Game1.Content)));

        }

        public void LoadContent()
        {
            _spriteBatch = new SpriteBatch(Stage.Game1.GraphicsDevice);

            Stage.LoadContent();

            Sprites.Add(_script.mario.mSprite);
            _script._blocks.ForEach(b => Sprites.Add(b._sprite));
            _script._items.ForEach(i => Sprites.Add(i._sprite));
            _script._enemies.ForEach(e => Sprites.Add(e._sprite));

            Sprites.ForEach(s => s.Load());

        }

        public void Update(GameTime gameTime)
        {
            Stage.Update(gameTime);
            _script.Update(gameTime);
            // TODO Should we update the sprites in script? That way we are only doing updates from one location
            Sprites.ForEach(s => s.Update((float)gameTime.ElapsedGameTime.TotalSeconds));
        }

        public void Draw(GameTime gameTime)
        {
            Stage.Draw(gameTime, _spriteBatch);

            _spriteBatch.Begin();
            Sprites.ForEach(s => s.Draw(_spriteBatch));
            _spriteBatch.End();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                _spriteBatch.Dispose();
        }

        public Script getScript()
        {
            return this._script;

        }

    }
}