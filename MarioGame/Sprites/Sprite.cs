using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame.Sprites
{
    public class Sprite : ISprite //TODO: Should we make this class abstract?
    {
        protected Vector2 _position;
        protected Texture2D _texture;
        protected string _assetName;

        public bool Visible
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual void Draw(SpriteBatch batch)
        {
            if (Visible)
                batch.Draw(_texture, _position);
        }

        public virtual void Load(ContentManager content, int frameCount = 1, int framesPerSecond = 1)
        {
            _texture = content.Load<Texture2D>(_assetName);
        }

        public virtual void Update(float elapsed)
        {
            throw new NotImplementedException();
        }
    }
}
