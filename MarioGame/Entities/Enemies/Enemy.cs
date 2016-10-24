using MarioGame.Core;
using MarioGame.Sprites;
using MarioGame.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Entities
{
    public class Enemy : Entity
    {
        public AnimatedSprite _enemySprite { get { return _sprite; } }
        protected EnemyActionState _enemyActionState {get {return (EnemyActionState)aState; } }
        protected bool _isDead;
        public bool Dead { get { return _isDead; } }
        protected bool _hurts;
        public bool Hurts { get { return _hurts; } }
        public Enemy(Vector2 position, ContentManager content) : base(position, content)
        {
            _isDead = false;
            _hurts = true;
            boxPercentSizeOfEntity = .8f;
        }
        public override void Halt()
        {
            Position -= Velocity;
            _enemyActionState.Halt();
        }
        public override void onCollide(IEntity otherObject, Sides side)
        {
            base.onCollide(otherObject, side);
            if (otherObject is Mario )
            {
                if (side == Sides.Top)
                {
                    _isDead = true;
                    _enemyActionState.JumpedOn(); 
                }
            }
            if(otherObject is Block)
            {
                if(side == Sides.Left || side == Sides.Right)
                {
                    _enemyActionState.HitBlock();
                }
            }
        }
        public void ChangeToDeadState()
        {
            _enemyActionState.ChangeToDead();
        }
    }
}
