using System;
using System.Collections.Generic;
using MarioGame.Core;
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
        protected static Texture2D RectanglePixel;
        protected SpriteBatch SpriteBatch;
        protected Camera _camera;
        public Camera Camera => _camera;
        private bool _drawBox=false;

        public Script Script { get; }
        protected List<Layer> Layers { get; set; }
        private const int ActionLayer = 2;
        public Stage Stage { get; }
        public Game1 Game1 => Stage.Game1;
        private bool _paused;

        public Scene(Stage stage)
        {
            Stage = stage;
            Script = new Script(this);
            _paused = false;
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Initialize()
        {
            Stage.Initialize();
            Script.Initialize();

            _camera = new Camera(Stage.Game1.GraphicsDevice.Viewport);
            Layers = new List<Layer>
            {
                new Layer(Camera, new Vector2(0.1f, 1.0f)),
                new Layer(Camera, new Vector2(0.5f, 1.0f)),
                new Layer(Camera, new Vector2(1.0f, 1.0f))
            };
            var middle = new Vector2(Stage.Game1.GraphicsDevice.Viewport.Width/2f,
                Stage.Game1.GraphicsDevice.Viewport.Height/2f);

            LevelLoader.AddTileMapToScript("Level1.json", Script, Stage.Game1);
        }

        public void AddActionSprite(Sprite s)
        {
            Layers[ActionLayer].Add(s);
        }

        public void AddToLayer(int layer, Sprite s)
        {
            Layers[layer].Add(s);
        }
        public void LoadContent()
        {
            SpriteBatch = new SpriteBatch(Stage.Game1.GraphicsDevice);

            UpdateItemVisibility();
            Layers.ForEach(l => l.Load());
            
            Script.Entities.ForEach(e => e.LoadBoundingBox());
            //Allows for bounding boxes to be drawn in different colors
            RectanglePixel = new Texture2D(Stage.Game1.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            RectanglePixel.SetData(new[] { Color.White });
        }
        public void UpdateItemVisibility()
        {
            Script.updateItemVisibility(Layers[ActionLayer]);
        }
        public void Update(GameTime gameTime)
        {
            if (!_paused)
            {
                Stage.Update();
                Script.Update(gameTime);
                // TODO Should we update the sprites in script? That way we are only doing updates from one location
                Layers.ForEach(l => l.Sprites.ForEach(s => s.Update((float)gameTime.ElapsedGameTime.TotalSeconds)));
                //_layers.ForEach(l => Script.updateItemVisibility(l));
                //camera.Position = new Vector2(camera.Position.X + 1, camera.Position.Y);
                //camera.LookAt(_script.mario.position);
            }
            else
            {
                Stage.CheckForResume();
            }

        }

        public void Draw()
        {
            Stage.Draw();
            Layers.ForEach(l => l.Draw(SpriteBatch));
            Mario.Scoreboard.DrawScoreboard(SpriteBatch);
            
            if (_drawBox)
            {
                SpriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, Camera.GetViewMatrix(new Vector2(1.0f)));
                Script.Entities.FindAll(e => !(e is BackgroundItem)).//TODO: make it so that bounding boxes are handled in the specific entities sprite's draw method
                    ForEach(e => DrawRectangleBorder(SpriteBatch, e.BoundingBox, e.BoxColor));
                SpriteBatch.End();
                SpriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, Camera.GetViewMatrix(new Vector2(0.5f)));
                Script.Entities.FindAll(e => (e is BackgroundItem)).
                    ForEach(e => DrawRectangleBorder(SpriteBatch, e.BoundingBox, e.BoxColor));
                SpriteBatch.End();
            }

        }
        public void DrawBoundingBoxes()
        {
            _drawBox = !_drawBox;
        }
        public static void DrawRectangleBorder(SpriteBatch batch, Rectangle toDraw, Color borderColor)
        {
            // Draw top line
            batch.Draw(Scene.RectanglePixel, new Rectangle((toDraw.X), toDraw.Y, toDraw.Width, 1), borderColor);
            // Draw left line
            batch.Draw(Scene.RectanglePixel, new Rectangle(toDraw.X, toDraw.Y, 1, toDraw.Height), borderColor);
            // Draw right line
            batch.Draw(Scene.RectanglePixel, new Rectangle((toDraw.X + toDraw.Width - 1), toDraw.Y, 1, toDraw.Height), borderColor);
            // Draw bottom line
            batch.Draw(Scene.RectanglePixel, new Rectangle(toDraw.X, toDraw.Y + toDraw.Height - 1, toDraw.Width, 1), borderColor);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                SpriteBatch.Dispose();
        }
        internal void Pause()
        {
            _paused = !_paused;
        }

    }
}
