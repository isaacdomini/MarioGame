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
        protected Texture2D _texture;
        protected string _assetName;
        protected ContentManager _content;

        public Vector2 Position
        {
            get; set;
        }

        public Sprite(ContentManager content)
        {
            _content = content;
        }
        public bool Visible { get; set; }
       

        public virtual void Draw(SpriteBatch batch)
        {
            if (Visible)
            {
                batch.Draw(_texture, Position);
            }
        }

        public virtual void Load(int framesPerSecond = 5)
        {

            _texture = _content.Load<Texture2D>(_assetName);
        }

        public virtual void Update(float elapsed)
        {
            throw new NotImplementedException();
        }

        public virtual void changeActionState(ActionState goombaActionState) { }
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
