using System;
using System.Collections.Generic;
using MarioGame.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MarioGame.Entities;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Theming.Scenes
{
    public class Scene : IDisposable
    {
        //Texture in order to draw bounding boxes on screen from sprint2
        public static Texture2D rectanglePixel;
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
            Console.WriteLine("Add to tile map scripts about to be called");
            ContentManager content = Stage.Game1.Content;
            Factory.addTileMapToScript("Level1.json", _script);
            Console.WriteLine("Add to tile map scripts called");
            /*_script.AddEntity(new Coin(new Vector2(150, 100), content));
            _script.AddEntity(new FireFlower(new Vector2(200, 100), content));
            _script.AddEntity(new Mushroom1Up(new Vector2(250, 100), content));
            _script.AddEntity(new MushroomSuper(new Vector2(300, 100), content));
            _script.AddEntity(new Star(new Vector2(350, 100), content));
            _script.AddMario(new Mario(new Vector2(100, 150), content));
            _script.AddEntity(new KoopaTroopa(new Vector2(450, 100), content));
            _script.AddEntity(new Goomba(new Vector2(500, 100), content));
            _script.AddEntity(new BrickBlock(new Vector2(500, 300), content));

            _script.AddEntity(new GroundBlock(new Vector2(550, 300), content));
            _script.AddEntity(new StepBlock(new Vector2(600, 300), content));
            _script.AddEntity(new UsedBlock(new Vector2(650, 300), content));
            _script.AddEntity(new QuestionBlock(new Vector2(700, 300), content));
            */

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
            //Allows for bounding boxes to be drawn in different colors
            rectanglePixel = new Texture2D(Stage.Game1.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            rectanglePixel.SetData(new[] { Color.White });

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

            // Draw all rectangles
            drawRectangleBorder(_spriteBatch, _script.mario.boundingBox, 1, _script.mario.boxColor);
            foreach (var block in _script._blocks)
            {
                if (block._sprite.Visible == false)
                {
                    drawRectangleBorder(_spriteBatch, block.boundingBox, 1, block.boxColor);
                }
            }
            foreach (var enemy in _script._enemies)
            {
                if (enemy._sprite.Visible == false)
                {
                    drawRectangleBorder(_spriteBatch, enemy.boundingBox, 1, enemy.boxColor);
                }
            }
            foreach (var item in _script._items)
            {
                if (item._sprite.Visible == false)
                {
                    drawRectangleBorder(_spriteBatch, item.boundingBox, 1, item.boxColor);
                }
            }
            _spriteBatch.End();
        }

        public void drawRectangleBorder(SpriteBatch batch, Rectangle toDraw, int borderThickness, Color borderColor)
        {
            // Draw top line
            batch.Draw(Scene.rectanglePixel, new Rectangle((toDraw.X), toDraw.Y, toDraw.Width, 1), borderColor);
            // Draw left line
            batch.Draw(Scene.rectanglePixel, new Rectangle(toDraw.X, toDraw.Y, 1, toDraw.Height), borderColor);
            // Draw right line
            batch.Draw(Scene.rectanglePixel, new Rectangle((toDraw.X + toDraw.Width - 1), toDraw.Y, 1, toDraw.Height), borderColor);
            // Draw bottom line
            batch.Draw(Scene.rectanglePixel, new Rectangle(toDraw.X, toDraw.Y + toDraw.Height - 1, toDraw.Width, 1), borderColor);
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
