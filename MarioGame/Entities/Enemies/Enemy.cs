using MarioGame.Sprites;
using MarioGame.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Entities
{
    public class Enemy : Entity
    {
        public AnimatedSprite eSprite;
        protected bool _isDead;
        protected bool _hurts;
        private readonly static Vector2 fallingVelocity = new Vector2(0, velocityConstant * 1);

        public Enemy(Vector2 position, ContentManager content) : base(position, content)
        {
            _isDead = false;
            _hurts = true;
        }
        public virtual void JumpedOn() { }

        public virtual bool IsDead()
        {
            return _isDead;
        }
        public virtual bool Hurts()
        {
            return _hurts;
        }
        public virtual void ChangeVelocityDirection() { }
        public void SetVelocityToFalling()
        {
            this.setVelocity(fallingVelocity);
        }
    }
}
