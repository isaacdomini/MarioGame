using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MarioGame.Entities;

namespace MarioGame.Sprites
{
    public class Sprite : ISprite //TODO: Should we make this class abstract?
    {
        protected Texture2D _texture;
        protected IEntity _entity;
        protected string _assetName;
        protected ContentManager _content;
        protected Viewport _viewport;

        protected Vector2 _position
        {
            get
            {
                return _entity.getPosition();
            }
            set { }
        }

        public Sprite(IEntity entity, ContentManager content, Viewport viewport)
        {
            _entity = entity;
            _content = content;
            _viewport = viewport;
        }
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
            {
                batch.Draw(_texture, _position);
            }
        }

        public virtual void Load(int framesPerSecond = 1)
        {
            _texture = _content.Load<Texture2D>(_assetName);
        }

        public virtual void Update(float elapsed)
        {
            throw new NotImplementedException();
        }
    }
}
