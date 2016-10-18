using MarioGame.Sprites;
using MarioGame.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Entities
{
    public class Enemy :Entity
    {
        public AnimatedSprite eSprite;
        public ActionState aState;
        protected bool _isDead;
        public Enemy(Vector2 position, ContentManager content) : base(position, content)
        {
            _isDead = false;
        }
        public virtual void JumpedOn() { }

        public virtual bool IsDead()
        {
            return _isDead;
        }
    }
}
