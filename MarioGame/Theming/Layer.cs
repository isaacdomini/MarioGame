using MarioGame.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.Theming
{
    public class Layer
    {
        public Layer(Camera camera, Vector2 parallax)
        {
            _camera = camera;
            Parallax = parallax;
            Sprites = new List<ISprite>();
        }

        public Vector2 Parallax { get; set; }
        public List<ISprite> Sprites { get; private set; }

        public void Add(ISprite sprite)
        {
            this.Sprites.Add(sprite);
        }
        public void Load()
        {
            Sprites.ForEach(s => s.Load());
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, _camera.GetViewMatrix(Parallax));
            foreach (ISprite sprite in Sprites)
                sprite.Draw(spriteBatch);
            spriteBatch.End();
        }

        private readonly Camera _camera;
    }
}
