﻿using System;
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
        public Camera camera;
        Vector2 camPos;

        public Scene(Stage stage)
        {
            Stage = stage;
            _script = new Script(this);
        }

        private List<Layer> Layers { get; set; }
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
            Layers = new List<Layer>();
            var middle = new Vector2(Stage.Game1.GraphicsDevice.Viewport.Width/2f,
                Stage.Game1.GraphicsDevice.Viewport.Height/2f);

            LevelLoader.addTileMapToScript("Level1.json", _script, Stage.Game1.Content);
            camera = new Camera(Stage.Game1.GraphicsDevice.Viewport);
            camPos = camera.Position;

        }

        public void LoadContent()
        {
            _spriteBatch = new SpriteBatch(Stage.Game1.GraphicsDevice);

            Stage.LoadContent();
            Layers.Add(new Layer(camera, new Vector2(0.5f, 1.0f)));
            Layers.Add(new Layer(camera, new Vector2(1.0f, 1.0f)));
            foreach (Entity e in _script._entities)
            {
                if(e is Cloud)
                {
                    Layers[0].Add(e._sprite);
                }
                else
                {
                    Layers[1].Add(e._sprite);
                }
            }

            Layers.ForEach(l => l.Load());
            _script._entities.ForEach(e => e.LoadBoundingBox());
            //Allows for bounding boxes to be drawn in different colors
            rectanglePixel = new Texture2D(Stage.Game1.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            rectanglePixel.SetData(new[] { Color.White });

        }

        public void Update(GameTime gameTime)
        {
            Stage.Update(gameTime);
            _script.Update(gameTime);
            // TODO Should we update the sprites in script? That way we are only doing updates from one location
            Layers.ForEach(l => l.Sprites.ForEach(s => s.Update((float)gameTime.ElapsedGameTime.TotalSeconds)));
            //camera.Position = new Vector2(camera.Position.X + 1, camera.Position.Y);
            //camera.LookAt(_script.mario.position);
        }

        public void Draw(GameTime gameTime)
        {
            Stage.Draw(gameTime, _spriteBatch);
            Layers.ForEach(l => l.Draw(_spriteBatch));
            _spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, camera.GetViewMatrix(new Vector2(1.0f)));
            _script._entities.FindAll(e => (!e._sprite.Visible)&& !(e is Cloud)).
                ForEach(e => drawRectangleBorder(_spriteBatch, e.boundingBox, 1, e.BoxColor));
            _spriteBatch.End();
            _spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, camera.GetViewMatrix(new Vector2(0.5f)));
            _script._entities.FindAll(e => (!e._sprite.Visible) && (e is Cloud)).
                ForEach(e => drawRectangleBorder(_spriteBatch, e.boundingBox, 1, e.BoxColor));
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
