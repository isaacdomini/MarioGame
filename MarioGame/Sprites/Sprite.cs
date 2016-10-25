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
        protected Texture2D Texture;
        protected string AssetName;
        protected ContentManager Content;
        protected Entity Entity;

        public Vector2 Position => Entity.Position;

        public Sprite(ContentManager content, Entity entity)
        {
            Entity = entity;
            Content = content;
        }

        public bool Visible { get; set; }
       

        public virtual void Draw(SpriteBatch batch)
        {
            if (Visible)
            {
                batch.Draw(Texture, Position);
            }
        }

        public virtual void Load(int framesPerSecond = 5)
        {

            Texture = Content.Load<Texture2D>(AssetName);
        }

        public virtual void Update(float elapsed)
        {
            throw new NotImplementedException();
        }
        public void Show()
        {
            this.Visible = true;
        }
        public void Hide()
        {
            this.Visible = false;
        }
    }
}
