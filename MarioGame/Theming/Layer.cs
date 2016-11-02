using MarioGame.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioGame.Theming
{
    public class Layer
    {
        public Layer(Camera camera, Vector2 parallax)
        {
            _camera = camera;
            Parallax = parallax;
            Sprites = new List<Sprite>();
        }

        public Vector2 Parallax { get; set; }
        public List<Sprite> Sprites { get; private set; }

        public void Add(Sprite sprite)
        {
            this.Sprites.Add(sprite);
        }
        public void Remove(Sprite sprite)
        {
            this.Sprites.Remove(sprite);
        }
        public void Load()
        {
            Sprites.ForEach(s => s.Load(GlobalConstants.FramesPerSecond));
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, _camera.GetViewMatrix(Parallax));
            Sprites = Sprites.FindAll(s => !s.Deleted);
            Sprites.ForEach(s => s.Draw(spriteBatch));
            spriteBatch.End();
        }

        private Camera _camera;
        public Camera Camera => _camera;

        public Vector2 WorldToScreen(Vector2 worldPosition)
        {
            return Vector2.Transform(worldPosition, _camera.GetViewMatrix(Parallax));
        }
        public Vector2 ScreenToWorld(Vector2 screenPosition)
        {
            return Vector2.Transform(screenPosition, Matrix.Invert(_camera.GetViewMatrix(Parallax)));
        }
    }
}
