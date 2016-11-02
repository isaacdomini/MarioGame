using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MarioGame.Entities;
using MarioGame.States;

namespace MarioGame.Sprites
{
    public class Sprite : ISprite //TODO: Should we make this class abstract?
    {
        private Texture2D _texture;
        public Texture2D Texture { get { return _texture; } set { _texture = value; } }
        private string _assetName;
        protected string AssetName { get { return _assetName; } set { _assetName = value; } }
        private ContentManager _content;
        protected ContentManager Content { get { return _content; } set { _content = value; } }
        private Entity _entity;
        public Entity Entity { get { return _entity; } set { _entity = value; } }
        public Vector2 Position => Entity.Position;
        private bool _deleted => Entity.Deleted;
        public bool Deleted { get { return _deleted; } }
        public Sprite(ContentManager content, Entity entity)
        {
            Entity = entity;
            Content = content;
        }
       

        public virtual void Draw(SpriteBatch batch)
        {
            batch.Draw(Texture, Position);
        }

        public virtual void Load(int framesPerSecond = 5)
        {

            Texture = Content.Load<Texture2D>(AssetName);
        }

        public virtual void Update(float elapsed)
        {
        }
    }
}
