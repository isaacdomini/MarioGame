using MarioGame.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Entities
{
    public class Enemy :Entity
    {
        public AnimatedSprite eSprite;
        public Enemy(Vector2 position, ContentManager content) : base(position, content)
        {

        }
        public virtual void JumpedOn() { }
    }
}
